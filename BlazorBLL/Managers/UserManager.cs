using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class UserManager
    {
        Manager manager;
        public UserManager(Manager manager)
        {
            this.manager=manager;
        }
        public ReturnResult<List<USER_DATA>> GetUserList()
        {
            var sql = PetaPoco.Sql.Builder
                .Append("SELECT * from dbo.user_data");
            var res = manager.Db.Fetch<USER_DATA>(sql);
            return new ReturnResult<List<USER_DATA>>
            {
                IsSuccess=1,
                Msg="Kullanıcı Listesi Getirildi",
                result=res
            };
        }
       
    }

}
