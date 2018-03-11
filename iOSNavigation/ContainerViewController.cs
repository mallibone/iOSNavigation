using System;
using PureLayout.Net;
using UIKit;

namespace iOSNavigation
{
    internal class ContainterViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var contentView = new ContentViewController();

            View.AddSubview(contentView.View);
            AddChildViewController(contentView);
            contentView.View.AutoPinEdgesToSuperviewEdges();

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ((AwareNavigationController)NavigationController).PoppedViewController += ViewControllerPopped;
        }

        private void ViewControllerPopped(object sender, EventArgs e)
        {
            Console.WriteLine("Going back Shell");
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            if(IsMovingFromParentViewController) Console.WriteLine("Going back Shell");
            ((AwareNavigationController)NavigationController).PoppedViewController -= ViewControllerPopped;
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            if(parent == null) Console.WriteLine("Going back Shell");
            base.WillMoveToParentViewController(parent);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            // this will throw a argument null exception
            //((AwareNavigationController)NavigationController).PoppedViewController -= ViewControllerPopped;
        }
    }
}
