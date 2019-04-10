using System;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using UpMovies.Droid.Renderers;
using UpMovies.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SnackBarNotificationRender))]
namespace UpMovies.Droid.Renderers
{
    public class SnackBarNotificationRender : ISnackBarNotification
    {
        Snackbar notifiation;

        public void SnackbarDismiss()
        {
            if(notifiation != null)
                notifiation.Dismiss();
        }

        public void SnackbarShow(string message, string acionMessage)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View view = activity.FindViewById(Android.Resource.Id.Content);
            notifiation = Snackbar.Make(view, message, Snackbar.LengthIndefinite);
            notifiation.SetAction(acionMessage, (obj) => notifiation.Dismiss());
            notifiation.SetActionTextColor(Android.Graphics.Color.ParseColor(activity.Resources.GetString(Resource.Color.NotificationActionColor)));
            Android.Views.View snackView = notifiation.View;
            FrameLayout.LayoutParams layoutParams = (FrameLayout.LayoutParams)snackView.LayoutParameters;
            layoutParams.Gravity = GravityFlags.Top;
            snackView.LayoutParameters = layoutParams;
            snackView.SetBackgroundColor(Android.Graphics.Color.ParseColor(activity.Resources.GetString(Resource.Color.ActionBarColor)));
            TextView textMessage = (TextView)snackView.FindViewById(Resource.Id.snackbar_text);
            textMessage.SetTextColor(Android.Graphics.Color.ParseColor(activity.Resources.GetString(Resource.Color.NotificationMessageColor)));
            textMessage.SetTextSize(Android.Util.ComplexUnitType.Px, 24);
            notifiation.Show();
            //"Many thanks to https://github.com/logeshpalani98"
        }


    }
}
