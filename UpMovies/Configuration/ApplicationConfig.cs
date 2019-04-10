using System;
using UpMovies.Common;
using Xamarin.Essentials;

namespace UpMovies.Configuration
{
    public class ApplicationConfig
    {
        //Project Name
        private string _projectName;
        public string ProjectName
        {
            get
            {
                _projectName = Preferences.Get(nameof(ProjectName), AppConstants.ProjectName);
                return _projectName;
            }
            set
            {
                _projectName = value;
                Preferences.Set(nameof(ProjectName), value);
            }
        }

        //Mode
        private string _mode;
        public string Mode
        {
            get
            {
                _mode = Preferences.Get(nameof(Mode), AppConstants.Mode);
                return _mode;
            }
            set
            {
                _mode = value;
                Preferences.Set(nameof(Mode), value);
            }
        }

        //Genre Saved as String Json
        private string _genreList;
        public string GenreList
        {
            get
            {
                _genreList = Preferences.Get(nameof(GenreList), String.Empty);
                return _genreList;
            }
            set
            {
                _genreList = value;
                Preferences.Set(nameof(GenreList), value);
            }
        }
    }
}
