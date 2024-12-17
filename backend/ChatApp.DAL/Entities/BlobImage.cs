namespace ChatApp.DAL.Entities;

public class BlobImage
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public byte[] Data { get; set; } = Array.Empty<byte>();
    
    public string ContentType { get; set; } = string.Empty;
}