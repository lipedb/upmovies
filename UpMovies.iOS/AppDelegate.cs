using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using UIKit;

namespace UpMovies.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            var svgAssembly = typeof(SvgCachedImage).Assembly;
            CachedImageRenderer.Init();
            new FFImageLoading.Transformations.TintTransformation();

            UIColor barTintColor = UIColor.FromRGBA(29, 29, 29, 1);
            UIColor textTintColor = UIColor.FromRGB(254, 254, 254);
            UINavigationBar.Appearance.BarTintColor = barTintColor;
            UINavigationBar.Appearance.TintColor = textTintColor;

            var ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            var ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

