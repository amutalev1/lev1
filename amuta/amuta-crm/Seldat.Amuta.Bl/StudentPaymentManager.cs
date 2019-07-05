using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Seldat.Amuta.Bl
{
    public class StudentPaymentManager
    {
        private static readonly IBaseLogger _logger;
        static StudentPaymentManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        static IStudentPaymentDataManager _studentPaymentDataManager;
        public static IStudentPaymentDataManager StudentPaymentDataManager
        {
            get
            {
                if (_studentPaymentDataManager == null)
                {
                    _studentPaymentDataManager = DIManager.Container.Resolve<IStudentPaymentDataManager>();
                }
                return _studentPaymentDataManager;
            }
        }

        public static StudentPayments GetPayments(int? from, int? amount)
        {
            try
            {
                StudentPayments payments = StudentPaymentDataManager.GetAllPayments(from, amount);
                return payments;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to load payments.", ex);
                throw;
            }
        }

    }
}
