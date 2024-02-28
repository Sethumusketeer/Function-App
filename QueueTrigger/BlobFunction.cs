using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionTrigger
{
    public class BlobFunction
    {
        [FunctionName("BlobFunction")]
        public void Run([BlobTrigger("sampleblob/{name}", Connection = "ConstString")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
