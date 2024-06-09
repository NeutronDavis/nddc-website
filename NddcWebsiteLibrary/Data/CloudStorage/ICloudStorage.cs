using Microsoft.AspNetCore.Http;
using NddcWebsiteLibrary.Model.CloudStorage;

namespace NddcWebsiteLibrary.Data.CloudStorage
{
    public interface ICloudStorage
    {
        Task<MyBlobResponseModel> DeleteAsync(string fileName);
        Task<MyBlobModel> DownloadAsync(string blobFilename);
        Task<List<MyBlobModel>> ListAsync();
        Task<MyBlobResponseModel> UploadAndResizeImageAsync(IFormFile imageFile, int newWidth, int newHeight, string fileName);
        Task<MyBlobResponseModel> UploadAsync(IFormFile file, string fileName);
    }
}