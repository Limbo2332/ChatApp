using ChatApp.BLL.Hubs.Clients;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.BLL.Hubs
{
    public class ChatHub : Hub<IChatHubClient>
    {
        public async Task OnConnectionAsync(string currentUserId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, currentUserId);
        }
    }
}
