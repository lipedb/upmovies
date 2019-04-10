using System;
using UpMovies.Controls;
using UpMovies.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBounceScrollView), typeof(NoBounceScrollViewRenderer))]
namespace UpMovies.iOS.Renderers
{
    public class NoBounceScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Bounces = false;
        }
    }
}
