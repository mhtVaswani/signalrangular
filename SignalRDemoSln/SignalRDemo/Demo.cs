using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace SignalRDemo
{
    public class Demo
    {
        private List<Mod> mods;

        private IHubContext<DemoHub> Hub
        {
            get;
            set;
        }


        public Demo(IHubContext<DemoHub> hub)
        {
            mods = new List<Mod>();
            mods.Add(new Mod { Id = 1, Name = "name" });
            Hub = hub;
        }

        public void SetAllData()
        {
            mods.Add(new Mod { Id = 2, Name = "namenew" });
        }

        public IEnumerable<Mod> GetAllData()
        {
            return mods;
        }


        public void broad()
        {
            Hub.Clients.All.SendAsync("reset");
        }
    }
}
