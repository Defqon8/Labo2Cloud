
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
    public static class calculator
    {
        [FunctionName("calculator")]
        public static async Task<IActionResult>Calc([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calculator/som/{number1}/{number2}")]HttpRequest req,int number1, int number2, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            //int som = number1 + number2;
            decimal verschil = number1 - number2;
            try
            {
                if (number2 == 0)
                {
                    return new BadRequestResult();
                }
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }

            

            //return new OkObjectResult(som);
            return new OkObjectResult(verschil);


        }
    }
}
