using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportingSpokaneChildren.Data.Blob;
public class BlobStorageService
{
    private BlobServiceClient _ServiceClient { get; set; }
    private BlobContainerClient _ContainerClient { get; set; }
    public BlobStorageService(IOptions<BlobOptions> options)
    {
        _ServiceClient = new BlobServiceClient(
            options.Value.BlobStorageConnectionString);
        _ContainerClient = _ServiceClient.GetBlobContainerClient("files");
    }
    public async Task<string> Upload(Container container, Stream stream, string fileFormat)
    {

        var fileName = $"{container.ToString()}/{Guid.NewGuid().ToString()}.{fileFormat}";
        BlobClient blobClient = _ContainerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(stream);
        return fileName;
    }

    public string GetImageUri(string blobId)
    {
        BlobClient blobClient = _ContainerClient.GetBlobClient(blobId);

        return blobClient.GenerateSasUri(
            BlobSasPermissions.Read,
            DateTimeOffset.UtcNow.AddHours(1)).ToString();
    }

    public enum Container
    {
        Announcements,
        Events
    }
}
