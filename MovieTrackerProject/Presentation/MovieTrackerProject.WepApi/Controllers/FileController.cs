using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Domain.Entities;

namespace MovieTrackerProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        readonly IAmazonS3 _amazonS3;
        private readonly IRepository<User> _repository;


        public FileController(IAmazonS3 amazonS3, IRepository<User> repository)
        {
            _amazonS3 = amazonS3;
            _repository = repository;
        }

        [HttpPost("Upload-Profile-Photo")]
        public async Task<IActionResult> UploadProfilePhotoAsync(int userId, IFormFile file)
        {
            string bucketName = "movietrackerapiuserprofilephotos";
            bool bucketExists = await _amazonS3.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists)
                return NotFound($"Bucket {bucketName} does not exist.");

            
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                return NotFound($"User with ID {userId} not found.");

          
            if (!string.IsNullOrEmpty(user.ProfilePhotoUrl))
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = user.ProfilePhotoUrl
                };
                await _amazonS3.DeleteObjectAsync(deleteRequest);
            }

            string key = $"users/{userId}/{file.FileName}";

            PutObjectRequest request = new()
            {
                BucketName = bucketName,
                Key = key,
                InputStream = file.OpenReadStream(),
            };
            request.Metadata.Add("Content-Type", file.ContentType);
            await _amazonS3.PutObjectAsync(request);
            user.ProfilePhotoUrl = key;
            await _repository.UpdateAsync(user);

            var urlRequest = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(15) 
            };

            string preSignedUrl = _amazonS3.GetPreSignedURL(urlRequest);

            return Ok(new { message = "Profile photo updated successfully.", url = preSignedUrl });
        }


        [HttpDelete("Delete-Profile-Photo")]
        public async Task<IActionResult> DeleteProfilePhotoAsync(int userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user == null)
                return NotFound($"User with ID {userId} not found.");

            
            string key = user.ProfilePhotoUrl;
            if (string.IsNullOrEmpty(key))
                return NotFound("No profile photo found for the user.");

            string bucketName = "movietrackerapiuserprofilephotos";

          
            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = key
            };
            await _amazonS3.DeleteObjectAsync(deleteRequest);

          
            user.ProfilePhotoUrl = null;
            await _repository.UpdateAsync(user);

            return Ok(new { message = "Profile photo deleted successfully.", url = (string)null });
        }

    }
}
