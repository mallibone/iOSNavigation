using System;
using Foundation;
using UIKit;

namespace iOSNavigation
{
    public class AwareNavigationController : UINavigationController
    {
        public event EventHandler PoppedViewController;

        public AwareNavigationController() : base() { }
        public AwareNavigationController(UIViewController rootViewController) : base(rootViewController) { }
        public AwareNavigationController(IntPtr intPtr) : base(intPtr) { }
        public AwareNavigationController(NSCoder coder) : base(coder) { }
        public AwareNavigationController(NSObjectFlag t) : base(t) { }
        public AwareNavigationController(string nibName, NSBundle bundle) : base(nibName, bundle) { }
        public AwareNavigationController(Type navigationBarType, Type toolbarType) : base(navigationBarType, toolbarType) { }

        public override UIViewController PopViewController(bool animated)
        {
            PoppedViewController?.Invoke(this, null);
            return base.PopViewController(animated);
        }
    }
}
