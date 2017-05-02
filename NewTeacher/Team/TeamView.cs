using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedForms;
using Model;

namespace NewTeacher
{
    public partial class TeamView : Form
    {
        OnlineInfo _onLineInfo;
        public TeamView(OnlineInfo onLineInfo)
        {
            InitializeComponent();
            _onLineInfo = onLineInfo;
            _onLineInfo.AddOnLine += _onLineInfo_AddOnLine;
        }

        private void _onLineInfo_AddOnLine(object sender, OnlineEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
              //  AddUserList(e.OnLines);
            });
        }

        private void TeamView_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            var list = GlobalVariable.GetTeamChatList();
           
            foreach (ChatStore item in list)
            {
                TreeNode node = new TreeNode(item.ChatDisplayName);
                foreach (TeamMember child in item.TeamMembers)
                {
                    node.Nodes.Add(child.DisplayName);
                }
                this.treeView1.Nodes.Add(node);
            }
            treeView1.ExpandAll();
        }
    }
}
