using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, System.EventArgs e)
        {
            navBarGroup2.SelectedLinkIndex = 3;

          //  barManager1.SetPopupContextMenu(navBarControl1, popupMenu1);
            // this.Appearance.
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            navBarGroup2.SelectedLinkIndex = 0;
        }

        private void navBarControl1_CustomDrawLink(object sender, CustomDrawNavBarElementEventArgs e)
        {
            DevExpress.XtraNavBar.NavBarItemLink link = ((NavLinkInfoArgs)e.ObjectInfo).Link;
            if (link.State == DevExpress.Utils.Drawing.ObjectState.Selected
                || link.State == DevExpress.Utils.Drawing.ObjectState.Hot
                || link.State == DevExpress.Utils.Drawing.ObjectState.Pressed
                )
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, e.RealBounds);
            }
        }

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Text = "navBarControl1_LinkClicked";
        }

        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Text = "navBarControl1_LinkPressed";
        }
        NavBarItem selectedNavBarItem = null;
        private void navBarControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
          //  selectedNavBarItem = navBarControl1.v
            NavBarHitInfo hit = navBarControl1.CalcHitInfo(e.Location);
            if ((!hit.InLink))
            {
                return;
            }
            FieldInfo fi = typeof(NavBarControl).GetField("viewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            NavBarViewInfo vi = fi.GetValue(navBarControl1) as NavBarViewInfo;
            selectedNavBarItem = vi.HotTrackedLink.Item;
            NavLinkInfoArgs arg = vi.GetLinkInfo(hit.Link);
            Point p = new Point(arg.Bounds.X, arg.Bounds.Bottom);
            popupMenu1.ShowPopup(navBarControl1.PointToScreen(p));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // var item = navBarControl1.SelectLinkOnPress;
            if (selectedNavBarItem != null)
            {
                MessageBox.Show(selectedNavBarItem.Caption);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            alertControl1.AutoFormDelay = 300;
            alertControl1.Show(this, "警告", "asdasdasd");
        }
    }
}