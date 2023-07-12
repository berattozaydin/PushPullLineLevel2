using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.HubMgr
{
    public static class WsClients
    {
        public static List<WsClient> WsClientsList { get; set; } = new List<WsClient>();
    }
    public class WsClient
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string Page { get; set; }
    }
}
