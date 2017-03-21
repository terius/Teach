using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class TeamView : Form
    {
        private TreeView treeView1=new TreeView();
        public TeamView()
        {
            InitializeComponent();
        }

        public TeamView(TreeView treeViewSource)
        {
            // TODO: Complete member initialization
            this.treeView1 = treeViewSource; 
        }

        private void TeamView_Load(object sender, EventArgs e)
        {
            this.TeamViewTree.ImageList = this.imageList1;
            TreeNode parentNode = null;
            for (int i = 0; i < TeamDiscuss.listAll.Count; )
            {               
                //int m = -1;
                TreeNode node = new TreeNode();
                node.Text = TeamDiscuss.listAll[i].Text;
                node.ImageIndex = TeamDiscuss.listAll[i].ImageIndex;
                node.SelectedImageIndex = node.ImageIndex;//SelectedImageIndex是节点选中时的图片索引
                if (node.ImageIndex == 0)
                {
                    parentNode = node;
                    TeamViewTree.Nodes.Add(parentNode);
                }
                else {
                    parentNode.Nodes.Add(node);
                }
                i++;              
            }
            /*
              MessageBox.Show("123");
              this.TeamViewTree = treeView1;
              if (this.TeamViewTree != null)
              {
                  TeamViewTree.ExpandAll(); //全部展开
              }
               * */
        }
    }
}

      
   

