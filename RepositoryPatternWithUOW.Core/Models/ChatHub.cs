using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RepositoryPatternWithUOW.Core.Interfaces;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class ChatHub : Hub<IChatHub>
    {
        public override async Task OnConnectedAsync()
        {

            await Clients
                .Client(Context.ConnectionId)
                .RecieveNotification($"Welcome to the chat room {Context.User?.Identity?.Name}");

            await base.OnConnectedAsync();
        }
    }
}
