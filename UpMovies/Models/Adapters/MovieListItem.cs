using System;
namespace UpMovies.Models.Adapters
{
    public class MovieListItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
    }
}
