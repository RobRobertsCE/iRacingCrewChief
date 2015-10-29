using System;
using System.Net;
using iRacing.CrewChief.Models;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Server.Request;
using iRacing.CrewChief.Server.Response;
using Newtonsoft.Json;

namespace iRacing.CrewChief.Server.API
{
    class ApiDataSampleJsonRequestHandler : ApiRequestHandler, IRequestHandler
    {
        static string responseData = "";

        public override string ApiEndpoint
        {
            get { return "api/datasamplejson"; }
        }

        public ApiDataSampleJsonRequestHandler()
            : base()
        {
        }

        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefDataSampleResponse response = new DataSampleResponse();
            try
            {

                //var apiResponse = SendAPIRequest<Data>(request);
                var apiResponse = SendAPIRequest(request);

                response.StatusCode = (int)apiResponse.StatusCode;
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            response.IsSuccess = true;
                            var jsonContent = apiResponse.Content;

                            response.Data = JsonConvert.DeserializeObject<DataSampleModel>(jsonContent);
                            
                            // JsonConvert.DeserializeObject<SessionData>(apiResponse.Data);
                            //response.SessionData = new SessionData() { Raw = apiResponse.Content };
                            //response.SessionData = apiResponse.Data;


                            //var sessionInfoString = apiResponse.Content.Replace("\\r\\n", "\\n");
                            //var input = new StringReader(sessionInfoString);
                            //var deserializer = new Deserializer();

                            //var result = (SessionData)deserializer.Deserialize(input, typeof(SessionData));

                            //response.SessionData = result;
                            //var cleaned = apiResponse.Content.TrimEnd('"').Substring(1).Replace("\r\n","").Replace(@"\","");
                            //response.Data = JsonConvert.DeserializeObject<Data>(cleaned);

                            break;
                        }
                    case HttpStatusCode.NoContent:
                        {
                            response.IsSuccess = false;
                            response.ErrorMessage = "iRacing is not running.";
                            break;
                        }
                    default:
                        {
                            response.IsSuccess = false;
                            if (null != apiResponse.ErrorException)
                            {
                                response.ErrorMessage = apiResponse.ErrorException.Message;
                            }
                            else if (null != apiResponse.ErrorMessage)
                            {
                                response.ErrorMessage = apiResponse.ErrorMessage;
                            }
                            else
                            {
                                response.ErrorMessage = String.Format("Server returned {0}\r\n{1}", apiResponse.StatusDescription, apiResponse.Content);
                            }
                            break;
                        }
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
