using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using UpMovies.Common;
using UpMovies.Extensions;
using UpMovies.Interfaces;
using UpMovies.Models;
using UpMovies.Models.Response;

namespace UpMovies.Services.Remote
{
    public static class RESTServices
    {
        public static async Task<string> RetriveMoviesToServerAsync(string page)
        {
            string response = String.Empty;
            IRemoteServices remoteServices;
            remoteServices = RestService.For<IRemoteServices>(AppConstants.ApiURL);
            UpcomingMoviesRequest upcomingMoviesRequest = new UpcomingMoviesRequest
            {
                Page = page
            };
            try
            {
                response = await remoteServices.UpcomingMovies(upcomingMoviesRequest);
                string parsedResponse = ExtensionMethods.FixApiResponseString(response);
                return parsedResponse;
            }
            catch (Exception ex)
            {
                //var statusCode = ex.StatusCode;
                ErrorResponse errorResponse = new ErrorResponse
                {
                    Message = ex.ToString()
                };
                return errorResponse.Message;
            }
        }
    }
}
