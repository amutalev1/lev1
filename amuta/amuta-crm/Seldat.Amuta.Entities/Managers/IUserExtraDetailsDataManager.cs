using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Amuta.Entities.Managers
{
    public interface IUserExtraDetailsDataManager
    {
        int InsertUserExtraDetails(UserExtraDetails userExtraDetails);
        int UpdateUserExtraDetails(UserExtraDetails userExtraDetails);
        int DeleteUserExtraDetails(string Id);
        UserExtraDetails GetUserDetails(string Id);
    }
}
