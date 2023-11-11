using AutoMapper;
using ChatApp.BLL.Interfaces.Auth;
using ChatApp.BLL.MappingProfiles.Resolvers;
using ChatApp.BLL.MappingProfiles;
using ChatApp.BLL.Services.Auth;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using ChatApp.UnitTests.TestData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.DAL.Entities;
using ChatApp.Common.DTO.Message;

namespace ChatApp.UnitTests.Systems.Services.Abstract
{
    public abstract class BaseServiceTests
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IUserIdGetter> _userIdGetterMock = new Mock<IUserIdGetter>();
        protected readonly Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        protected readonly string _signingKeyConfigName = "JWT:SigningKey";
        protected readonly string _blobAccessPathConfigName = "BlobStorage:AccessPath";

        public BaseServiceTests()
        {
            SetUpConfiguration();

            _mapper = SetUpMapper();

            _userIdGetterMock.Setup(x => x.CurrentUserId).Returns(1);
        }

        private void SetUpConfiguration()
        {
            var mockIConfigurationSigningKeySection = new Mock<IConfigurationSection>();
            mockIConfigurationSigningKeySection.Setup(x => x.Key).Returns(_signingKeyConfigName);
            mockIConfigurationSigningKeySection.Setup(x => x.Value).Returns("4odPs71hSke+1yr7h66LLg==");

            var mockIConfigurationBlobAccessSection = new Mock<IConfigurationSection>();
            mockIConfigurationBlobAccessSection.Setup(x => x.Key).Returns(_blobAccessPathConfigName);
            mockIConfigurationBlobAccessSection.Setup(x => x.Value).Returns("https://ovchatappstorage.blob.core.windows.net/profileimages");

            _configMock.Setup(x => x.GetSection(_signingKeyConfigName)).Returns(mockIConfigurationSigningKeySection.Object);
            _configMock.Setup(x => x.GetSection(_blobAccessPathConfigName)).Returns(mockIConfigurationBlobAccessSection.Object);
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
