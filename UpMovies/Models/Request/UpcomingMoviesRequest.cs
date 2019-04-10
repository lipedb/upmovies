using Refit;
using UpMovies.Common;

namespace UpMovies.Models
{
    public class UpcomingMoviesRequest : BaseRequest
    {
        [AliasAs("page")]
        public string Page { get; set; }
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
