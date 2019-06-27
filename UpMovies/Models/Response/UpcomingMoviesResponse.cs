using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UpMovies.Models.Response
{
    public partial class UpcomingMoviesResponse
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("results")]
        public List<Movie> Results { get; set; }

    }

    public partial class UpcomingMoviesResponse
    {
        public static UpcomingMoviesResponse FromJson(string json) => JsonConvert.DeserializeObject<UpcomingMoviesResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this UpcomingMoviesResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
