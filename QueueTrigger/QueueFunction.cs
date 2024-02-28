using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionTrigger
{
    public class QueueFunction
    {
        [FunctionName("QueueFunction")]
        public void Run([QueueTrigger("printsamplemessage", Connection = "ConstString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
