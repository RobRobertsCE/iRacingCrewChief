using iRacing.CrewChief.Request;
using RestSharp;

namespace iRacing.CrewChief.Client.API
{
    abstract class ApiRequestHandler 
    {
        protected const string ApiBaseUrl = "http://localhost:49427/";

        public abstract string ApiEndpoint { get; }
        public virtual RestSharp.Method ApiMethod { get { return Method.GET; } }

        protected ApiRequestHandler()
        {
        }

        protected virtual IRestResponse<T> SendAPIRequest<T>(ICrewChiefRequest request) 
            where T : new()
        {
            var client = new RestClient(ApiBaseUrl);
            client.Timeout = 10000;
            var apiRequest = new RestRequest(ApiEndpoint, ApiMethod);

            var responseObj =  client.Execute<T>(apiRequest);

            return responseObj;
        }
        protected virtual IRestResponse SendAPIRequest(ICrewChiefRequest request)
        {
            var client = new RestClient(ApiBaseUrl);
            var apiRequest = new RestRequest(ApiEndpoint, ApiMethod);

            var responseObj = client.Execute(apiRequest);

            return responseObj;
        }

        protected virtual IRestResponse SendAPICommand<T>(ICrewChiefRequest request) 
        {
            var client = new RestClient(ApiBaseUrl);
            var apiRequest = new RestRequest(ApiEndpoint, ApiMethod);
            return client.Execute(apiRequest);
        }
    }
}
