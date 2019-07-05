using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Amuta.Entities.Validations;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using Unity;

namespace Seldat.Amuta.BL
{
    public class StudentManager
    {
        private static readonly IBaseLogger _logger;
        static StudentManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        #region Managers

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

        static IStudentChildrenDataManager _studentChildrenDataManager;
        static IStudentChildrenDataManager StudentChildrenDataManager
        {
            get
            {
                if (_studentChildrenDataManager == null)
                {
                    _studentChildrenDataManager = DIManager.Container.Resolve<IStudentChildrenDataManager>();
                }
                return _studentChildrenDataManager;
            }
        }

        #endregion

        private static int getNumberNotMarriedChildren(List<StudentChildren> studentChildren)
        {
            if (studentChildren != null)
            {
                string maxChildrenNumber = ConfigurationManager.AppSettings.Get("MaxChildrenNumber");
                if (studentChildren.Count > int.Parse(maxChildrenNumber))
                    throw new Exception($"Children number must be maximum {maxChildrenNumber}");
            }
            else
                return studentChildren.Where(child => child.Status != Status.Married.ToString()).Count();
            return 0;
        }

        public static Students Contains(Student.Includes includes, string str)
        {
            try
            {
                Students students = StudentDataManager.Contains(includes, str);
                return students;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load students.", ex);
                throw;
            }
        }



        private static int getNumberMarriedChildren(List<StudentChildren> studentChildren)
        {
            if (studentChildren != null)
                return studentChildren.Where(child => child.Status == Status.Married.ToString()).Count();
            return 0;
        }

        public static Students GetStudents(Student.Includes includes,int?from,int? amount)
        {
            try
            {
                Students students = StudentDataManager.GetAllStudents(includes,from,amount);
                return students;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load students.", ex);
                throw;
            }
        }

        public static Students GetStudentsOfBranch(int branchId, Student.Includes includes,int? from,int? amount)
        {
            try
            {
                Students students = StudentDataManager.GetStudentsOfBranch(branchId, includes,from,amount);
                return students;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load the students of this branch.", ex);
                throw;
            }
        }
        public static Students GetPendingStudents(Student.Includes includes)
        {
            try
            {
                Students students = StudentDataManager.GetPendingStudents(includes);
                return students;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load pending students.", ex);
                throw;
            }
        }

        public static Student GetStudent(int studentId, Student.Includes includes)
        {
            try
            {
                Student student = StudentDataManager.GetStudent(studentId, includes);
                return student;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load student {studentId}.", ex);
                throw;
            }
        }
        public static Student GetStudentByIdentityNumber(int studentIdentityNumber, Student.Includes includes)
        {
            try
            {
                Student student = StudentDataManager.GetStudentByIdentityNumber(studentIdentityNumber, includes);
                return student;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load student {studentIdentityNumber}.", ex);
                throw;
            }
        }
        public static decimal GetPayment(int studentId)
        {
            try
            {
                decimal payment = StudentDataManager.GetPayment(studentId);
                return payment;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to calculate student's payment,studentId: {studentId}.", ex);
                throw;
            }
        }

        public static int InsertPendingStudent(Student student, int branchId, int? studyPathId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (StudentDataManager.IsExistIdentityNumber(student.IdentityNumber, student.Id))
                        throw new Exception("The identity number is already exist.");
                    
                    student.Address.Id = AddressManager.InsertAddress(student.Address);
                    student.Bank.Id = BankManager.InsertBank(student.Bank);
                    //student.ChildrenNumber = getNumberNotMarriedChildren(student.StudentChildren);
                    //student.MarriedChildrenNumber = getNumberMarriedChildren(student.StudentChildren);
                    int insert = student.Id = StudentDataManager.InsertPendingStudent(student);
                    if (student.StudentChildren != null)
                    {
                        foreach (StudentChildren child in student.StudentChildren)
                        {
                            if (!ValidateModel.IsValid(new List<object>() { child }))
                                throw new Exception("not valid child field/s");
                            //i had this line
                            child.Student = student;
                            child.Student.Id = student.Id;
                            child.Id = StudentChildrenDataManager.InsertStudentChildren(child);
                        }
                    }
                    //BranchStudentManager.RequestRregistration(student.Id, branchId, studyPathId);
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to insert pending student.", ex);
                throw;
            }
        }

        public static int UpdateStudent(Student student)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //if (StudentDataManager.IsExistIdentityNumber(student.IdentityNumber, student.Id))
                    //    throw new Exception("The identity number is already exist.");
                    AddressManager.UpdateAddress(student.Address);
                    BankManager.UpdateBank(student.Bank);
                    student.ChildrenNumber = getNumberNotMarriedChildren(student.StudentChildren);
                    student.MarriedChildrenNumber = getNumberMarriedChildren(student.StudentChildren);
                    int update = StudentDataManager.UpdateStudent(student);
                    if (student.StudentChildren != null)
                        foreach (StudentChildren child in student.StudentChildren)
                        {
                            if (!ValidateModel.IsValid(new List<object>() { child }))
                                throw new Exception("not valid child field/s");

                            //if (child.Id > 0)
                            //    update = StudentChildrenDataManager.UpdateStudentChildren(child);
                            //else
                            //{
                            //    child.Student.Id = student.Id;
                            //    child.Id = StudentChildrenDataManager.InsertStudentChildren(child);
                            //}
                        }
                    scope.Complete();
                    return update;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to update student {student.Id}.", ex);
                throw;
            }
        }

        public static int SetStudentInactive(int studentId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //TODO- not in that sprint:
                    //all the requests,attendance... become Inactive
                    BranchStudentManager.SetBranchOfStudentInactive(studentId);
                    int update = StudentDataManager.SetStudentInactive(studentId);
                    scope.Complete();
                    return update;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to set the student {studentId} to inactive.", ex);
                throw;
            }
        }
        public static int InsertStudentPayment(StudentPayment studentPayment)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //todo check if not appear scolarship in that month

                    int insert = studentPayment.Id = StudentDataManager.InsertStudentPayment(studentPayment);
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to insert payment of student.", ex);
                throw;
            }
        }
        public static int SetStudentActive(int studentId, int branchId)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    //TODO- not in that sprint:
                    //all the requests,attendance... branchs become active?
                    int update = StudentDataManager.SetStudentActive(studentId);
                    if (update == 1)
                    {
                        BranchStudentManager.RegistrationStudentToBranch(studentId, branchId);
                        BranchManager.IncreaseNumberOfStudents(branchId);
                    }
                    scope.Complete();
                    return update;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to set the student {studentId} to active.", ex);
                throw;
            }
        }

        public static int ApprovalRegistration(BranchStudent branchStudent)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int update = BranchStudentManager.ApprovalRegistrationStudent(branchStudent.Id);
                    StudentDataManager.SetStudentActive(branchStudent.Student.Id);
                    if (update == 1)
                        BranchManager.IncreaseNumberOfStudents(branchStudent.Branch.Id);
                    scope.Complete();
                    return update;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to set the student {branchStudent.Student.Id} to active in branch {branchStudent.Branch.Id}.", ex);
                throw;
            }
        }
    }
}
