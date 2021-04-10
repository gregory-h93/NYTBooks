using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Amazon.Lambda.Core;
using System.Dynamic;
using Newtonsoft.Json;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Assignment9Books
{
    public class Function
    {
        public static readonly HttpClient client = new HttpClient();
        public async Task<ExpandoObject> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            //Returns a string
            string bookString = await client.GetStringAsync("https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=bAvrr98zTj8axTADUG5E9klSaGW9XBdz");
            
            //Convert string to object
            dynamic bookObject = JsonConvert.DeserializeObject<ExpandoObject>(bookString);
            
            //Return object
            return bookObject;
        }
    }
}
