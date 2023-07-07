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
        public ReturnResult<List<Account>> GetUserList()
        {
            var res = manager.Db.Fetch<Account>();
            return new ReturnResult<List<Account>>
            {
                IsSuccess=1,
                Msg="Kullanıcı Listesi Getirildi",
                result=res
            };
        }
       
    }

}
