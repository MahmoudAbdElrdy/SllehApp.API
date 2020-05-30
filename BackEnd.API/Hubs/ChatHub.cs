
using BackEnd.Service.IServices;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
       
        private readonly IServicesChat _ChatServices;

        public ChatHub(IServicesChat servicesChat)
        {
            _ChatServices = servicesChat;
        }
        public async Task SendMessage(ChatVM message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

    }



    public interface ITypedHubClient
    {
        Task BroadcastMessage(ChatVM chatVM);
    }
}

