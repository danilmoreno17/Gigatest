using Kameyo.Core.Application.Common.Dtos.Response;
using Kameyo.Core.Application.Common.Interfaces;
using MediatR;

namespace Kameyo.Core.Application.Modules.UploadImages.Commands
{
    public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, UrlsDto>
    {
        private readonly IFileStorageService _fileStorageService;

        public UploadImagesCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        public async Task<UrlsDto> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var urls = await _fileStorageService.UploadAsync(request.Files, request.BlobContainerName);
            return urls;
        }
    }
}
