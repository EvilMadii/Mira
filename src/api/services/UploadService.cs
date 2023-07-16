using api.dal;
using api.models.dbEntities;
using Amazon.S3;
using Amazon.S3.Model;
using api.services;

class UploadService : IUploadService
{
    private readonly IAmazonS3 _s3;
    private readonly RailwayContext _context;
    private readonly IConfiguration _configuration;
    public UploadService(IAmazonS3 s3, IConfiguration configuration)
    {
        _s3 = s3;
        _context = new RailwayContext();
        _configuration = configuration;
    }
    public Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GetObjectResponse> GetImageAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile image)
    {
        string BucketName = _configuration.GetSection("bucket-name").Value!;
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = $"profile_images/{id}",
            ContentType = image.ContentType,
            InputStream = image.OpenReadStream(),
            Metadata = {
                ["x-amz-meta-originalName"] = image.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(image.FileName)
            }
        };
        return await _s3.PutObjectAsync(putObjectRequest);
    }
}
