using ChatApp.Common.DTO.Chat;

namespace ChatApp.BLL.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatPreviewDto>> GetChatsAsync();
    }
}
