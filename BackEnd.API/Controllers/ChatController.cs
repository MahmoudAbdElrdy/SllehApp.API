using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackEnd.Service.Models;
using Chat.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _ChatHubContext;

        
    //    IHubContext<ChatHub, ITypedHubClient> _chatHubContext;
        //public async Task SendMessage(string messageContent, string chatId, MessageType messageType, string RecieveSearchId)
        //{

        //    var userId = AuthHelper.GetCurrentUserId(Context.User);
        //    var searchId = AuthHelper.GetCurrentUserSearchId(Context.User);
        //    var User = AuthHelper.GetCurrentUserBySearchId(searchId, _userService);
        //    var RecieverUser = AuthHelper.GetCurrentUserBySearchId(RecieveSearchId, _userService);

        //    var chat = _chatService.GetChat(chatId);
        //    string senderSearchId = searchId;
        //    if (chat != null && chat.ChatParticipants != null)
        //    {
        //        if (chat.ChatParticipants.Select(x => x.UserSearchId).Contains(searchId))
        //        {
        //            _chatService.SaveChatMessage(chat.Id, userId, messageContent, messageType, null);
        //            await Clients.Group(chat.Id).SendAsync("ReceiveMessage", senderSearchId, messageContent, chat.Id, messageType, User);
        //            string registration_ids = RecieverUser.DeviceToken;
        //            SendNotificationTofcm sendNotification = new SendNotificationTofcm();
        //            sendNotification.SendNotification(registration_ids, messageContent, User.UserName, senderSearchId);
        //            _chatService.ChangeisLeave(chatId, RecieveSearchId);
        //        }
        //        else
        //            await Clients.Caller.SendAsync("ReceiveMessage", "You Are Not Authorized To Access That Chat");
        //    }
        //    else
        //        await Clients.Caller.SendAsync("ReceiveMessage", "Chat Error, Contact The Admin");
        //}

        //public ResponseDTO SaveChatMessage(string chatId, long userId, string message, MessageType messageType, List<ImageMessage> imageMessages)
        //{
        //    var chat = db.Chats.Where(x => x.Id == chatId).Include(x => x.ChatParticipants).FirstOrDefault();
        //    if (chat != null)
        //    {
        //        var chatMessage = Helper.CreateChatMessageBase64(userId, message, messageType, imageMessages);
        //        if (chat.ChatParticipants != null && chat.ChatParticipants.Select(x => x.UserId).Contains(userId))
        //        {
        //            chatMessage.ChatId = chat.Id;

        //            db.ChatMessages.Add(chatMessage);
        //            db.SaveChanges();
        //            return Helper.CreateResponse("200", "Success", true);
        //        }
        //        else
        //            return Helper.CreateResponse("200", "Fail", false);
        //    }
        //    else
        //        return Helper.CreateResponse("200", "Fail", false);
        //}
            public ChatController(IHubContext<ChatHub> chatHubContext)
        {
         //   _chatHubContext = chatHubContext;
            _ChatHubContext = chatHubContext;
        }

        //// GET: api/values
        //[HttpGet]
        //[Route("GetAll")]
        //public IEnumerable<string> Get()
        //{
        //    _ChatHubContext.Clients.All.BroadcastMessage("test", "test");
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost]
        [Route("SendMessage")]
        public  Task SendMessage(ChatMessage message)
        {
            return _ChatHubContext.Clients.All.SendAsync("ReceiveMessage", message.message);
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