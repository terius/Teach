using Common;
using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SharedForms;
using System;

namespace NewTeacher
{
    public partial class TeamDiscuss : CSkinBaseForm
    {

        OnlineInfo _onLineInfo;
        ChatStore selectTeam;
        public TeamDiscuss(OnlineInfo onLineInfo)
        {
            InitializeComponent();
            _onLineInfo = onLineInfo;
            _onLineInfo.AddOnLine += _onLineInfo_AddOnLine;
            BindTeam();
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

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            GlobalVariable.CreateTeamChat(this.txtCreate.Text.Trim());
            BindTeam();
        }

        private void BindTeam()
        {
            cboxTeam.Items.Clear();
            teamMemList.Clear();
            var list = GlobalVariable.GetTeamChatList();
            foreach (ChatStore item in list)
            {
                cboxTeam.Items.Add(item);
            }
            cboxTeam.DisplayMember = "ChatDisplayName";
            cboxTeam.ValueMember = "ChatUserName";
            if (cboxTeam.Items.Count > 0)
            {
                cboxTeam.SelectedIndex = 0;
            }

        }

        private void cboxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTeamMember();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cboxTeam.SelectedIndex >= 0)
            {
                selectTeam = (ChatStore)cboxTeam.SelectedItem;
                fmEditTeamName editForm = new fmEditTeamName(selectTeam.ChatUserName, selectTeam.ChatDisplayName);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    BindTeam();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboxTeam.SelectedIndex >= 0)
            {
                selectTeam = (ChatStore)cboxTeam.SelectedItem;
                var rs = GlobalVariable.DelTeam(selectTeam.ChatUserName);
                if (rs)
                {
                    GlobalVariable.ShowSuccess("分组删除成功");
                    BindTeam();
                }
                else
                {
                    GlobalVariable.ShowError("分组删除失败");
                }
            }
        }

        private void picAddMem_Click(object sender, EventArgs e)
        {
            if (onLineListView.CheckedItems.Count <= 0)
            {
                GlobalVariable.ShowWarnning("请先选择要添加的学生");
                return;
            }

            if (cboxTeam.SelectedIndex < 0)
            {
                GlobalVariable.ShowWarnning("请先选择要添加的分组");
                return;
            }
            selectTeam = (ChatStore)cboxTeam.SelectedItem;
            GlobalVariable.AddTeamMember(onLineListView.CheckedItems, selectTeam.ChatUserName);
            BindTeamMember();
        }

        private void BindTeamMember()
        {
            if (cboxTeam.SelectedIndex >= 0)
            {
                selectTeam = (ChatStore)cboxTeam.SelectedItem;
                groupBox2.Text = "分组：" + selectTeam.ChatDisplayName + "的成员";
                teamMemList.Clear();
                foreach (TeamMember mem in selectTeam.TeamMembers)
                {
                    ListViewItem listItem = new ListViewItem();
                    //listItem.Name = item.clientStyle == ClientStyle.PC ? "计算机" : "移动端";
                    listItem.Text = mem.DisplayName;
                    listItem.ImageIndex = 0;
                    listItem.SubItems.Add(mem.UserName);

                    this.teamMemList.Items.Add(listItem);
                }
                CreateTeamRequest request = new CreateTeamRequest();
                request.groupguid = selectTeam.ChatUserName;
                request.groupname = selectTeam.ChatDisplayName;
                request.groupuserList = selectTeam.TeamMembers.Select(d => d.UserName).ToArray();
                request.nickname = GlobalVariable.LoginUserInfo.DisplayName;
                request.username = GlobalVariable.LoginUserInfo.UserName;
                GlobalVariable.client.Send_CreateTeam(request);


            }
        }

        private void memDel_Click(object sender, EventArgs e)
        {
            if (cboxTeam.SelectedIndex >= 0)
            {
                selectTeam = (ChatStore)cboxTeam.SelectedItem;
                
                string userName = this.teamMemList.SelectedItems[0].SubItems[1].Text;
                bool rs = GlobalVariable.DelTeamMember(selectTeam.ChatUserName, userName);
                BindTeamMember();
            }
        }

        private void teamMemList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = teamMemList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    teamMemList.ContextMenuStrip = memberMenu;
                }
                else
                {
                    teamMemList.ContextMenuStrip = null;
                }
                return;
            }
        }
    }
}
