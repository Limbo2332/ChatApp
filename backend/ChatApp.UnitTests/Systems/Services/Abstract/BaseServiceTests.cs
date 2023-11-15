using AutoMapper;
using ChatApp.BLL.MappingProfiles;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.Common.Logic.Abstract;
using Microsoft.Extensions.Configuration;

namespace ChatApp.UnitTests.Systems.Services.Abstract
{
    public abstract class BaseServiceTests
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IUserIdGetter> _userIdGetterMock;
        protected readonly Mock<IConfiguration> _configMock;
        protected readonly string _signingKey = "testForSigningKey";

        protected BaseServiceTests()
        {
            _userIdGetterMock = new Mock<IUserIdGetter>();
            _configMock = new Mock<IConfiguration>();
            _mapper = SetUpMapper();

            SetUpConfiguration();
        }

        private void SetUpConfiguration()
        {
            _configMock
                .Setup(c => c.GetSection(It.IsAny<string>()).Value)
                .Returns(_signingKey);
        }

        private IMapper SetUpMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConstructServicesUsing(type =>
                {
                    if (type.Name.Contains(nameof(CurrentUserResolver)))
                    {
                        return new CurrentUserResolver(_userIdGetterMock.Object);
                    }

                    if (type.Name.Contains(nameof(MessagePreviewResolver)))
                    {
                        return new MessagePreviewResolver(_userIdGetterMock.Object);
                    }

                    return new ImagePathResolver(_configMock.Object);
                });
                mc.AddProfile<UserProfile>();
                mc.AddProfile<ChatsProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
