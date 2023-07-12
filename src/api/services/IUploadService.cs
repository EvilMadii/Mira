using Amazon.S3.Model;
namespace api.services;
public interface IUploadService
{
    public Task<PutObjectResponse> UploadAsync(Guid uuid, IFormFile file);
    public Task<GetObjectResponse> GetImageAsync(Guid uuid);
    public Task<DeleteObjectResponse> DeleteImageAsync(Guid uuid);
    public Task<PutObjectResponse> OverwriteImageAsync(Guid uuid, IFormFile file);
}