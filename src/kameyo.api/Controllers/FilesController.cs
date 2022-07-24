using Kameyo.Core.Application.Common.Dtos.Request;
using Kameyo.Core.Application.Modules.UploadImages.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Kameyo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ApiControllerBase
    {
        [HttpPost("Images/profiles/users/{userId}")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> files, Guid userId)
        {
            var uploadImagesCommand = new UploadImagesCommand() { BlobContainerName = "user-pictures" };

            foreach (var formFile in files)
            {
                var file = new FileDto
                {
                    Content = formFile.OpenReadStream(),
                    Name = formFile.FileName,
                    ContentType = formFile.ContentType,
                    UserId = userId,
                    BasePath = $"{userId}/profile/",
                    FileName = $"{userId}{Path.GetExtension( formFile.FileName)}",
                };
                uploadImagesCommand.Files.Add(file);
            }

            var response = await Mediator.Send(uploadImagesCommand);

            return Ok(response);
        }
    }
}
