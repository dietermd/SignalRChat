using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Web.Hubs
{
    public class ChatHub : Hub
    {
        public static Dictionary<string, string> UserNamesMap = new();

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SaveUserName(string userName)
        {
            UserNamesMap.Add(Context.ConnectionId, userName);
            await UpdateMembers();
        }

        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        public async Task UpdateMembers()
        {
            var chatMembers = UserNamesMap.Select(x => x.Value).ToArray();
            await Clients.All.SendAsync("UpdateMembers", chatMembers);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserNamesMap.Remove(Context.ConnectionId);
            await UpdateMembers();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
