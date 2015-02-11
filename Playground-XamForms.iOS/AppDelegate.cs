using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ReactiveUI;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace PlaygroundXamForms.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        UIWindow window;
        AutoSuspendHelper suspendHelper;
        UIViewController vc;

        public AppDelegate()
        {
            RxApp.SuspensionHost.CreateNewAppState = () => new AppBootstrapper();
        }

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            Forms.Init ();
            RxApp.SuspensionHost.SetupDefaultSuspendResume();

            suspendHelper = new AutoSuspendHelper(this);
            suspendHelper.FinishedLaunching(app, options);

            window = new UIWindow (UIScreen.MainScreen.Bounds);

            LoadApplication(RxApp.SuspensionHost.GetAppState<AppBootstrapper>().CreateFormsApplication());

            return base.FinishedLaunching(app, options);
        }

        public override void DidEnterBackground(UIApplication application)
        {
            suspendHelper.DidEnterBackground(application);
        }

        public override void OnActivated(UIApplication application)
        {
            suspendHelper.OnActivated(application);
        }
    }
}

