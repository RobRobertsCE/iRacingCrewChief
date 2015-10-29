using System;
using System.Collections.Generic;
using System.Net;
using iRacing.CrewChief.Models;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Server.Request;
using iRacing.CrewChief.Server.Response;

namespace iRacing.CrewChief.Server.API
{
    class ApiLeaderboardRequestHandler : ApiRequestHandler, IRequestHandler
    {
        public override string ApiEndpoint
        {
            get { return "api/leaderboard"; }
        }

        public ApiLeaderboardRequestHandler()
            : base()
        {
        }

        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefLeaderboardResponse response = new LeaderboardResponse();
            try
            {
                var apiResponse = SendAPIRequest<List<ResultsPositionsModel>>(request);

                response.StatusCode = (int)apiResponse.StatusCode;

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            response.IsSuccess = true;
                            response.Leaderboard = apiResponse.Data;
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
