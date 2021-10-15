using Application.Common.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly BlobContainerClient blobContainerClient;
        private readonly IDateTime dateTimeService;

        public AzureBlobService(IDateTime dateTimeService)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=smepmlworkspac9341395123;AccountKey=xdYNKLMSGbvQG9D6jNzwTLUdGQSfQrBEmauefAW3eozTyEE1kdN4GX3fJG0oDxhA70nEe7kUECzaOQSebeO8fA==;EndpointSuffix=core.windows.net";

            blobContainerClient = new BlobContainerClient(connectionString, "smepml");
            this.dateTimeService = dateTimeService;
        }

        public async Task<string> DownloadURI(string directory, string fileName)
        {
            var blobClient = blobContainerClient.GetBlobClient(Path.Combine(directory, fileName));

            if (!await blobClient.ExistsAsync())
                return null;

            return $"{blobClient.Uri.AbsoluteUri}{GenerarSas().Query}";
        }

        public async Task<string> Upload(string directory, string fileName, byte[] file)
        {
            var blobClient = blobContainerClient.GetBlobClient(Path.Combine(directory, fileName));

            await using var ms = new MemoryStream(file, true);
            await blobClient.UploadAsync(ms, true);

            return $"{blobClient.Uri.AbsoluteUri}{GenerarSas().Query}";
        }

        public Uri GenerarSas()
        {
            var sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = blobContainerClient.Name,
                Resource = "c",
                ExpiresOn = dateTimeService.Now.AddYears(1),
            };

            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

            return blobContainerClient.GenerateSasUri(sasBuilder);
        }
    }
}
