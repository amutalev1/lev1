using System.Collections.Generic;


namespace Seldat.Amuta.Entities.Managers
{
   public  interface IStudentChildrenDataManager
    {
        //List<StudentChildren> GetStudentChildren(int id);
        int InsertStudentChildren(StudentChildren studentChildren);
        int UpdateStudentChildren(StudentChildren studentChildren);
    }
}
