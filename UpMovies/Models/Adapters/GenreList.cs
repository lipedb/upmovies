using System;
namespace UpMovies.Models.Adapters
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public class GenreList
    {
        [JsonProperty("genres")]
        public List<GenreItemElement> Genres { get; set; }
    }
}
