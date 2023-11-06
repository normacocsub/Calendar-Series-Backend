namespace Infrastructure.ExternalServices;

public interface IGoogleDriveService
{
    Task<string> UploadImage(Stream imageStream, string name, string folderId);
}