using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _ChatHubContext;

        
        IHubContext<ChatHub, ITypedHubClient> _chatHubContext;
        public ChatController(IHubContext<ChatHub, ITypedHubClient> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<string> Get()
        {
            _chatHubContext.Clients.All.BroadcastMessage("test", "test");
            return new string[] { "value1", "value2" };
        }
        // [HttpGet("lengthy")]
        //public async Task<IActionResult> Lengthy()
        //{
        //    await _ChatHubContext
        //        .Clients
        //        .Group(ChatHub.)
        //        .SendAsync("taskStarted");

        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(200);
        //        Debug.WriteLine($"progress={i + 1}");
        //        await _ChatHubContext
        //            .Clients
        //            .Group(ChatHub.GROUP_NAME)
        //            .SendAsync("taskProgressChanged", i + 1);
        //    }

        //    await _ChatHubContext
        //        .Clients
        //        .Group(ChatHub.GROUP_NAME)
        //        .SendAsync("taskEnded");

        //    return Ok();
        //}
    }
}