using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdamOneilSoftware
{
    public static class AzureXmlSerializer
	{
        public static T Download<T>(BlobUri blobUri, StorageCredentials credentials = null)
        {
            return Download<T>(blobUri.ToString(), credentials);
        }

        public static T Download<T>(string uri, StorageCredentials credentials = null)
        {
            CloudBlockBlob blob = new CloudBlockBlob(new Uri(uri), credentials);
            T result = default(T);
            using (var stream = new MemoryStream())
            {
                blob.DownloadToStream(stream);
                XmlSerializer xs = new XmlSerializer(typeof(T));
                stream.Seek(0, SeekOrigin.Begin);
                result = (T)xs.Deserialize(stream);
            }
            return result;
        }

        public async static Task DownloadAsync<T>(string uri, StorageCredentials credentials = null)
        {
            await Task.Run(() => Download<T>(uri, credentials));
        }

        public async static Task DownloadAsync<T>(BlobUri blobUri, StorageCredentials credentials = null)
        {
            await Task.Run(() => Download<T>(blobUri, credentials));
        }

        public static void Upload<T>(T @object, BlobUri blobUri, StorageCredentials credentials = null)
        {
            Upload<T>(@object, blobUri.ToString(), credentials);
        }

        public static void Upload<T>(T @object, string uri, StorageCredentials credentials = null)
        {
            // thanks to http://stackoverflow.com/questions/11033739/how-do-i-serialize-a-net-object-into-azure-blob-storage-without-using-a-tempora
            using (var stream = new MemoryStream())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(stream, @object);
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(uri), credentials);
                stream.Seek(0, SeekOrigin.Begin);
                blob.UploadFromStream(stream);
            }
        }

        public async static Task UploadAsync<T>(T @object, string uri, StorageCredentials credentials = null)
        {
            await Task.Run(() => Upload(@object, uri, credentials));
        }

        public async static Task UploadAsync<T>(T @object, BlobUri blobUri, StorageCredentials credentials = null)
        {
            await Task.Run(() => Upload(@object, blobUri.ToString(), credentials));
        }
    }
}
