using Microsoft.AspNetCore.Http;

namespace Demo.BusinessLogic.Services.AttatchementService;

public interface IAttatchementService
{
    public string Upload(IFormFile file, string path);
    bool Delete(string path);
}
