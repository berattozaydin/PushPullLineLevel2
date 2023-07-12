using BlazorBLL.HubMgr;
using BlazorDAL.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class AdminManager
    {
        IHubContext<Socket> hubContext;
        Manager mgr;
        public AdminManager(Manager mgr,IHubContext<Socket> hubContext)
        {
                this.hubContext = hubContext;
                this.mgr = mgr;
        }
        public ReturnResult SendRefresh()
        {
         

            return new ReturnResult { IsSuccess=1,Msg="Sayfa yenileme isteği gönderildi." };
        }
    }
}
