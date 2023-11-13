using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;

namespace ChatApp.BLL.Hubs.Clients
{
    public interface IChatHubClient
    {
        Task SendNewMessageAsync(MessagePreviewDto message);

        Task CreateNewChatAsync(ChatPreviewDto chat);

        Task ReadMessagesAsync(ChatReadDto chatRead);
    }
}
