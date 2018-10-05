
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("History")]
        public static async Task<IActionResult> History([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {

            string from = string.Empty;
            string to = string.Empty;
            foreach (var key in req.Query.Keys)
            {
                if (key == "from")
                    from = req.Query["from"];

                if (key == "to")
                    from = req.Query["to"];
            }
            log.LogInformation($"From:{ from } to { to }");
            return new OkObjectResult("Done");

            
        }
    }
}