namespace UpMovies.Interfaces
{
    public interface ISnackBarNotification
    {
        void SnackbarShow(string message, string actionMessage);
        void SnackbarDismiss();
    }
}

