using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");

    // parse query parameter
    string type = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "type", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    type = type ?? data?.type;

    int value = 0;
    
    switch(type)
    {
        case "Pilsner":
            value = 1;
            break;
        case "Lager":
            value = 2;
            break;
        case "Porter/Stout":
            value = 3;
            break;
        case "IPA":
            value = 4;
            break;
        case "Trappist/Abbey":
            value = 5;
            break;
        case "Weizen/Wit/Wheat":
            value = 6;
            break;
        case "Bock":
            value = 7;
            break;
        case "Lambic":
            value = 8;
            break;
        default:
            break;
    }
    
    return req.CreateResponse(HttpStatusCode.OK, value);
}