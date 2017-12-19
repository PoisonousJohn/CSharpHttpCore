using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;

namespace HttpTriggerCore
{
    public class HttpTrigger
    {
        public static IActionResult Run(HttpRequest req, TraceWriter log)
        {
            var client = new SqlCommand();
            log.Info("C# HTTP trigger function processed a request.");

            if (req.Query.TryGetValue("name", out StringValues value)) {
                return new OkObjectResult($"Hello, {value.First()}");
            }

            return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
