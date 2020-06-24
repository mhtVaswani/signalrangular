using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public class DemoHub : Hub
    {
        private List<Mod> modList;

        private readonly IHubContext<DemoHub> _hubContext;

        public DemoHub(IHubContext<DemoHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void GetData(string connectionId)
        {
            Clients.Client(connectionId).SendAsync("messageData", "message " + connectionId);
            //Clients.All.SendAsync("messageData", "message " + connectionId);
        }



        public string GetConnectionId()
        {
            return Context.ConnectionId; 
        }

    }
}
