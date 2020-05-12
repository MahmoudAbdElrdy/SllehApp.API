
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class ChatHub : Hub<ITypedHubClient>
    {
        public void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
        }

    }
   

    }
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string name, string message);
    }
    public class ChatMessage
    {
        public string user { get; set; }

        public string message { get; set; }

        public string room { get; set; }
    }

