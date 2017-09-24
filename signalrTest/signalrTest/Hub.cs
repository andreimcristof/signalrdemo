using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Cors;

namespace signalrTest
{
    [EnableCors("MyPolicy")]
    public class Chat: Hub
    {
        public async Task Send(string message)
        {            
            await Clients.All.InvokeAsync("Send", message);
        }
    }
}
