using Refit;
using UpMovies.Common;

namespace UpMovies.Models
{
    public class BaseRequest
    {
        [AliasAs("language")]
        public string Language { get => AppConstants.ApiLanguage; }
        [AliasAs("api_key")]
        public string ApiKey { get => AppConstants.ApiKey; }
    }
}
