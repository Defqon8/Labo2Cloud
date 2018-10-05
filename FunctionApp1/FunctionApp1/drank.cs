
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
    public static class Drank
    {
        [FunctionName("drank")]
        public static async Task<IActionResult> run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "legal")]HttpRequest req, ILogger log)
        {

            log.LogInformation("c# http trigger");
            string json = await new StreamReader(req.Body).ReadToEndAsync();

            Drinks data = JsonConvert.DeserializeObject<Drinks>(json);
            if (data.Age < 0 || data.Age > 100)
                return new BadRequestResult();

            data.Result = true;
            if ((data.Age < 18) && (data.Drink == "wine" || data.Drink == "gin" || data.Drink == "beer"))
                data.Result = false;

            return new OkObjectResult(data);
        }
        
        public class Drinks
        {
            public string Drink { get; set; }
            public int Age { get; set; }
            public bool Result { get; set; }
        }
    }
}