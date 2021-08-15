using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace BookShop.Reporting
{
    public static class ExportInventory
    {
        [FunctionName("ExportInventory")]
        public static async Task<ExportResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            
            HttpRequest req, ILogger log)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            return new ExportResult("inventory.xlsx", "ZHNhZnNhIGZzYWRmZyBkc2ZzYWQgZ2ZzYWcgZmFzZ2Y=");
        }
    }

    public class ExportResult
    {
        public string FileName { get; }
        public string DataB64 { get; }
        
        public ExportResult(string fileName, string data)
        {
            FileName = fileName;
            DataB64 = data;
        }
    }
}