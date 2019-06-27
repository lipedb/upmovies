using UpMovies.Interfaces;
using TTGSnackBar;
using Xamarin.Forms;
using UpMovies.iOS.Renderers;

[assembly: Xamarin.Forms.Dependency(typeof(SnackBarNotificationRender))]
namespace UpMovies.iOS.Renderers
{
    public class SnackBarNotificationRender : ISnackBarNotification
    {
        TTGSnackbar snackbar; 
        public void SnackbarDismiss()
        {
            if (snackbar != null)
                snackbar.Dismiss();
        }

        public void SnackbarShow(string message, string acionMessage)
        {
            snackbar = new TTGSnackbar(message, acionMessage, (t) => { t.Dismiss(); });
        }
    }
}
