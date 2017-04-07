using AdamOneilSoftware;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestUploadAsync();
            //TestAsyncDownload();
            var b = new BlobUri("adamosoftware", "install", "whatevs2.xml");
            Console.WriteLine($"Exists = {b.Exists()}");
            Console.WriteLine($"ExistsAsync = {b.ExistsAsync()}");
            

            Console.ReadLine();
        }

        private async static void TestUploadAsync()
        {
            var test = new Thing() { FirstName = "Oingo", LastName = "Boingo", Date = DateTime.Today };

            await AzureXmlSerializerHelper.UploadAsync(test,
                new BlobUri("adamosoftware", "install", "whatevs2.xml"), 
                "CnwT4Y9GiATbmKvVgJk0y0s8plhddOugoHM5ZUm6tskN+gq2g2xEWpYSamdgcRhby12SOuDHN9/vshAHK5VsGw==");
        }

        private async static void TestAsyncDownload()
        {
            var test = await AzureXmlSerializerHelper.DownloadAsync<Thing>(
                new BlobUri("adamosoftware", "install", "whatevs.xml")/*,
                new StorageCredentials("adamosoftware", "CnwT4Y9GiATbmKvVgJk0y0s8plhddOugoHM5ZUm6tskN+gq2g2xEWpYSamdgcRhby12SOuDHN9/vshAHK5VsGw==")*/);

            Console.WriteLine($"FirstName = {test.FirstName}");
            Console.WriteLine($"LastName = {test.LastName}");
            Console.WriteLine($"Date = {test.Date}");            
        }
    }

    public class Thing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
}
