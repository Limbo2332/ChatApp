using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;

namespace ChatApp.BLL.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatPreviewDto>> GetChatsAsync();

        Task<ChatConversationDto> GetConversationAsync(int chatId);
    }
}
