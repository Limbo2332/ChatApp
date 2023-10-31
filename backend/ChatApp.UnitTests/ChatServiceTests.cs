using ChatApp.BLL.Hubs;
using ChatApp.BLL.Hubs.Clients;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;
using ChatApp.Common.Exceptions;
using ChatApp.UnitTests.Abstract;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.UnitTests
{
    public class ChatServiceTests : BaseServiceTests
    {
        private readonly IChatService _sut;
        private readonly Mock<IHubContext<ChatHub, IChatHubClient>> _hubContextMock = new Mock<IHubContext<ChatHub, IChatHubClient>>();
        private readonly Mock<IBlobStorageService> _blobStorageServiceMock = new Mock<IBlobStorageService>();
        private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();

        public ChatServiceTests()
        {
            var userService = new UserService(_context, _mapper, _userIdGetterMock.Object, _blobStorageServiceMock.Object, _emailServiceMock.Object);

            SetUpHubContextMock();

            _sut = new ChatService(_context, _mapper, _userIdGetterMock.Object, _hubContextMock.Object, userService);
        }

        [Fact]
        public async Task GetChatsAsync_ShouldReturnPreviewList_WithoutPageSettings()
        {
            // Arrange
            PageSettingsDto? pageSettings = null;
            var currentUser = _context.Users.First(u => u.Id == _userIdGetterMock.Object.CurrentUserId);

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(result);
                Assert.Equal(2, result.Count);

                Assert.All(result, item => Assert.Equal(0, item.InterlocutorUnreadMessagesCount));
                Assert.All(result, item => Assert.NotEqual(currentUser.UserName, item.Interlocutor.UserName));
                Assert.All(result, item => Assert.True(item.LastMessage.IsMine));
                Assert.All(result, item => Assert.False(item.LastMessage.IsRead));
            });
        }

        [Fact]
        public async Task GetChatsAsync_ShouldReturnPreviewList_WithPageSettingsFiltering()
        {
            // Arrange
            PageSettingsDto pageSettings = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Interlocutor.UserName",
                    PropertyValue = "123"
                },
                Pagination = null
            };

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(result);
                Assert.Single(result);

                Assert.Collection(result, item => Assert.Contains("123", item.Interlocutor.UserName));
            });
        }

        [Fact]
        public async Task GetChatsAsync_ShouldReturnPreviewList_WithPageSettingsPagination()
        {
            // Arrange
            PageSettingsDto pageSettings = new PageSettingsDto()
            {
                Filter = null,
                Pagination = new PagePaginationDto
                {
                    PageNumber = 2,
                    PageSize = 1,
                }
            };

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(result);
                Assert.Single(result);
            });
        }

        [Fact]
        public async Task GetChatsAsync_ShouldReturnPreviewList_WithPageSettingsAndOrdered()
        {
            // Arrange
            PageSettingsDto pageSettings = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Interlocutor.UserName",
                    PropertyValue = "Test"
                },
                Pagination = new PagePaginationDto
                {
                    PageNumber = 1,
                    PageSize = 2,
                }
            };

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(result);

                Assert.True(result.SequenceEqual(result.OrderByDescending(c => c.LastMessage.SentAt)));
            });
        }

        [Fact]
        public async Task GetConversationAsync_ShouldThrowException_WhenNoChat()
        {
            // Arrange
            var chatId = 999;
            PageSettingsDto? pageSettingsDto = null;

            // Act
            var action = async () => await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task GetConversationAsync_ShouldReturnConversation_WithoutPageSettings()
        {
            // Arrange
            var chatId = 1;
            PageSettingsDto? pageSettingsDto = null;
            var currentUser = await _context.Users.FirstAsync(u => u.Id == _userIdGetterMock.Object.CurrentUserId);

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(chatId, result.ChatId);
                Assert.NotEqual(currentUser.UserName, result.Interlocutor.UserName);
                Assert.NotEmpty(result.Messages);
            });
        }

        [Fact]
        public async Task GetConversationAsync_ShouldReturnConversation_WithPageFiltering()
        {
            // Arrange
            var chatId = 1;
            PageSettingsDto pageSettingsDto = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                     PropertyName = "Value",
                     PropertyValue = "No message"
                },
                Pagination = null,
            };

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(chatId, result.ChatId);
                Assert.Empty(result.Messages);
            });
        }

        [Fact]
        public async Task GetConversationAsync_ShouldReturnConversation_WithPagePagination()
        {
            // Arrange
            var chatId = 1;
            PageSettingsDto pageSettingsDto = new PageSettingsDto()
            {
                Filter = null,
                Pagination = new PagePaginationDto
                {
                    PageNumber = 2,
                    PageSize = 2,
                }
            };

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(chatId, result.ChatId);
                Assert.Single(result.Messages);
            });
        }

        [Fact]
        public async Task GetConversationAsync_ShouldReturnConversation_WithPageSettings()
        {
            // Arrange
            var chatId = 1;
            PageSettingsDto pageSettingsDto = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Value",
                    PropertyValue = "Hello"
                },
                Pagination = new PagePaginationDto
                {
                    PageNumber = 1,
                    PageSize = 2,
                }
            };

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.Equal(chatId, result.ChatId);
                Assert.Equal(2, result.Messages.Count());
            });
        }

        [Fact]
        public async Task AddMessageAsync_ShouldAddNewMessage()
        {
            // Arrange
            var newMessage = new NewMessageDto
            {
                ChatId = 1,
                Value = "NewMessage"
            };

            // Act
            var result = await _sut.AddMessageAsync(newMessage);

            // Arrange
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(newMessage.ChatId, result.ChatId);
                Assert.Equal(newMessage.Value, result.Value);
            });
        }

        [Fact]
        public async Task AddNewChatWithAsync_ShouldThrowException_WhenChatIsAlreadyCreated()
        {
            // Arrange
            var newChat = new NewChatDto
            {
                NewMessage = "Hello!",
                UserName = "TestUserName1"
            };

            // Act
            var action = async () => await _sut.AddNewChatWithAsync(newChat);

            // Assert
            await Assert.ThrowsAsync<BadRequestException>(action);
        }

        [Fact]
        public async Task AddNewChatWithAsync_ShouldReturnNewChat()
        {
            // Arrange
            var newChat = new NewChatDto
            {
                NewMessage = "Hello!",
                UserName = "TestUserName1234"
            };

            // Act
            var result = await _sut.AddNewChatWithAsync(newChat);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.Equal(newChat.UserName, result.Interlocutor.UserName);
                Assert.Equal(newChat.NewMessage, result.LastMessage.Value);
            });
        }

        [Fact]
        public async Task ReadMessagesAsync_ShouldThrowException()
        {
            // Arrange
            var chat = new ChatReadDto
            {
                Id = 3,
                UserId = 4
            };

            // Act
            var action = async () => await _sut.ReadMessagesAsync(chat);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(action);
        }

        [Fact]
        public async Task ReadMessagesAsync_ShouldWork()
        {
            // Arrange
            var chat = new ChatReadDto
            {
                Id = 1,
                UserId = 2
            };

            // Act
            await _sut.ReadMessagesAsync(chat);

            // Assert
            var conversation = await _sut.GetConversationAsync(chat.Id, null);
            Assert.All(conversation.Messages, message => Assert.True(message.IsRead));
        }

        private void SetUpHubContextMock()
        {
            var mockClientProxyParticipants = new Mock<IChatHubClient>();
            var mockClients = new Mock<IHubClients<IChatHubClient>>();

            foreach (var user in _context.Users)
            {
                mockClients.Setup(clients => clients.Group(user.Id.ToString()))
                    .Returns(mockClientProxyParticipants.Object);
            }

            _hubContextMock.Setup(hub => hub.Clients)
                .Returns(mockClients.Object);
        }
    }
}
