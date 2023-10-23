using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;

namespace ChatApp.BLL.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatPreviewDto>> GetChatsAsync();

        Task<ChatConversationDto> GetConversationAsync(int chatId);

        Task<MessagePreviewDto> AddMessageAsync(NewMessageDto newMessage);
    }
}
