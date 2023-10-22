using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;

namespace ChatApp.Common.DTO.Chat
{
    public class ChatPreviewDto
    {
        public UserPreviewDto Interlocutor { get; set; } = null!;

        public LastMessagePreviewDto LastMessage { get; set; } = null!;
    }
}
