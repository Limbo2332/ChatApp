using ChatApp.BLL.Hubs;
using ChatApp.BLL.Hubs.Clients;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.Common.DTO.Chat;
using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.Page;
using ChatApp.Common.Exceptions;
using ChatApp.DAL.Entities;
using ChatApp.DAL.Repositories.Abstract;
using ChatApp.UnitTests.Systems.Services.Abstract;
using ChatApp.UnitTests.TestData;
using Microsoft.AspNetCore.SignalR;
using System.Linq.Expressions;

namespace ChatApp.UnitTests.Systems.Services
{
    public class ChatServiceTests : BaseServiceTests
    {
        private readonly IChatService _sut;
        private readonly Mock<IHubContext<ChatHub, IChatHubClient>> _hubContextMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IUserChatsRepository> _userChatsRepositoryMock;
        private readonly Mock<IMessageRepository> _messageRepositoryMock;

        public ChatServiceTests()
        {
            _hubContextMock = new Mock<IHubContext<ChatHub, IChatHubClient>>();
            _userServiceMock = new Mock<IUserService>();
            _userChatsRepositoryMock = new Mock<IUserChatsRepository>();
            _messageRepositoryMock = new Mock<IMessageRepository>();

            var chatRepositoryMock = new Mock<IChatRepository>();

            _sut = new ChatService(
                _mapper,
                _userIdGetterMock.Object,
                _hubContextMock.Object,
                _userServiceMock.Object,
                chatRepositoryMock.Object,
                _userChatsRepositoryMock.Object,
                _messageRepositoryMock.Object);

            SetUpHubContextMock();
            SetUserChats();
            SetUserGetter();
        }

        [Fact]
        public async Task GetChatsAsync_Should_ReturnPreviewList_WhenNoPageSettings()
        {
            // Arrange
            var user = DbContextTestData.Users.First();

            // Act
            var result = await _sut.GetChatsAsync(It.IsAny<PageSettingsDto>());

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeEmpty();
                result.Count.Should().Be(2);

                result.Should().BeInDescendingOrder(chat => chat.LastMessage.SentAt);

                result.Should().AllSatisfy(item => item.InterlocutorUnreadMessagesCount.Should().Be(0));
                result.Should().AllSatisfy(item => item.Interlocutor.UserName.Should().NotBe(user.UserName));
                result.Should().AllSatisfy(item => item.LastMessage.IsMine.Should().BeTrue());
                result.Should().AllSatisfy(item => item.LastMessage.IsRead.Should().BeFalse());
            }
        }

        [Fact]
        public async Task GetChatsAsync_Should_ReturnPreviewList_WhenPageSettingsFiltering()
        {
            // Arrange
            var propertyValue = "123";

            var pageSettings = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Interlocutor.UserName",
                    PropertyValue = propertyValue
                },
            };

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeEmpty();
                result.Should().ContainSingle();

                result.Should().AllSatisfy(item => item.Interlocutor.UserName.Contains(propertyValue));
            }
        }

        [Fact]
        public async Task GetChatsAsync_Should_ReturnPreviewList_WhenPageSettingsPagination()
        {
            // Arrange
            var pageSettings = new PageSettingsDto()
            {
                Pagination = new PagePaginationDto
                {
                    PageNumber = 2,
                    PageSize = 1,
                }
            };

            // Act
            var result = await _sut.GetChatsAsync(pageSettings);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeEmpty();
                result.Should().ContainSingle();
            }
        }

        [Fact]
        public async Task GetChatsAsync_Should_ReturnPreviewList_WhenPageSettingsAndOrdered()
        {
            // Arrange
            var propertyValue = "Test";

            var pageSettings = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Interlocutor.UserName",
                    PropertyValue = propertyValue
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
            using (new AssertionScope())
            {
                result.Should().NotBeEmpty();
                result.Should().BeInDescendingOrder(c => c.LastMessage.SentAt);
                result.Should().AllSatisfy(item => item.Interlocutor.UserName.Contains(propertyValue));
            }
        }

        [Fact]
        public async Task GetConversationAsync_Should_ThrowException_WhenNoChat()
        {
            // Arrange
            var exceptionMessage = new NotFoundException(nameof(Chat));

            // Act
            var action = async () => await _sut.GetConversationAsync(
                It.IsAny<int>(), 
                It.IsAny<PageSettingsDto>());

            // Assert
            await action
                .Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(exceptionMessage.Message);
        }

        [Fact]
        public async Task GetConversationAsync_Should_ReturnConversation_WhenNoPageSettings()
        {
            // Arrange
            var currentUser = DbContextTestData.Users
                .First(user => user.Id == _userIdGetterMock.Object.CurrentUserId);

            var chatId = 1;

            // Act
            var result = await _sut.GetConversationAsync(
                chatId, 
                It.IsAny<PageSettingsDto>());

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result.ChatId.Should().Be(chatId);
                result.Interlocutor.UserName.Should().NotBeEquivalentTo(currentUser.UserName);
                result.Messages.Should().NotBeEmpty();
            }
        }

        [Fact]
        public async Task GetConversationAsync_Should_ReturnConversation_WhenPageFiltering()
        {
            // Arrange
            var chatId = 1;
            var pageSettingsDto = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Value",
                    PropertyValue = "No message"
                },
            };

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result.ChatId.Should().Be(chatId);
                result.Messages.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task GetConversationAsync_Should_ReturnConversation_WhenPagePagination()
        {
            // Arrange
            var chatId = 1;
            var pageSettingsDto = new PageSettingsDto()
            {
                Pagination = new PagePaginationDto
                {
                    PageNumber = 2,
                    PageSize = 2,
                }
            };

            // Act
            var result = await _sut.GetConversationAsync(chatId, pageSettingsDto);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result.ChatId.Should().Be(chatId);
                result.Messages.Should().ContainSingle();
            }
        }

        [Fact]
        public async Task GetConversationAsync_Should_ReturnConversation_WhenPageSettings()
        {
            // Arrange
            var chatId = 1;
            var propertyValue = "Hello";
            var pageSettingsDto = new PageSettingsDto()
            {
                Filter = new PageFilteringDto
                {
                    PropertyName = "Value",
                    PropertyValue = propertyValue
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
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.ChatId.Should().Be(chatId);
                result.Messages.Count().Should().Be(2);
                result.Messages.Should().AllSatisfy(m => m.Value.Contains(propertyValue));
            }
        }

        [Fact]
        public async Task AddMessageAsync_Should_AddNewMessage()
        {
            // Arrange
            var newMessage = new NewMessageDto
            {
                ChatId = 1,
                Value = "NewMessage"
            };

            var userChat = DbContextTestData.UserChats.First();

            _userChatsRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<UserChats, bool>>>()))
                .ReturnsAsync(userChat);

            // Act
            var result = await _sut.AddMessageAsync(newMessage);

            // Arrange
            using (new AssertionScope())
            {
                result.Should().NotBeNull();

                result.ChatId.Should().Be(newMessage.ChatId);
                result.Value.Should().BeEquivalentTo(newMessage.Value);
            }
        }

        [Fact]
        public async Task AddNewChatWithAsync_Should_ThrowException_WhenChatIsAlreadyCreated()
        {
            // Arrange
            var newChat = new NewChatDto();
            var user = new User()
            {
                Id = 1
            };

            _userServiceMock
                .Setup(us => us.FindUserByUsernameAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Act
            var action = async () => await _sut.AddNewChatWithAsync(newChat);

            // Assert
            await action
                .Should()
                .ThrowAsync<BadRequestException>()
                .WithMessage("This chat is already created");
        }

        [Fact]
        public async Task AddNewChatWithAsync_Should_ReturnNewChat()
        {
            // Arrange
            var newChat = new NewChatDto
            {
                NewMessage = "Hello!",
                UserName = "TestUserName1234"
            };

            var user = DbContextTestData.Users.First(u => u.UserName == newChat.UserName);

            _userServiceMock
                .Setup(us => us.FindUserByUsernameAsync(newChat.UserName))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.AddNewChatWithAsync(newChat);

            // Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Interlocutor.UserName.Should().BeEquivalentTo(newChat.UserName);
                result.LastMessage.Value.Should().BeEquivalentTo(newChat.NewMessage);
            }
        }

        [Fact]
        public async Task ReadMessagesAsync_Should_ThrowException()
        {
            // Arrange
            var chat = new ChatReadDto();
            var exceptionMessage = new NotFoundException(nameof(UserChats));

            // Act
            var action = async () => await _sut.ReadMessagesAsync(chat);

            // Assert
            await action
                .Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(exceptionMessage.Message);
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

            var userChats = await _userChatsRepositoryMock.Object.GetAllAsync();

            _userChatsRepositoryMock
                .Setup(ur => ur.GetByExpressionAsync(It.IsAny<Expression<Func<UserChats, bool>>>()))
                .ReturnsAsync(userChats.First());

            _messageRepositoryMock
                .Setup(mr => mr.UpdateEveryMessageByExpressionAsync(It.IsAny<Func<Message, object>>(), It.IsAny<object>()))
                .Callback(() =>
                {
                    foreach (var userChat in userChats)
                    {
                        foreach (var message in userChat.Chat.Messages)
                        {
                            message.IsRead = true;
                        }
                    }
                });

            _userChatsRepositoryMock
                .Setup(ur => ur.GetAllAsync())
                .ReturnsAsync(userChats);

            // Act
            await _sut.ReadMessagesAsync(chat);

            // Assert
            var conversation = await _sut.GetConversationAsync(chat.Id, It.IsAny<PageSettingsDto>());

            conversation.Messages.Should().AllSatisfy(message => message.IsRead.Should().BeTrue());
        }

        private void SetUpHubContextMock()
        {
            var mockClientProxyParticipants = new Mock<IChatHubClient>();
            var mockClients = new Mock<IHubClients<IChatHubClient>>();

            foreach (var user in DbContextTestData.Users)
            {
                mockClients.Setup(clients => clients.Group(user.Id.ToString()))
                    .Returns(mockClientProxyParticipants.Object);
            }

            _hubContextMock.Setup(hub => hub.Clients)
                .Returns(mockClients.Object);
        }

        private void SetUserChats()
        {
            var combinedUserChats = DbContextTestData.UserChats
                .Join(
                    DbContextTestData.Users,
                    uc => uc.UserId,
                    u => u.Id,
                    (uc, u) => new { uc, u })
                .Join(
                    DbContextTestData.Chats,
                    combined => combined.uc.ChatId,
                    c => c.Id,
                    (combined, c) => new { combined.uc, combined.u, c })
                .GroupJoin(
                    DbContextTestData.Messages,
                    combined => combined.c.Id,
                    m => m.ChatId,
                    (combined, messages) => new { combined.uc, combined.u, combined.c, messages })
                .ToList();

            combinedUserChats.ForEach(combined =>
            {
                combined.uc.Chat = combined.c;
                combined.uc.Chat.Messages = combined.messages.ToList();
                combined.uc.User = combined.u;
            });

            _userChatsRepositoryMock
                .Setup(ucr => ucr.GetAllAsync())
                .ReturnsAsync(combinedUserChats.Select(combined => combined.uc));
        }

        private void SetUserGetter()
        {
            var user = DbContextTestData.Users.First();

            _userIdGetterMock
                .Setup(u => u.CurrentUserId)
                .Returns(user.Id);
        }
    }
}
