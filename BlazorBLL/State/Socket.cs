using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBLL.Managers;
using BlazorDAL.Models;

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
            var context = Context.GetHttpContext();
            var pageName = context.Request.Query["pagename"];
            if (pageName.ToString() =="/home")
                await SendMessageAsync("", "User Connected");
            await base.OnConnectedAsync();
        }

        public async Task SendMessageAsync(string user, string message)
        {
            var res = mgr.Db.Fetch<EvtAlmDto>("SELECT * FROM event_alarm");
            while (true)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, res);
                await Task.Delay(2000);
            }
        }
    }
}
