using Common;
using DevExpress.XtraEditors;
using Model;
using SharedForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewTeacher
{
    public partial class TeamDiscuss : XtraForm
    {

        OnlineInfo _onLineInfo;
        ChatStore selectTeam;
        public TeamDiscuss(OnlineInfo onLineInfo)
        {
            InitializeComponent();
            _onLineInfo = onLineInfo;
            _onLineInfo.AddOnLine += _onLineInfo_AddOnLine;
            _onLineInfo.DelOnLine += _onLineInfo_DelOnLine;
        }

        private void _onLineInfo_DelOnLine(UserLogoutResponse delInfo)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                foreach (ListViewItem item in this.onLineListView.Items)
                {
                    if (item.SubItems[1].Text == delInfo.username)
                    {
                        item.Remove();
                        break;
                    }
                }
            });
         
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
            foreach (OnlineListResult item in onLineList)
            {
                if (!item.username.IsMySelf())
                {
                    ListViewItem listItem = new ListViewItem();
                    listItem.Text = item.nickname;
                    listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 1;
                    listItem.SubItems.Add(item.username);
                    this.onLineListView.Items.Add(listItem);
                }
            }

        }

        private void TeamDiscuss_Load(object sender, System.EventArgs e)
        {
            BindOnlineUser();
            BindTeam();
        }

        private void BindOnlineUser()
        {
            foreach (OnlineListResult item in _onLineInfo.OnLineList)
            {
                if (!item.username.IsMySelf())
                {
                    ListViewItem listItem = new ListViewItem();
                    //listItem.Name = item.clientStyle == ClientStyle.PC ? "计算机" : "移动端";
                    listItem.Text = item.nickname;
                    listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 1;
                    listItem.SubItems.Add(item.username);

                    this.onLineListView.Items.Add(listItem);
                }
            }
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            if (GlobalVariable.CreateTeamChat(this.txtCreate.Text.Trim()))
            {
                AddNewTeam();
            }
        }

        private void AddNewTeam()
        {
            var newItem = GlobalVariable.GetNewTeamChat();
            cboxTeam.Items.Add(newItem);
            cboxTeam2.Items.Add(newItem);
            if (cboxTeam.SelectedIndex <= 0)
            {
                cboxTeam.SelectedIndex = 0;
            }
        }

        private void BindTeam()
        {
            cboxTeam.Items.Clear();
            cboxTeam2.Items.Clear();
            teamMemList.Clear();
            var list = GlobalVariable.GetTeamChatList();
            foreach (ChatStore item in list)
            {
                cboxTeam.Items.Add(item);
                cboxTeam2.Items.Add(item);
            }
            cboxTeam.DisplayMember = "ChatDisplayName";
            cboxTeam.ValueMember = "ChatUserName";
            cboxTeam2.DisplayMember = "ChatDisplayName";
            cboxTeam2.ValueMember = "ChatUserName";
            if (cboxTeam.Items.Count > 0)
            {
                cboxTeam.SelectedIndex = 0;
            }
            if (cboxTeam2.Items.Count > 0)
            {
                cboxTeam2.SelectedIndex = 0;
            }
        }

        private void cboxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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

            if (cboxTeam2.SelectedIndex < 0)
            {
                GlobalVariable.ShowWarnning("请先选择要添加的分组");
                return;
            }
            selectTeam = (ChatStore)cboxTeam2.SelectedItem;
            GlobalVariable.AddTeamMember(onLineListView.CheckedItems, selectTeam.ChatUserName);
            BindTeamMember();
        }

        private void BindTeamMember()
        {
            if (cboxTeam2.SelectedIndex >= 0)
            {
                selectTeam = (ChatStore)cboxTeam2.SelectedItem;
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


                //TeamChatListRequest request = new TeamChatListRequest();
                //request.groupguid = selectTeam.ChatUserName;
                //request.groupname = selectTeam.ChatDisplayName;
                //request.groupuserList = selectTeam.TeamMembers.Select(d => d.UserName).ToArray();
                //request.nickname = GlobalVariable.LoginUserInfo.DisplayName;
                //request.username = GlobalVariable.LoginUserInfo.UserName;
                //GlobalVariable.client.Send_CreateTeam(request);


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

        private void cboxTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTeamMember();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalVariable.SendCommand_TeamChatList();
        }
    }
}
