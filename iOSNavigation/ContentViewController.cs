using System;
using Foundation;
using PureLayout.Net;
using UIKit;

namespace iOSNavigation
{
    internal class ContentViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tableView = new UITableView();

            tableView.Source = new MenuTable(this);

            View.AddSubview(tableView);
            tableView.AutoPinEdgesToSuperviewEdges();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ((AwareNavigationController)NavigationController).PoppedViewController += ViewControllerPopped;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            ((AwareNavigationController)NavigationController).PoppedViewController -= ViewControllerPopped;
        }

        private void ViewControllerPopped(object sender, EventArgs e)
        {
            Console.WriteLine("Going back Content");
        }
    }

    internal class MenuTable : UITableViewSource
    {
        private UIViewController _parentView;
        private string[] _menus;
        private const string CellIdentifier = "gnabber";

        public MenuTable(UIViewController parentView)
        {
            _parentView = parentView;
            _menus = new string[] { "Menu one", "Menu two", "Menu three" };
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = _menus[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _menus.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _parentView.NavigationController.PushViewController(new ContainterViewController(), true);
        }
    }
}
