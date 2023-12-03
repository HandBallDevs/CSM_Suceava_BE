namespace CSU_Suceava_BE.Application.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadImageAsync(string base64Image, string resourceName);
    }
}
