using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;

namespace ChatApp.BLL.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatPreviewDto>> GetChatsAsync(PageSettingsDto pageSettings);

        Task<ChatConversationDto> GetConversationAsync(int chatId, PagePaginationDto pageSettings);

        Task<MessagePreviewDto> AddMessageAsync(NewMessageDto newMessage);

        Task<ChatPreviewDto> AddNewChatWithAsync(NewChatDto newChat);

        Task ReadMessagesAsync(ChatReadDto chat);
    }
}
