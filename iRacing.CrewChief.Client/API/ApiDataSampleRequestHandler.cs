using System;
using System.Net.Http;
using System.Net.Http.Headers;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Client.Request;
using iRacing.CrewChief.Client.Response;
using iRacing.Models;
using Newtonsoft.Json;

namespace iRacing.CrewChief.Client.API
{
    class ApiDataSampleRequestHandler : ApiRequestHandler, IRequestHandler
    {
        static string responseData = "";

        public override string ApiEndpoint
        {
            get { return "api/datasample"; }
        }

        public ApiDataSampleRequestHandler()
            : base()
        {
        }

        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefDataSampleResponse response = new DataSampleResponse();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponse = client.GetAsync(ApiEndpoint).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    var sample = httpResponse.Content.ReadAsStringAsync().Result;
                    response.StatusCode = (int)httpResponse.StatusCode;
                    response.IsSuccess = true;
                    response.Data = JsonConvert.DeserializeObject<DataSample>(sample);
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
