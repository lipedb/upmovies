using Android.Widget;
using UpMovies.Renderers;
using UpMovies.Droid.Renderers;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchbar), typeof(CustomSearchbarRender))]
namespace UpMovies.Droid.Renderers
{

    public class CustomSearchbarRender : SearchBarRenderer
    {
        public CustomSearchbarRender(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var color = global::Xamarin.Forms.Color.LightGray;
                var searchView = Control as SearchView;

                int searchPlateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                Android.Views.View searchPlateView = searchView.FindViewById(searchPlateId);
                searchPlateView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

    }
}
