﻿using Kameyo.Core.Application.Common.Extensions;

namespace Kameyo.Core.Application.Common.Dtos.Request
{
    public class FileDto
    {
        public Guid UserId { get; set; }
        public Stream Content { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }

        public string? BasePath { get; set; }
        public string? FileName { get; set; }

        public string GetPathWithFileName()
        {
            string uniqueAutoGeneratedFileName = Path.GetRandomFileName();
            string shortClientSideFileNameWithoutExt = Path.GetFileNameWithoutExtension(Name).TruncateLongString(10);  //Trimming to max 10 as client side file name can be too long
            string ext = Path.GetExtension(Name);
            string basePath =  String.IsNullOrEmpty(BasePath)? $"{UserId}/default/": BasePath;

            var pathWithFileName = basePath + uniqueAutoGeneratedFileName + "_" + shortClientSideFileNameWithoutExt + ext;
            if (!string.IsNullOrEmpty(FileName))
            {
                pathWithFileName = basePath + FileName;
            }

            return pathWithFileName;
        }
    }
}
