using Common;
using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedForms;

namespace NewTeacher
{
    public partial class TeamDiscuss : CSkinBaseForm
    {

        OnlineInfo _onLineInfo;
        public TeamDiscuss(OnlineInfo onLineInfo)
        {
            InitializeComponent();
            _onLineInfo = onLineInfo;
            _onLineInfo.AddOnLine += _onLineInfo_AddOnLine;
        }

        private void _onLineInfo_AddOnLine(object sender, OnlineEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                AddUserList(e.OnLines);
            });
        }

        private void AddUserList(IList<OnlineListResult> onLineList)
        {
          
                //  MessageBox.Show("新用户登陆");
                foreach (OnlineListResult item in onLineList)
                {
                    if (!IsMySelf(item.username))
                    {
                        //   if (!_onLineInfo.OnLineList.Any(d => d.username == item.username))
                        //   {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = item.nickname;
                        listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 39;
                        listItem.SubItems.Add(item.username);
                        this.onLineListView.Items.Add(listItem);
                        //  }
                    }
                }
            
        }

        private void TeamDiscuss_Load(object sender, System.EventArgs e)
        {
            foreach (OnlineListResult item in _onLineInfo.OnLineList)
            {
                if (!IsMySelf(item.username))
                {
                    ListViewItem listItem = new ListViewItem();
                    //listItem.Name = item.clientStyle == ClientStyle.PC ? "计算机" : "移动端";
                    listItem.Text = item.nickname;
                    listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 39;
                    listItem.SubItems.Add(item.username);

                    this.onLineListView.Items.Add(listItem);
                }
            }
        }
    }
}
