using BlazorBLL.State;
using BlazorDAL;
using BlazorDAL.Models;
using Microsoft.AspNetCore.SignalR;
using PetaPoco;
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
        IHubContext<Socket> hubContext;
        
        public ShiftManager(Manager mgr, IHubContext<Socket> hubContext)
        {
            this.mgr=mgr;
            this.hubContext=hubContext;
        }
        public ReturnResult<Account> GetShift()
        {
            var foreman = mgr.Db.Query<line_data>().FirstOrDefault();
            var userForeman = mgr.Db.Query<Account>("WHERE \"Username\" = @0",foreman.active_foreman).FirstOrDefault();

            if(userForeman == null)
                return new ReturnResult<Account> { IsSuccess=0,Msg="Aktif formen bilgisi yok."};
            return new ReturnResult<Account> {IsSuccess=1,Msg="Aktif formen bilgisi getirildi.", result=userForeman };
        }
        public ReturnResult SetShiftForeman(Account accountDto)
        {
            var res = mgr.Db.Query<Account>("Select * From \"Account\" where \"Id\" = @0", accountDto.Id).FirstOrDefault();
            if (res == null)
                return new ReturnResult { IsSuccess=0, Msg="Kullanıcı Bulunamadı." };
            Sql sql = new($"UPDATE line_data set active_foreman = @0 WHERE id=1",res.Username);
            var result = mgr.Db.Execute(sql);
            if (result>0)
            {
                var args = new event_alarm
                {
                    dati=DateTime.Now,
                    log_description="Formen Bilgisi Güncellendi Aktif Formen : " +res.Name,
                    log_method="SetShiftForeman",
                    machine_name=Environment.MachineName,
                    user_name=mgr.Identity.Name,
                    
                };
                mgr.Db.Insert(args);
                hubContext.Clients.All.SendAsync("ReceiveMessage", "", res.Name);
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg="Formen Bilgisi Güncellendi Aktif Formen : " +accountDto.Name
                };
            }
            else
            {
                return new ReturnResult
                {
                    IsSuccess=0,
                    Msg="Formen Güncellenemedi"
                };
            }
        }
    }
}
