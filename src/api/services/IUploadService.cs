using Amazon.S3.Model;
public interface IUploadService
{
    public Task<PutObjectResponse> UploadAsync(Guid uuid, IFormFile file);
}