using Azure.Storage.Blobs;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.UnitTests.Systems.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace ChatApp.UnitTests.Systems.Services
{
    public class BlobStorageServiceTests : BaseServiceTests
    {
        private readonly IBlobStorageService _sut;
        private readonly BlobClient _blobClient;
        private readonly BlobContainerClient _blobContainerClient;

        public BlobStorageServiceTests()
        {
            _blobClient = Substitute.For<BlobClient>();
            _blobContainerClient = Substitute.For<BlobContainerClient>();

            SetupBlobContainerClient();

            _sut = new BlobStorageService(_mapper, _userIdGetterMock.Object, _blobContainerClient);   
        }

        [Fact]
        public async Task UploadNewFileAsync_Should_ReturnGeneratedPath()
        {
            // Arrange
            var fileName = "fileName";

            var formFile = Substitute.For<IFormFile>();
            formFile.FileName.Returns(fileName);

            // Act
            var result = await _sut.UploadNewFileAsync(formFile);

            // Assert
            result.Should().Contain(fileName);
            _blobContainerClient
                .GetBlobClient(fileName)
                .ReceivedCalls()
                .Count()
                .Should()
                .Be(1);
        }

        [Fact]
        public void GetFullAvatarPath_Should_ReturnFullAvatarPath()
        {
            // Arrange
            var uniqueName = "fileName";
            var fullPath = $"https://example.com/{uniqueName}";

            _blobClient.Uri.Returns(new Uri(fullPath));

            // Act
            var result = _sut.GetFullAvatarPath(uniqueName);
            
            // Assert
            result.Should().BeEquivalentTo(fullPath);
        }

        [Fact]
        public async Task DeleteProfileAvatarAsync_Should_ReturnCompletedTask()
        {
            // Arrange
            var fileName = "fileName";

            // Act
            await _sut.DeleteProfileAvatarAsync(fileName);

            // Assert
            _blobContainerClient
                .GetBlobClient(fileName)
                .ReceivedCalls()
                .Count()
                .Should()
                .Be(1);
        }

        private void SetupBlobContainerClient()
        {
            _blobContainerClient
                .GetBlobClient(Arg.Any<string>())
                .Returns(_blobClient);
        }
    }
}
