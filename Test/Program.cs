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
            /*var test = new Thing() { FirstName = "Whatever", LastName = "Bongo", Date = DateTime.Today };

            AzureXmlSerializerHelper.Upload(test,
                new BlobUri("adamosoftware", "install", "whatevs.xml"),
                new StorageCredentials("adamosoftware", "CnwT4Y9GiATbmKvVgJk0y0s8plhddOugoHM5ZUm6tskN+gq2g2xEWpYSamdgcRhby12SOuDHN9/vshAHK5VsGw=="));
                */

            var test = AzureXmlSerializerHelper.Download<Thing>(
                new BlobUri("adamosoftware", "install", "whatevs.xml"),
                new StorageCredentials("adamosoftware", "CnwT4Y9GiATbmKvVgJk0y0s8plhddOugoHM5ZUm6tskN+gq2g2xEWpYSamdgcRhby12SOuDHN9/vshAHK5VsGw=="));
        }
    }

    public class Thing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }
}
