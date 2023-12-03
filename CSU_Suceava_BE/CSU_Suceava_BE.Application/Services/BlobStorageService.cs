using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSU_Suceava_BE.Application.Interfaces;

namespace CSU_Suceava_BE.Application.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadImageAsync(string base64Image, string resourceName)
        {
            var bytes = Convert.FromBase64String(base64Image);
            var fileContent = new MemoryStream(bytes);

            var blobContainer = blobServiceClient
                .GetBlobContainerClient(Environment.GetEnvironmentVariable("BLOB_CONTAINER_NAME"));

            var blobHttpHeaders = new BlobHttpHeaders { ContentType = "image/png" };
            var blobName = $"{resourceName}{Guid.NewGuid()}.png";
            var blobClient = blobContainer.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileContent, blobHttpHeaders);

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
