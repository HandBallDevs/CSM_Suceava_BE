using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace CSU_Suceava_BE.Utils.Herlpers
{
    public class BlobStorageHelper
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobStorageHelper(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public  async Task<string> UploadImageAsync(string base64Img, string resourceName)
        {
            var bytes = Convert.FromBase64String(base64Img);
            var fileContent = new MemoryStream(bytes);

            var blobContainer = blobServiceClient
                .GetBlobContainerClient(Environment.GetEnvironmentVariable("BLOB_CONTAINER_NAME"));

            // Upload the image to the blob storage
            var blobHttpHeaders = new BlobHttpHeaders { ContentType = "image/png" };
            var blobName = $"{resourceName}{Guid.NewGuid()}.png";
            var blobClient = blobContainer.GetBlobClient(blobName);

            await blobClient.UploadAsync(fileContent, blobHttpHeaders);

            return $"{blobClient.Uri.AbsoluteUri}/{blobName}";
        }
    }
}