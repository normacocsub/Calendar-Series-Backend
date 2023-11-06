using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace Infrastructure.ExternalServices;

public class GoogleDriveServices : IGoogleDriveService
{
    private readonly DriveService _service;

    public GoogleDriveServices()
    {
        GoogleCredential credential;
        
        var directory = Directory.GetCurrentDirectory();

        var routCredentials = Path.Combine(directory, "credentials", "credentials.json");

        using (var stream = new FileStream(routCredentials, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(DriveService.Scope.Drive);
        }
        
        _service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Calendar"
        });
    }

    public async Task<string> UploadImage(Stream imageStream, string nameFile, string idFolder)
    {
        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        {
            Name = nameFile,
            Parents = new List<string> { idFolder }
        };

        FilesResource.CreateMediaUpload request = _service.Files.Create(fileMetadata, imageStream, "image/jpeg");
        request.Fields = "id";

        await request.UploadAsync();
        var file = await _service.Files.Get(request.ResponseBody.Id).ExecuteAsync();
        var idFile = file.Id;

        if (!string.IsNullOrEmpty(idFile))
        {
            return idFile;
        }
        else
        {
            throw new Exception($"Error: Fail to upload image in Google Drive.");
        }
    }
}