using System;
using System.IO;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SingletonHttpClientNS;

namespace Linru_queue_trigger_SNAT_exhaustion
{
    public static class BlobTrigger3
    {
        [FunctionName("BlobTrigger3")]
        public static async void Run([BlobTrigger("samples-workitems/{name}", Connection = "MY_STORAGE_ACCT_APP_SETTING")]Stream myBlob, string name, ILogger log)
        {
            
            log.LogInformation($"C# Blob trigger function 3 Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            var httpClient1 = HttpHelper.SharedHttpClient;

            var request1 = new HttpRequestMessage(HttpMethod.Options, new Uri("http://www.google.com"));
            var response1 = await httpClient1.SendAsync(request1);

            var request2 = new HttpRequestMessage(HttpMethod.Head, new Uri("http://www.google.com"));
            var response2 = await httpClient1.SendAsync(request2);
        }
            
        
    }
}
