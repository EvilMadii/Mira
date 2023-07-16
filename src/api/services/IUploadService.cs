using Amazon.S3.Model;

namespace api.services;

public interface IUploadService
{
    Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile image);
    Task<GetObjectResponse> GetImageAsync(Guid id);
    Task<DeleteObjectResponse> DeleteImageAsync(Guid id);
}