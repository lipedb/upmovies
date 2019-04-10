using System;
using Newtonsoft.Json;
using Prism.Navigation;
using UpMovies.Common;
using UpMovies.Helpers;
using UpMovies.Models;
using UpMovies.Resources.Languages;

namespace UpMovies.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public MovieDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        private string backgroundImage; 
        public string BackgroundImage
        {
            get => this.backgroundImage;
            set => SetProperty(ref this.backgroundImage, value);
        }

        private string date;
        public string Date
        {
            get => this.date;
            set => SetProperty(ref this.date, value);
        }

        private string popularity;
        public string Popularity
        {
            get => this.popularity;
            set => SetProperty(ref this.popularity, value);
        }

        private string description;
        public string Description
        {
            get => this.description;
            set => SetProperty(ref this.description, value);
        }

        private string genres;
        public string Genres
        {
            get => this.genres;
            set => SetProperty(ref this.genres, value);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            string receivedJsonObject = parameters.GetValue<string>(key: AppConstants.ObjectDetail);
            Movie receivedItem = JsonConvert.DeserializeObject<Movie>(receivedJsonObject);
            SetElementsOnScreen(receivedItem);
        }

        public void SetElementsOnScreen(Movie receivedItem)
        {
            if(String.IsNullOrEmpty(receivedItem.BackdropPath))
            {
                BackgroundImage = MoveListItemHelper.GetImageURL(receivedItem.PosterPath);
            }
            else
            {
                BackgroundImage = MoveListItemHelper.GetImageURL(receivedItem.BackdropPath);
            }
            Title = receivedItem.Title;
            Date = MoveListItemHelper.GetDateFormatted(receivedItem.ReleaseDate);
            Popularity = "Popularity: " + (receivedItem.Popularity).ToString() + "%";
            string description = receivedItem.Overview;
            if (String.IsNullOrEmpty(description))
            {
                Description = AppResources.Sinopsis + AppResources.NoInformation;
            }
            else
            {
                Description = AppResources.Sinopsis + description; 
            }
            string genreList = MoveListItemHelper.GetGenreListNames(receivedItem.GenreIds);
            if (String.IsNullOrEmpty(genreList))
            {
                Genres = AppResources.Genres + AppResources.NoInformation;
            }
            else
            {
                Genres = AppResources.Genres + genreList;
            }
        }
    }
}
