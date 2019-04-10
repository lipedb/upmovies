using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpMovies.Models;
using UpMovies.Models.Response;

namespace UpMovies.Interfaces
{
    [Headers("User-Agent: :request:")]
    public interface IRemoteServices
    {
        [Get("/3/discover/movie")]
        Task<string> UpcomingMovies(UpcomingMoviesRequest upcomingMoviesRequest);
    }
}
