# AzureXmlSerializer

I created this because I wanted an easy way to serialize and deserialize objects in XML in Azure blob storage. To use

1. Install nuget package **AoAzureXmlSerializer**.

2. Use static methods of the static AzureXmlSerializerHelper class `Upload`, `Download` or their async counterparts.

The examples below use this sample class:

    public class Thing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
    }

Upload example:

    static void Main(string[] args)
    {
        var test = new Thing() { FirstName = "Whatever", LastName = "Bongo", Date = DateTime.Today };
        
        AzureXmlSerializerHelper.Upload(test,
                new BlobUri("{your account}", "{your container}", "whatevs.xml"),
                new StorageCredentials("{your account}", "{your key}"));
    }
    
Running this will create a blob called *whatevs.xml* in your desired account and container. A download example looks like this:

    static void Main(string[] args)
    {
        var test = AzureXmlSerializerHelper.Download<Thing>(new BlobUri("{your account}", "{your container}", "whatevs.xml"));
    }
    
You can omit the credentials argument if the container doesn't require it. Credentials are typically required for uploads although the `Upload` method marks them as optional to be consistent with the `Download` method.

The `BlobUri` object is a helper class that makes it easier to form blob URIs from the relevant components account name, container, and blob path. You can use an ordinary string also, but I find the BlobUri handy.
