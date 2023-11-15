using ChatApp.BLL.Interfaces;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Conversation;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;
using ChatApp.Common.DTO.User;
using ChatApp.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatApp.UnitTests.Systems.Controllers
{
    public class ChatsControllerTests
    {
        private readonly IChatService _chatService;
        private readonly ChatsController _sut;

        public ChatsControllerTests()
        {
            _chatService = Substitute.For<IChatService>();

            _sut = new ChatsController(_chatService);
        }

        [Fact]
        public async Task GetChatsAsync_Should_BeSuccess()
        {
            // Arrange
            var pageSettings = Substitute.For<PageSettingsDto>();
            var chatPreviewList = Substitute.For<List<ChatPreviewDto>>();

            _chatService
                .GetChatsAsync(pageSettings)
                .Returns(chatPreviewList);

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _chatService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(chatPreviewList);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task GetConversationAsync_Should_BeSuccess()
        {
            // Arrange
            var chatId = 999;
            var pageSettings = Substitute.For<PageSettingsDto>();
            var chatConversation = Substitute.For<ChatConversationDto>();

            _chatService
                .GetConversationAsync(chatId, pageSettings)
                .Returns(chatConversation);

            // Act
            var result = await _sut.GetChatConversationAsync(chatId, pageSettings);
            var response = result.Result as OkObjectResult;

            // Assert
            using (new AssertionScope())
            {
                _chatService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(chatConversation);
                response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task AddMessageAsync_Should_BeSuccess()
        {
            // Arrange
            var newMessage = Substitute.For<NewMessageDto>();
            var messagePreview = Substitute.For<MessagePreviewDto>();

            _chatService
                .AddMessageAsync(newMessage)
                .Returns(messagePreview);

            // Act
            var result = await _sut.AddMessageAsync(newMessage);
            var response = result.Result as CreatedResult;

            // Assert
            using (new AssertionScope())
            {
                _chatService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(messagePreview);
                response.StatusCode.Should().Be((int)HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task AddChatAsync_Should_BeSuccess()
        {
            // Arrange
            var newChat = Substitute.For<NewChatDto>();
            var chatPreview = Substitute.For<ChatPreviewDto>();

            _chatService
                .AddNewChatWithAsync(newChat)
                .Returns(chatPreview);

            // Act
            var result = await _sut.AddChatAsync(newChat);
            var response = result.Result as CreatedResult;

            // Assert
            using (new AssertionScope())
            {
                _chatService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.Value.Should().Be(chatPreview);
                response.StatusCode.Should().Be((int)HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task ReadMessagesAsync_Should_BeSuccess()
        {
            // Arrange
            var chatRead = Substitute.For<ChatReadDto>();

            _chatService
                .ReadMessagesAsync(chatRead)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _sut.ReadMessagesAsync(chatRead);
            var response = result as OkResult;

            // Assert
            using (new AssertionScope())
            {
                _chatService.ReceivedCalls().Count().Should().Be(1);

                response.Should().NotBeNull();
                response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
            }
        }
    }
}
