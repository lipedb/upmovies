using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Prism.Navigation;
using UpMovies.Common;
using UpMovies.Configuration;
using UpMovies.Enum;
using UpMovies.Helpers;
using UpMovies.Interfaces;
using UpMovies.Models;
using UpMovies.Models.Adapters;
using UpMovies.Models.Response;
using UpMovies.Services.Remote;
using Xamarin.Forms;

namespace UpMovies.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        UpcomingMoviesResponse upcomingMovies;

        public ICommand MenuItemSelectedCommand => new AsyncCommand<MovieListItem>(MoveDetailsAsync);

        public AsyncCommand LoadCommand { get; private set; }

        private int MaxPages = 200;

        private List<Movie> ListItemsOnPage { get; set; }

        private ObservableCollection<MovieListItem> _movieLists;
        public ObservableCollection<MovieListItem> MovieLists
        {
            get => _movieLists;
            set => _movieLists = value;
        }

        private MovieListItem _currentMovieListItem;
        public MovieListItem CurrenMovieListItem
        {
            get => _currentMovieListItem;
            set => _currentMovieListItem = value;
        }

        private int _currentPageIndex = 1;
        public int CurrentPageIndex
        {
            get => _currentPageIndex;
            set => _currentPageIndex = value;
        }

        private void RetriveMovies()
        {

            if (IsInternetConnected)
            {
                Task.Run(async () =>
                {
                    await GetGenresRoutineAsync();
                    await GetMoviesRoutineAsync(CurrentPageIndex.ToString());
                });
            }
            else
            {
                ShowOfflineAlert();
            }
        }

        private async Task MoveDetailsAsync(MovieListItem movieItem)
        {
            string jsonObject = String.Empty;
            foreach(Movie item in ListItemsOnPage)
            {
                if(item.Id == movieItem.Id)
                    jsonObject = JsonConvert.SerializeObject(item);
            }

            var navParameters = new NavigationParameters
            {
                { AppConstants.ObjectDetail, jsonObject},
            };
            NavigationService.NavigateAsync(NavigateTo.MovieDetail, navParameters);

        }

        private async Task LoadMoreItems()
        {
            if (MaxPages >= CurrentPageIndex++)
            {
                await Task.Delay(1000);
                await GetMoviesRoutineAsync(CurrentPageIndex.ToString());
            }
        }

        public override void OnInternetAvailable()
        {
            base.OnInternetAvailable();
            RetriveMovies();
        }

        async Task GetMoviesRoutineAsync(string page)
        {
            CurrentPageIndex++;
            if (MaxPages >= CurrentPageIndex++)
            {
                var getMoviesAsyc = await RESTServices.RetriveMoviesToServerAsync(page);
                string response = getMoviesAsyc;
                upcomingMovies = new UpcomingMoviesResponse();
                try
                {
                    upcomingMovies = UpcomingMoviesResponse.FromJson(response);
                    UpdateElementsOnList(upcomingMovies.Results);
                }
                catch (Exception ex)
                {
                    ErrorResponse errorResponse = new ErrorResponse
                    {
                        Message = ex.ToString()
                    };
                }
            }
        }

        void UpdateElementsOnList(List<Movie> results)
        {
            List<MovieListItem> listItems = MoveListItemHelper.GetMovieListItems(results);
            foreach (MovieListItem elem in listItems)
            {
                MovieLists.Add(elem);
            }
            foreach (Movie itemReceived in results)
            {
                ListItemsOnPage.Add(itemReceived);
            }
        }

        async Task GetGenresRoutineAsync()
        {
            var getGenresAsyc = await RESTServices.RetriveGenresFromServerAsync();
            string response = getGenresAsyc;
            ApplicationConfig application = new ApplicationConfig
            {
                GenreList = response
            };
        }

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            upcomingMovies = new UpcomingMoviesResponse();
            RetriveMovies();
            MovieLists = new ObservableCollection<MovieListItem>();
            ListItemsOnPage = new List<Movie>();
            LoadCommand = new AsyncCommand(LoadMoreItems, CanExecuteSubmit);
        }

    }
}
