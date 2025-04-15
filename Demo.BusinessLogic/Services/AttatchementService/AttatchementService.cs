namespace Demo.BusinessLogic.Services.AttatchementService;
using Microsoft.AspNetCore.Http;


public class AttatchementService : IAttatchementService
{
    List<string> allowedExtensions = new List<string> { ".jpg", ".png", ".pdf" };
    const int MaxFileSize = 2048576; // 2MB
    public string? Upload(IFormFile file, string FolderName)
    {
        //check Extension
        var fileExtension = Path.GetExtension(file.FileName);
        if (!allowedExtensions.Contains(fileExtension)) return null;

        //check Size
        if (file.Length == 0 || file.Length > MaxFileSize) return null;

        //get Located Folder Path  
        var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

        //Make Attachment Name Unique -- Guid
        var FileName = $"{Guid.NewGuid()}_{file.FileName}";

        //Get File Path
        var FilePath = Path.Combine(FolderPath, FileName);

        //Create File Stream To Copy File [Unmanaged]
        using FileStream fs = new FileStream(FilePath, FileMode.Create);

        //Use Stream To Copy File
        file.CopyTo(fs);

        //Return FileName To Store In DB
        return FileName;
    }

    public bool Delete(string filepath)
    {
        if(!File.Exists(filepath)) 
            return false;
        else 
            File.Delete(filepath);
            return true;
    }
}
