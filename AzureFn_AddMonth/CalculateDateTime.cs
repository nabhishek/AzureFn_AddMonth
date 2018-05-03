using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace AzureFn_AddMonth
{
    public static class CalculateDateTime
    {
        [FunctionName("CalculateDate")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            PostData data = await req.Content.ReadAsAsync<PostData>();
            log.Info("time: " + data.original_dateTime + "\nAddMonths: "+ data.addMonths_value);

            var dateTime = Convert.ToDateTime(data.original_dateTime);
            var addMonths = Convert.ToInt32(data.addMonths_value);
            var newDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day).AddMonths(addMonths).ToString("yyyy-MM-dd");
            log.Info("New Date: " + newDate);
            
            var json = new { newDate = newDate};
            log.Info("json1: " + json);

            return newDate == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a Date and AddMonths value in the request body")
                : req.CreateResponse(HttpStatusCode.OK, json, mediaType:"application/json"); //"application / json");  
        }
    }
}
