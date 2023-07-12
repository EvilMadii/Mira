using Amazon.S3;
using Amazon.S3.Model;
using api.dal;
using api.models.dbEntities;

namespace api.services;
public class UploadService : IUploadService
{
    private readonly IAmazonS3 _s3;
    private readonly string _bucketName;
    public UploadService(IAmazonS3 s3)
    {
        _s3 = s3;
        _bucketName = new ConfigurationBuilder().AddUserSecrets<UploadService>().Build()["S3-Bucket:Name"];
    }
    public async Task<PutObjectResponse> UploadAsync(Guid uuid, IFormFile file)
    {
        var PutObjectRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = $"profile_images/{uuid}",
            ContentType = file.ContentType,
            InputStream = file.OpenReadStream(),
            Metadata = {
                ["x-amz-meta-originalname"] = file.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(file.FileName),
            }
        };

        return await _s3.PutObjectAsync(PutObjectRequest);
    }
    public async Task<GetObjectResponse> GetImageAsync(Guid uuid)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = $"profile_images/{uuid}"
        };
        return await _s3.GetObjectAsync(getObjectRequest);
    }

    public async Task<DeleteObjectResponse> DeleteImageAsync(Guid uuid)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = _bucketName,
            Key = $"profile_images/{uuid}"
        };
        return await _s3.DeleteObjectAsync(deleteObjectRequest);
    }

    public Task<PutObjectResponse> OverwriteImageAsync(Guid uuid, IFormFile file)
    {
        throw new NotImplementedException();
    }
}

