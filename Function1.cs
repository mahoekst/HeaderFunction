using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace HeaderFunction
{
    public static class Function1
    {
        [FunctionName("EchoHeaders")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
 
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var counter = 0;

            string returnHeaderstring = "";
            foreach (var header in req.Headers)
            {
                returnHeaderstring += "<H3><span style='color:blue'>" + header.Key + "</span>:<span>" + header.Value + "</span></H3>";
                counter++;
            }

            var strOut = "<H1 style = 'color:#7FFF00;background:black;width:50%'> ***" + counter + " Request Headers Found * ** </H1>" + returnHeaderstring;


            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(strOut);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;

        }
    }
}
