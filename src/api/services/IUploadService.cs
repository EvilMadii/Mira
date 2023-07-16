using Amazon.S3.Model;

namespace api.services;

public interface IUploadService
{
    Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile image);
    Task<DeleteObjectResponse> DeleteImageAsync(Guid id);
    Task<bool> ChangeImageUrlAsync(Guid id, string key);
}