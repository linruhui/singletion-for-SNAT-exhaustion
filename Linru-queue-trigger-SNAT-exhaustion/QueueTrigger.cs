using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Linru_queue_trigger_SNAT_exhaustion
{
    public static class QueueTrigger
    {
        [FunctionName("QueueTrigger")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "MY_STORAGE_ACCT_APP_SETTING")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Head, new Uri("https://www.google.com"));
                var response = httpClient.SendAsync(request).Result;
            }
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
