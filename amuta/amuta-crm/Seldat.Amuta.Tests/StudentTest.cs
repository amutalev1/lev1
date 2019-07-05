using NUnit.Framework;
using Seldat.Amuta.BL;
using Seldat.Amuta.Dal.MySqlManagers;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.NLogLogger;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
namespace Seldat.Amuta.Tests
{
    [TestFixture]
    public class StudentTest
    {
        [SetUp]
        public void Setup()
        {
            DIManager.Container.RegisterType<IStudentDataManager, MySqlStudentDataManager>();
            NLogLogger.NLogLogger mylogger = new NLogLogger.NLogLogger();
            DIManager.Container.RegisterInstance<IBaseLogger>(mylogger);
        }
        [Test]
        public void GetStudents()
        {
           Students students= StudentManager.GetStudents(Student.Includes.None,null,null);
           Assert.AreNotEqual(null, students);
        }
    }
}
