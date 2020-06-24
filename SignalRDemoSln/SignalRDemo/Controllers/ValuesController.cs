using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace SignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        List<Mod> lst = new List<Mod>() { new Mod { Id = 1, Name = "name 1" } };

        private readonly IHubContext<DemoHub> _hubContext;

        public ValuesController(IHubContext<DemoHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("test")]
        [HttpPost]
        public async Task<IActionResult> prop(Mod mod)
        {
            lst.Add(mod);   

            await _hubContext.Clients.All.SendAsync("SignalMessageReceived",  mod);

            return StatusCode(200, "res");

        }
    }
}
