using ChatApp.Common.DTO.Chat;
using ChatApp.DAL.Entities;

namespace ChatApp.BLL.Hubs.Clients
{
    public interface IChatHubClient
    {
        Task SendNewMessage(Message message);

        Task CreateNewChat(ChatPreviewDto chat);
    }
}
