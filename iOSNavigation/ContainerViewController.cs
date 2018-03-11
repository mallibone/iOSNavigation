using System;
using PureLayout.Net;
using UIKit;
using System.Linq;

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
            Console.WriteLine("Navigation Controller override: Going back Shell");
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            //if(IsMovingFromParentViewController) Console.WriteLine("Going back Shell");
            // this will throw a argument null exception
            //((AwareNavigationController)NavigationController).PoppedViewController -= ViewControllerPopped;
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (parent == null)
            {
                var childVCs = ChildViewControllers;
                foreach(var childVC in childVCs)
                {
                    childVC.RemoveFromParentViewController();
                }

                Console.WriteLine("Method override: Going back Shell");
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            ((AwareNavigationController)NavigationController).PoppedViewController -= ViewControllerPopped;
        }
    }
}
