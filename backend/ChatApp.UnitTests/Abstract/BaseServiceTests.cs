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

namespace ChatApp.UnitTests.Abstract
{
    public abstract class BaseServiceTests
    {
        protected readonly ChatAppContext _context;
        protected readonly IMapper _mapper;
        protected readonly Mock<IUserIdGetter> _userIdGetter = new Mock<IUserIdGetter>();
        protected readonly Mock<IConfiguration> _config = new Mock<IConfiguration>();
        protected readonly string _signingKeyConfigName = "JWT:SigningKey";
        protected readonly string _blobAccessPathConfigName = "BlobStorage:AccessPath";

        public BaseServiceTests()
        {
            var options = new DbContextOptionsBuilder<ChatAppContext>()
                .UseInMemoryDatabase(databaseName: $"{nameof(AuthServiceTests)}_FakeDatabase")
                .Options;

            SetUpConfiguration();

            _context = new ChatAppContext(options);
            PopulateContext();

            _mapper = SetUpMapper();

            _userIdGetter.Setup(x => x.CurrentUserId).Returns(1);
        }

        private void SetUpConfiguration()
        {
            var mockIConfigurationSigningKeySection = new Mock<IConfigurationSection>();
            mockIConfigurationSigningKeySection.Setup(x => x.Key).Returns(_signingKeyConfigName);
            mockIConfigurationSigningKeySection.Setup(x => x.Value).Returns("4odPs71hSke+1yr7h66LLg==");

            var mockIConfigurationBlobAccessSection = new Mock<IConfigurationSection>();
            mockIConfigurationBlobAccessSection.Setup(x => x.Key).Returns(_blobAccessPathConfigName);
            mockIConfigurationBlobAccessSection.Setup(x => x.Value).Returns("https://ovchatappstorage.blob.core.windows.net/profileimages");

            _config.Setup(x => x.GetSection(_signingKeyConfigName)).Returns(mockIConfigurationSigningKeySection.Object);
            _config.Setup(x => x.GetSection(_blobAccessPathConfigName)).Returns(mockIConfigurationBlobAccessSection.Object);
        }

        private void PopulateContext()
        {
            _context.Users.AddRange(AuthServiceTestData.GetUsers());
            _context.RefreshTokens.AddRange(AuthServiceTestData.GetRefreshTokens());
            _context.SaveChanges();
        }

        private IMapper SetUpMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConstructServicesUsing(type => new ImagePathResolver(_config.Object));
                mc.AddProfile<UserProfile>();
                mc.AddProfile<ChatsProfile>();
            });

            var mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
