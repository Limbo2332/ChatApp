namespace ChatApp.Common.DTO.User;

public class BlobImageDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public byte[] Data { get; set; } = Array.Empty<byte>();
    
    public string ContentType { get; set; } = string.Empty;
}