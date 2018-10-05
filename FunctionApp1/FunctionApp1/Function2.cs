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
    public static class Function4
    {
        [FunctionName("Som")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {

            log.LogInformation("c# http trigger");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
         
            Getallen data = JsonConvert.DeserializeObject<Getallen>(requestBody);
            int som = data.Getal1 + data.Getal2;
    
            //return new OkObjectResult(som.ToString());
            Resultaat r = new Resultaat();
            r.Som = data.Getal1 + data.Getal2;
            return new OkObjectResult(r);
        }

        public class Getallen
        {
            public int Getal1 { get; set; }
            public int Getal2 { get; set; }
        }

        public class Resultaat {
            public int Som { get; set; }
        }
        
    }
}