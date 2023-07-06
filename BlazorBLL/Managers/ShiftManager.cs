using BlazorDAL;
using BlazorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class ShiftManager
    {
        Manager mgr;
        public ShiftManager(Manager mgr)
        {
            this.mgr=mgr;
        }
        public ReturnResult<Account> GetShift()
        {
            var foreman = mgr.Db.Query<line_data>().FirstOrDefault();
            var userForeman = mgr.Db.Query<Account>("WHERE \"Username\" = @0",foreman.active_foreman).FirstOrDefault();

            if(userForeman == null)
                return new ReturnResult<Account> { IsSuccess=0,Msg="Aktif formen bilgisi yok."};
            return new ReturnResult<Account> {IsSuccess=1,Msg="Aktif formen bilgisi getirildi.", result=userForeman };
        }
    }
}
