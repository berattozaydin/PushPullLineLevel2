using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBLL.Managers;
using BlazorDAL.Models;
using BlazorDAL;

namespace BlazorBLL.State
{
    public class Socket : Hub
    {
        private readonly Manager mgr;
        public Socket(Manager mgr)
        {
            this.mgr = mgr;
        }
        public override async Task OnConnectedAsync()
        {
            WsClients.WsClientsList.Add(new WsClient { ConnectionId=Context.ConnectionId, UserName=Context.User.Identity.Name, Page=Context.GetHttpContext().Request.Query["pagename"] });
        
            /*var context = Context.GetHttpContext();
            var pageName = context.Request.Query["pagename"];
            if (pageName.ToString() =="/home")
                await SendMessageAsync("", "User Connected");
            if (pageName.ToString() =="/global")
                await SendMessageAsync("", "User Connected");*/
            await base.OnConnectedAsync();
            await SendMessageAsync("","");
        }
  

        public async Task SendMessageAsync(string user, string message)
        {
            var s = mgr.Db.Query<line_data>("SELECT * FROM line_data where id = 1").FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", "", s.active_foreman);
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
