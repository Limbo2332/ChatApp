using System.Text;
using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

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
        public async Task<ActionResult<List<ChatPreviewDto>>> GetChatsAsync([FromQuery] PageSettingsDto? pageSettings)
        {
            return Ok(await _chatService.GetChatsAsync(pageSettings));
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<ChatConversationDto>> GetChatConversationAsync(int chatId,
            [FromQuery] PageSettingsDto? pageSettings)
        {
            return Ok(await _chatService.GetConversationAsync(chatId, pageSettings));
        }

        [HttpPost("message")]
        public async Task<ActionResult<MessagePreviewDto>> AddMessageAsync(NewMessageDto newMessage)
        {
            var messagePreview = await _chatService.AddMessageAsync(newMessage);

            await PublishToRabbitMQ(newMessage);

            return Created("message", messagePreview);
        }

        [HttpPost]
        public async Task<ActionResult<ChatPreviewDto>> AddChatAsync(NewChatDto newChat)
        {
            var chatPreview = await _chatService.AddNewChatWithAsync(newChat);

            return Created("chat", chatPreview);
        }

        [HttpPatch("messages")]
        public async Task<ActionResult> ReadMessagesAsync(ChatReadDto chat)
        {
            await _chatService.ReadMessagesAsync(chat);

            return Ok();
        }

        private async Task PublishToRabbitMQ(NewMessageDto newMessage)
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq", UserName = "user", Password = "password" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "message_events", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var message = JsonConvert.SerializeObject(newMessage);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(exchange: "", routingKey: "message_events", body: body);
        }
    }
}
