using Seldat.Amuta.Dal.MySqlManagers;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace Seldat.Amuta.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            NLogLogger.NLogLogger mylogger = new NLogLogger.NLogLogger();
            DIManager.Container.RegisterInstance<IBaseLogger>(mylogger);
            DIManager.Container.RegisterType<IAddressDataManager, MySqlAddressDataManager>();
            DIManager.Container.RegisterType<ICountryDataManager, MySqlCountryDataManager>();
            DIManager.Container.RegisterType<ICityDataManager, MySqlCityDataManager>();
            DIManager.Container.RegisterType<IStreetDataManager, MySqlStreetDataManager>();
            DIManager.Container.RegisterType<IStudentDataManager, MySqlStudentDataManager>();
            DIManager.Container.RegisterType<IBankDataManager, MySqlBankDataManager>();
            DIManager.Container.RegisterType<IStudentChildrenDataManager, MySqlStudentChildrenDataManager>();
            DIManager.Container.RegisterType<IBranchStudentDataManager, MySqlBranchStudentDataManager>();
            DIManager.Container.RegisterType<IBranchStudentDataManager, MySqlBranchStudentDataManager>();
            DIManager.Container.RegisterType<IBranchActivityHoursDataManager, MySqlBranchActivityHoursDataManager>();
            DIManager.Container.RegisterType<IBranchDataManager, MySqlBranchDataManager>();
            DIManager.Container.RegisterType<IBranchRulesDataManager, MySqlBranchRulesDataManager>();
            DIManager.Container.RegisterType<IBranchStaffDataManager, IBranchStaffDataManager>();
            DIManager.Container.RegisterType<IBranchStudentDataManager, MySqlBranchStudentDataManager>();
            DIManager.Container.RegisterType<IStudentChildrenDataManager, MySqlStudentChildrenDataManager>();
            DIManager.Container.RegisterType<IStudentDataManager, MySqlStudentDataManager>();
            DIManager.Container.RegisterType<IUserExtraDetailsDataManager, MySqlUserExtraDetailsDataManager>();
            DIManager.Container.RegisterType<IBranchDataManager>();
            DIManager.Container.RegisterType<IBranchDataManager, MySqlBranchDataManager>();
            DIManager.Container.RegisterType<IBranchExamDataManager, MySqlBranchExamDataManager>();
            DIManager.Container.RegisterType<IScolarshipDataManager, MySqlScolarshipDataManager>();
            DIManager.Container.RegisterType<IBranchTypeDataManager, MySqlBranchTypeDataManager>();
            DIManager.Container.RegisterType<IStudentPaymentDataManager, MySqlStudentPaymentDataManager>();
            DIManager.Container.RegisterType<ILoanDataManager, MySqlLoanDataManager>();
            DIManager.Container.RegisterType<IFinancialSupportDataManager, MySqlFinancialSupportDataManager>();

        }
    }
}
