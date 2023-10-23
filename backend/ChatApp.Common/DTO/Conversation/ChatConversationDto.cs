using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;

namespace ChatApp.Common.DTO.Conversation
{
    public class ChatConversationDto
    {
        public int ChatId { get; set; }

        public UserPreviewDto Interlocutor { get; set; } = null!;

        public IEnumerable<MessagePreviewDto> Messages { get; set; } = null!;
    }
}
