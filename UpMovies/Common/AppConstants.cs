namespace UpMovies.Common
{
    public static class AppConstants
    {
        //Basically what we have here is a static class to handlle all general contants in the app

        //Project Name - default
        public const string ProjectName = "UpMovies";

        //Mode - default
        public const string Mode = "DEBUG";

        //URL to consume API
        public const string ApiURL = "https://api.themoviedb.org";

        //ApiKey Paramter to consume API
        public const string ApiKey = "1f54bd990f1cdfb230adb312546d765d";

        //Language Paramter to consume API
        public const string ApiLanguage = "en-US";

        //Sort Paramter to consume API
        public const string ApiSort = "primary_release_date.asc";

        //Adult Paramter to consume API
        public const string ApiAdult = "false"; //I could use bool, I know! But to avoid extra processing 

        //Video Paramter to consume API
        public const string ApiVideo = "false";

        //Date Paramter to consume API
        public const string ApiDate = "now";
    }
}
