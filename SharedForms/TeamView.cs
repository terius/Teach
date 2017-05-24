using DevExpress.XtraEditors;
using Model;
using SharedForms;
using System;
using System.Windows.Forms;

namespace SharedForms
{
    public partial class TeamView : XtraForm
    {
    
        public TeamView()
        {
            InitializeComponent();
        }

       

        private void TeamView_Load(object sender, EventArgs e)
        {
           // toolTip1.SetToolTip(this.treeView1, "信息提示");
            this.treeView1.Nodes.Clear();
            var list = GlobalVariable.GetTeamChatList();
            TreeNode node;
            TreeNode childNode;
            foreach (ChatStore item in list)
            {
                node = new TreeNode(item.ChatDisplayName);
                foreach (TeamMember child in item.TeamMembers)
                {
                    childNode = new TreeNode(child.DisplayName);
                    childNode.ImageIndex = childNode.SelectedImageIndex = child.IsOnline ? 2 : 3;
                    childNode.ToolTipText = child.IsOnline ? "在线" : "离线";
                    node.Nodes.Add(childNode);
                }
                this.treeView1.Nodes.Add(node);
            }
            treeView1.ExpandAll();
        }
    }
}
