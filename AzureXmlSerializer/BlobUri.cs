using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace AdamOneilSoftware
{
    public class BlobUri
    {
        public string StorageAccountName { get; set; }
        public string ContainerName { get; set; }
        public string Path { get; set; }

        public BlobUri()
        {
        }

        public BlobUri(string storageAccountName, string containerName, string path)
        {
            StorageAccountName = storageAccountName;
            ContainerName = containerName;
            Path = path;
        }

        public Uri ToUri()
        {
            return new Uri(ToString());
        }

        public override string ToString()
        {
            return $"https://{StorageAccountName}.blob.core.windows.net:443/{ContainerName}/{Path}";
        }

        public bool Exists(StorageCredentials credentials = null)
        {
            CloudBlob blob = new CloudBlob(ToUri(), credentials);
            return blob.Exists();
        }

        public bool Exists(string key)
        {
            CloudBlob blob = new CloudBlob(ToUri(), new StorageCredentials(StorageAccountName, key));
            return blob.Exists();
        }

        public async Task<bool> ExistsAsync(StorageCredentials credentials = null)
        {
            CloudBlob blob = new CloudBlob(ToUri(), credentials);
            return await blob.ExistsAsync();
        }

        public async Task<bool> ExistsAsync(string key)
        {
            CloudBlob blob = new CloudBlob(ToUri(), new StorageCredentials(StorageAccountName, key));
            return await blob.ExistsAsync();
        }
    }
}
