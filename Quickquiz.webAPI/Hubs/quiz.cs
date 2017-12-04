using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Quickquiz.webAPI.Hubs
{
    public class quiz : Hub
    {
        public void GetRealTime()
        {
            Clients.Caller.setRealTime(DateTime.Now.ToString("h:mm:ss tt"));
        }
    }
}