using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionTrigger
{
    public class ServiceBusFunction
    {
        [FunctionName("ServiceBusFunction")]
        public void Run([ServiceBusTrigger("thequeue", Connection = "SBConnection")]string myQueueItem,
            [Blob("sampleblob/{sys.randguid}", FileAccess.Write, Connection = "ConstString")] Stream stream, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            StreamWriter sr = new StreamWriter(stream);
            sr.Write(myQueueItem);
            sr.Flush();
        }
    }
}
