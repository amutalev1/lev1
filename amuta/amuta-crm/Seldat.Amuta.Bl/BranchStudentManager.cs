using Seldat.Amuta.Bl;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Amuta;
using Seldat.Utils;
using System;
using Unity;

namespace Seldat.Amuta.BL
{
    public class BranchStudentManager
    {
        private static readonly IBaseLogger _logger;
        static BranchStudentManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        #region Managers
        static IBranchStudentDataManager _branchStudentDataManager;
        static IBranchStudentDataManager BranchStudentDataManager
        {
            get
            {
                if (_branchStudentDataManager == null)
                {
                    _branchStudentDataManager = DIManager.Container.Resolve<IBranchStudentDataManager>();
                }
                return _branchStudentDataManager;
            }
        }

        static IStudentDataManager _studentDataManager;
        static IStudentDataManager StudentDataManager
        {
            get
            {
                if (_studentDataManager == null)
                {
                    _studentDataManager = DIManager.Container.Resolve<IStudentDataManager>();
                }
                return _studentDataManager;
            }
        }
        #endregion

        public static int ApprovalRegistrationStudent(int branchStudentId)
        {
            try
            {
                string entryHebrewDate = DateConverter.GetHebrewDate(DateTime.Today);
                int update = BranchStudentDataManager.ApprovalRegistrationStudent(branchStudentId, entryHebrewDate);
                return update;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to approve registration for the student in this branchbranch.");
                throw;
            }
        }

       

        public static int RequestRregistration(BranchStudent branchStudent)
        {
            try
            {
                
                int insert = BranchStudentDataManager.RequestRegistrationBranchStudent(branchStudent);
                return insert;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to insert the requested branch by student.");
                throw;
            }

        }

        public static int RequestRregistration(int studentId, int branchId, int? studyPathId)
        {
            try
            {
                int insert = BranchStudentDataManager.RequestRegistrationBranchStudent(studentId, branchId, studyPathId);
                return insert;
            }
            catch (Exception)
            {
                _logger.Debug($"Failed to insert the requested branch by studentId: {studentId}.");
                throw;
            }

        }

        public static int RegistrationStudentToBranch(int studentId, int branchId)
        {
            string entryHebrewDate = DateConverter.GetHebrewDate(DateTime.Today);
            int insert = BranchStudentDataManager.RegistrationStudentToBranch(studentId, branchId, entryHebrewDate);
            return insert;
        }

        public static int SetStudentActiveInBranch(int studentId, int branchId)
        {
            try
            {
                int insert = RegistrationStudentToBranch(studentId, branchId);
                BranchManager.IncreaseNumberOfStudents(branchId);
                StudentDataManager.SetStudentActive(studentId);
                return insert;
            }
            catch (Exception)
            {
                _logger.Debug("Failed to set the student to active in this branch.");
                throw;
            }
        }

        public static int SetStudentInactiveInBranch(int studentId, int branchId)
        {
            try
            {
                string releaseHebrewDate = DateConverter.GetHebrewDate(DateTime.UtcNow);
                int update = BranchStudentDataManager.SetStudentInactiveInBranch(studentId, branchId, releaseHebrewDate);
                if (update == 1)
                    BranchManager.ReduceNumberOfStudents(branchId);
                BranchesStudents branchStudents = BranchStudentDataManager.GetActiveBranchesOfStudent(studentId);
                if (branchStudents.Count() == 0)
                    StudentDataManager.SetStudentInactive(studentId);
                return update;
            }
            catch (Exception)
            {
                _logger.Debug("Failed to set the student to inactive in this branch.");
                throw;
            }
        }

        public static int SetBranchOfStudentInactive(int studentId)
        {
            try
            {
                int update = 0;
                BranchesStudents branchesStudent = BranchStudentDataManager.GetActiveBranchesOfStudent(studentId,Student.Includes.Branch);
                string releaseHebrewDate = DateConverter.GetHebrewDate(DateTime.UtcNow);
                foreach (BranchStudent branchStudent in branchesStudent)
                {
                    update = BranchStudentDataManager.SetStudentInactiveInBranch(studentId, branchStudent.Branch.Id, releaseHebrewDate);
                    BranchManager.ReduceNumberOfStudents(branchStudent.Branch.Id);
                }
                return update;
            }
            catch (Exception ex)
            {
                _logger.Debug("Failed to set the student to inactive in his branches.");
                throw;
            }
        }

        public static int MakeBranchStudentsInactive(int branchId)
        {
            return BranchStudentDataManager.MakeBranchStudentsInactive(branchId);
        }

    }
}
