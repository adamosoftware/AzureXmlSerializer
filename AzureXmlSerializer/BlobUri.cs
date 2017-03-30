using System;

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
    }
}
