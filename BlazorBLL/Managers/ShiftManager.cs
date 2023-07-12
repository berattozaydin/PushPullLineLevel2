using BlazorBLL.HubMgr;
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
        public ReturnResult<USER_DATA> GetShift()
        {
           /* var foreman = mgr.Db.Query<line_data>().FirstOrDefault();*/
            var userForeman = mgr.Db.Query<USER_DATA>("SELECT * FROM dbo.user_data WHERE user_name = @0","adminIT").FirstOrDefault();

            /*if(userForeman == null)
                return new ReturnResult<Account> { IsSuccess=0,Msg="Aktif formen bilgisi yok."};*/
            return new ReturnResult<USER_DATA> {IsSuccess=1,Msg="Aktif formen bilgisi getirildi.", result=userForeman };
        }
        public ReturnResult SetShiftForeman(USER_DATA accountDto)
        {
            var res = mgr.Db.Query<USER_DATA>("Select * From dbo.user_data where id = @0", accountDto.ID).FirstOrDefault();
            if (res == null)
                return new ReturnResult { IsSuccess=0, Msg="Kullanıcı Bulunamadı." };
            /*Sql sql = new($"UPDATE line_data set active_foreman = @0 WHERE id=1",res.USER_NAME);*/
            var result = 1;//mgr.Db.Execute(sql);
            if (result>0)
            {
                /*var args = new event_alarm
                {
                    dati=DateTime.Now,
                    log_description="Formen Bilgisi Güncellendi Aktif Formen : " +res.Name,
                    log_method="SetShiftForeman",
                    machine_name=Environment.MachineName,
                    user_name=mgr.Identity.Name,
                    
                };
                mgr.Db.Insert(args);*/
                hubContext.Clients.All.SendAsync("ReceiveMessage", "", res.FIRST_NAME);
                return new ReturnResult
                {
                    IsSuccess=1,
                    Msg="Formen Bilgisi Güncellendi Aktif Formen : " +accountDto.FIRST_NAME
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
