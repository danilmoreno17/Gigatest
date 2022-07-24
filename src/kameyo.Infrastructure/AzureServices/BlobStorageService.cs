using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Kameyo.Core.Application.Common.Dtos.Request;
using Kameyo.Core.Application.Common.Dtos.Response;
using Kameyo.Core.Application.Common.Interfaces;

namespace Kameyo.Infrastructure.AzureServices
{
    public class BlobStorageService : IFileStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<UrlsDto> UploadAsync(ICollection<FileDto> files, string blobContainerName)
        {
            if (files == null || files.Count == 0)
            {
                return null;
            }

            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);

            var urls = new List<string>();

            foreach (var file in files)
            {
                var blobClient = containerClient.GetBlobClient(file.GetPathWithFileName());

                await blobClient.UploadAsync(file.Content, new BlobHttpHeaders { ContentType = file.ContentType });

                urls.Add(blobClient.Uri.ToString());
            }

            return new UrlsDto(urls);
        }
    }
}
