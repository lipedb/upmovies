using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UpMovies.Configuration;
using UpMovies.Models;
using UpMovies.Models.Adapters;

namespace UpMovies.Helpers
{
    public class MoveListItemHelper
    {
        public static List<MovieListItem> GetMovieListItems(List<Movie> results)
        {
            List<MovieListItem> movieLists = new List<MovieListItem>();
            foreach (Movie item in results)
            {
                MovieListItem listItem = new MovieListItem
                {
                    Id = item.Id,
                    Title = item.Title,
                    ReleaseDate = GetDateFormatted(item.ReleaseDate),
                    Genre = GetGenreListNames(item.GenreIds),
                    ImageURL = GetImageURL(item.PosterPath)
                };
                movieLists.Add(listItem);
            }
            return movieLists;
        }

        public static string GetDateFormatted(DateTimeOffset date)
        {
            string specifier = "D";
            return date.ToString(specifier);
        }

        public static string GetGenreListNames(List<object> GenreIds)
        {
            ApplicationConfig application = new ApplicationConfig();
            string storedGenreList = application.GenreList;
            if(!String.IsNullOrEmpty(storedGenreList))
            {
                List<string> GenreListNames = new List<string>();
                GenreList genreList = JsonConvert.DeserializeObject<GenreList>(storedGenreList);
                List<GenreItemElement> genreItems = genreList.Genres;
                foreach (object instance in GenreIds)
                {
                    foreach (GenreItemElement genreItem in genreItems)
                    {
                        if(Convert.ToInt32(instance) == genreItem.Id)
                            GenreListNames.Add(genreItem.Name);
                    }
                }
                string result = string.Join(" | ", GenreListNames);
                return result;
            }
            else
            {
                return String.Empty;
            }
        }

        public static string GetImageURL(string endpoint)
        {
            string baseURL = "https://image.tmdb.org/t/p/original";
            return baseURL + endpoint;
        }
    }
}
