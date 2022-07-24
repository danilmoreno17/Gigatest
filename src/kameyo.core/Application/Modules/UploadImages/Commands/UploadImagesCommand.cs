using Kameyo.Core.Application.Common.Dtos.Request;
using Kameyo.Core.Application.Common.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.UploadImages.Commands
{
    public class UploadImagesCommand : IRequest<UrlsDto>
    {
        public Guid UserId { get; set; }
        public ICollection<FileDto> Files { get; set; } = new List<FileDto>();
        public string BlobContainerName { get; set; }
    }
}
