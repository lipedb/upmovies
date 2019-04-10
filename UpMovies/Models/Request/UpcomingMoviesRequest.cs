using Refit;
using UpMovies.Common;

namespace UpMovies.Models
{
    public class UpcomingMoviesRequest
    {
        [AliasAs("api_key")]
        public string ApiKey { get => AppConstants.ApiKey;}
        [AliasAs("page")]
        public string Page { get; set; }
        [AliasAs("language")] 
        public string Language { get => AppConstants.ApiLanguage; }
        [AliasAs("sort_by")] 
        public string SortBy { get => AppConstants.ApiSort; }
        [AliasAs("include_adult")]
        public string IncludeAdult { get => AppConstants.ApiAdult; }
        [AliasAs("include_video")]
        public string IncludeVideo { get => AppConstants.ApiVideo; }
        [AliasAs("primary_release_date.gte")]
        public string MinimumDate { get => AppConstants.ApiDate; }
    }
}
