using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
    public interface IAttendanceDataManager
    {
        int InsertAttendance(Attendance attendance);
        List<Attendance> GetAttendances();
        List<Attendance> GetStudentAttendance(int studentId);
        List<Attendance> GetbranchAttendance(int id);
        List<Attendance> GetAttendanceByStatus(int id);
        //List<Attendance> GetAttendanceByDate(DateTime date);
        int UpdateAttendance(Attendance attendance);
        int DeleteAttendance(int id);
    }
}
