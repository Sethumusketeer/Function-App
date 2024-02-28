using System;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionTrigger
{
    public class QueueFunction
    {
        [FunctionName("QueueFunction")]
        public void Run([QueueTrigger("printsamplemessage", Connection = "ConstString")] string myQueueItem,
            [Blob("sampleblob/{queueTrigger}", FileAccess.Read, Connection = "ConstString")] Stream stream,
            [Queue("outputqueue", Connection = "ConstString")] out string output, ILogger log)
        {
            StreamReader sr = new StreamReader(stream);
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem} \n Size: {stream.Length} \n Content: {sr.ReadToEnd()}");
            output = myQueueItem;
        }

        //[FunctionName("BlodQueFunction")]
        //public void Run([QueueTrigger("printsamplemessage", Connection = "ConstString")] string myQueueItem,
        //    [Blob("sampleblob/textfile.txt", FileAccess.Write, Connection = "ConstString")] Stream writestream, ILogger log)
        //{
        //    log.LogInformation($"C# BlobQueue trigger function processed: {myQueueItem}");
        //    writestream.Write(Encoding.ASCII.GetBytes(myQueueItem));
        //}
    }
}
