using System;
using System.IO;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SingletonHttpClientNS;

namespace Linru_queue_trigger_SNAT_exhaustion
{
    public static class Function3
    {
        [FunctionName("BlobTrigger1")]
        public static async void Run([BlobTrigger("samples-workitems/{name}", Connection = "MY_STORAGE_ACCT_APP_SETTING")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function 1 Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            //var httpClient = new HttpClient();
            var httpClient1 = HttpHelper.SharedHttpClient;
            
            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("http://www.google.com"));
            var response = await httpClient1.SendAsync(request);

            var request1 = new HttpRequestMessage(HttpMethod.Get, new Uri("http://www.google.com"));
            var response1 = await httpClient1.SendAsync(request1);


            
        }
    }


}
