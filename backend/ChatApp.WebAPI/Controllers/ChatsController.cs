using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChatPreviewDto>>> GetChatsAsync()
        {
            return Ok(await _chatService.GetChatsAsync());
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<ChatConversationDto>> GetChatConversationAsync(int chatId)
        {
            return Ok(await _chatService.GetConversationAsync(chatId));
        }

        [HttpPost("message")]
        public async Task<ActionResult<MessagePreviewDto>> AddMessageAsync(NewMessageDto newMessage)
        {
            var messagePreview = await _chatService.AddMessageAsync(newMessage);

            return Created("message", messagePreview);
        }

        [HttpPost]
        public async Task<ActionResult<ChatPreviewDto>> AddChatAsync(NewChatDto newChat)
        {
            var chatPreview = await _chatService.AddNewChatWithAsync(newChat);

            return Created("chat", chatPreview);
        }
    }
}
