using api.dal;
using api.models.dbEntities;
using Amazon.S3;
using Amazon.S3.Model;
using api.services;
using Microsoft.EntityFrameworkCore;
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
    public async Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
    {
        string BucketName = _getBucketName()!;
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = BucketName,
            Key = $"profile_images/{id}"
        };
        await ChangeImageUrlAsync(id);

        return await _s3.DeleteObjectAsync(deleteObjectRequest);
    }

    public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile image)
    {
        string BucketName = _getBucketName()!;
        string _key = $"profile_images/{id}";
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = _key,
            ContentType = image.ContentType,
            InputStream = image.OpenReadStream(),
            Metadata = {
                ["x-amz-meta-originalName"] = image.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(image.FileName)
            }
        };
        await ChangeImageUrlAsync(id, _key);
        return await _s3.PutObjectAsync(putObjectRequest);

    }
    private string _getBucketName()
    {
        return _configuration.GetSection("bucket-name").Value!;
    }

    public async Task<bool> ChangeImageUrlAsync(Guid id, string key = "default/images.png")
    {
        try
        {
            var _usr = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (_usr is null)
                return false;
            _usr.UserProfileImageUrl = $"https://d32w0gx4lhskfg.cloudfront.net/{key}";
            _context.Entry(_usr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
        {
            return false;
        }
    }
}
