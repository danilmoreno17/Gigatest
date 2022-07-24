using Kameyo.Core.Application.Common.Dtos.Request;
using Kameyo.Core.Application.Common.Dtos.Response;

namespace Kameyo.Core.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        Task<UrlsDto> UploadAsync(ICollection<FileDto> files, string blobContainerName);
    }
}
