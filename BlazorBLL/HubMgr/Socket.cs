using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBLL.Managers;
using BlazorDAL.Models;
using BlazorDAL;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Blazor.Core.Src;

namespace BlazorBLL.HubMgr
{
    public class Socket : Hub
    {
        private readonly Manager mgr;
        readonly System.Timers.Timer TMR_CYCREAD = new();
        private int _readCycle = 1; // in minutes
        CounterList counterList = new CounterList();
        public Socket(Manager mgr)
        {
            this.mgr = mgr;
        }
        public override async Task OnConnectedAsync()
        {
            WsClients.WsClientsList.Add(new WsClient { ConnectionId=Context.ConnectionId, UserName=Context.User.Identity.Name, Page=Context.GetHttpContext().Request.Query["pagename"] });
        
            var context = Context.GetHttpContext();
            var pageName = context.Request.Query["pagename"];
            if (pageName.ToString() =="/home")
                await SendTrkAsync("","");//await StartAsync("", "User Connected");
            if (pageName.ToString() =="/global")
                await SendMessageAsync("", "User Connected");
            await base.OnConnectedAsync();
        }
        /*public Task StartAsync(string user,string message)
        {
            var args = new event_alarm
            {
                log_description = "Trk Başladı",
                dati=DateTime.Now,
                machine_name=Environment.MachineName,
                log_method=MethodBase.GetCurrentMethod().Name,
                user_name=mgr.Identity.Name
            };

            // Convert min to miliseconds and assign it to interval of the timer.
            TMR_CYCREAD.Interval = _readCycle == 0 ? 2 * 1 * 200 : 1 * 1 * 200;
            TMR_CYCREAD.Elapsed += TMR_CYCREAD_Elapsed;
            TMR_CYCREAD.Enabled = true;
            return Task.CompletedTask;
        }*/
        /*private async void TMR_CYCREAD_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                TMR_CYCREAD.Enabled = false;
                await SendTrkAsync("","");
                await SendMessageAsync("", "");
            }
            catch { }
            finally
            { TMR_CYCREAD.Enabled = true; }

        }*/

        public async Task SendMessageAsync(string user, string message)
        {
            var s = mgr.Db.Query<USER_DATA>("SELECT * FROM dbo.user_data where ID = 1").FirstOrDefault();
            await Clients.All.SendAsync("ReceiveMessage", "", s.FIRST_NAME);
        }
        public async Task SendTrkAsync(string user, string message)
        {
            while (true)
            {
                //var s = mgr.Db.Query<line_data>("SELECT * FROM line_data where id = 1").FirstOrDefault();
                counterList.Counter++;
                await Clients.All.SendAsync("Trk", "", counterList);
                await Task.Delay(2000);
            }
            
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var wsClientConnection = WsClients.WsClientsList.FirstOrDefault(x => x.ConnectionId==Context.ConnectionId);
            if(wsClientConnection.Page == "/trk")
                WsClients.WsClientsList.Remove(wsClientConnection);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
