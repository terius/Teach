using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TcpConnectJson;
using Newtonsoft.Json;


namespace TeacherUser
{
    public partial class TeamDiscuss : Form
    {
        public static int TNUMBER = 1;
        public  List<TreeNode> list = new List<TreeNode>();
        public static List<TreeNode> listAll = new List<TreeNode>();

        private static int count = 0;
        public TeamDiscuss()
        {
            InitializeComponent();           
        }

        private void TeamDiscussNew_Load(object sender, EventArgs e)
        {         
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.FullRowSelect = true;
            this.treeView1.ImageList = this.imageList1;
            this.listView1.Columns.Add("设备", 90, HorizontalAlignment.Left); //一步添加 
            //this.listView1.Columns.Add("身份", 90, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("IP地址", 120, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("端口号", 90, HorizontalAlignment.Left); //一步添加 

            
            foreach (UserInfm user in MainForm.userlist)
            {
                if (user.role == "TEACHER")
                {
                    continue;
                }
                else
                { 
                  int picIndex=-1;
                  switch(user.deviceType)
                  {
                      case "COMPUTER":
                          picIndex = 1;
                          this.listView1.Items.Add("计算机");
                         // this.listView1.Items[count].SubItems.Add(user.role);
                          this.listView1.Items[count].SubItems.Add(user.ip);
                          this.listView1.Items[count].SubItems.Add(user.port.ToString());
                          this.listView1.Items[count].ImageIndex = picIndex;
                          break;
                      case "ANDROID":
                          picIndex = 3;
                          this.listView1.Items.Add("移动端");
                         // this.listView1.Items[count].SubItems.Add(user.role);
                          this.listView1.Items[count].SubItems.Add(user.ip);
                          this.listView1.Items[count].SubItems.Add(user.port.ToString());
                          this.listView1.Items[count].ImageIndex = picIndex;
                          break;
                      default:
                          break;
                  }               
                  count++;                   
                }
            }
            this.textBox1.Text = count.ToString();
            /*
            MysqlHelper helper = new MysqlHelper();         
            string sql = string.Format("SELECT picIndex,name from online");
            MySqlDataReader dr = MysqlHelper.ExecuteReader(sql);
            try
            {
                while (dr.Read())
                {
                    int picIndex =Convert.ToInt32(dr["picIndex"]);
                    string name = dr["name"].ToString();
                    ListViewItem lvi = new ListViewItem();        //首先创建一个ListView项item
                    lvi.ImageIndex = picIndex;
                    lvi.Text = name;
                    this.listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;

            }
            finally
            {
                dr.Close();//关闭
            }
            */         
        }

        private void button1_Click(object sender, EventArgs e)//右移 添加至新建小组
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < this.listView1.SelectedItems.Count; i++)//
                {
                    //string str = (string)this.listView1.SelectedItems[i].SubItems[1].Text;
                    string str = (string)this.listView1.SelectedItems[i].SubItems[0].Text + "(" + (string)this.listView1.SelectedItems[i].SubItems[1].Text + ":" + (string)this.listView1.SelectedItems[i].SubItems[2].Text + ")";
                    int p = this.listView1.SelectedItems[i].ImageIndex;
                    TreeNode node1 = new TreeNode();
                    node1.Text = str;
                    node1.ImageIndex = p;//注意：ImageIndex是节点没选中时的图片索引
                    node1.SelectedImageIndex = p;//SelectedImageIndex是节点选中时的图片索引
                    // TreeNode node = TN[TNUMBER - 1];
                    TreeNode node = list[TNUMBER - 2];
                    node.Nodes.Add(node1);
                }
                for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
                {
                    this.listView1.Items.Remove(this.listView1.SelectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("请先建立小组！");
            }
        }

        private void button3_Click(object sender, EventArgs e)//新建分组
        {
            TreeNode node = new TreeNode();
            node.Text = "小组" + TNUMBER.ToString();
            node.ImageIndex = 0;
            treeView1.Nodes.Add(node);
            //  TN[TNUMBER - 1] = node;
            if (node != null)
            {
                list.Add(node);
                TNUMBER++;
            }
            AddContextMenu(node.Text);
        }

        private void button2_Click(object sender, EventArgs e)//左移
        {
            string str = (string)this.treeView1.SelectedNode.Text;
            int p = this.treeView1.SelectedNode.ImageIndex;
            if (p == 0)
            {
                /*
                foreach(TreeNode tn in this.treeView1.SelectedNode.Nodes)
                {]
                    listViewAdd(tn.Text, tn.ImageIndex);
                }
                */
            }
            else
            {
                listViewAdd(str,p);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }      
        }

        public void listViewAdd(string str, int index)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = index;
            lvi.Text = str;
            this.listView1.Items.Add(lvi);
        }


       //**********************************************************************************************
         ToolStripMenuItem mi = new ToolStripMenuItem("移动至");//contextMenuStrip1要求是空
         ToolStripMenuItem mii = new ToolStripMenuItem("移动至");//contextMenuStrip3要求是空


        void AddContextMenu(string text)
        {
              contextMenuStrip1.Items.Clear();
              mi.DropDownItems.Add(text);
              mi.DropDownItems[TNUMBER - 2].Click += delegate(Object o, EventArgs e) { MenuClicked(contextMenuStrip1, text); };//
              this.contextMenuStrip1.Items.Add(mi);

             this.contextMenuStrip3.Items.Clear();
             mii.DropDownItems.Add(text);
             mii.DropDownItems[TNUMBER - 2].Click += delegate(Object o, EventArgs e) { MenuClicked2(contextMenuStrip3, text); };//
             this.contextMenuStrip3.Items.Add(mii);
        }
        //***********************************************************************************************

       
        void MenuClicked(object sender, string strValue)
        {
            //MessageBox.Show(strValue);//测试用
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)//
            {
                //string str = (string)this.listView1.SelectedItems[i].Text;
                string str = (string)this.listView1.SelectedItems[i].SubItems[0].Text + "(" + (string)this.listView1.SelectedItems[i].SubItems[1].Text + ":" + (string)this.listView1.SelectedItems[i].SubItems[2].Text + ")";

                int p = this.listView1.SelectedItems[i].ImageIndex;
                TreeNode node1 = new TreeNode();
                node1.Text = str;
                node1.ImageIndex = p;
                node1.SelectedImageIndex = p;
                TreeNode node = FindNode(strValue);
                node.Nodes.Add(node1);
            }

            for (int i = this.listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                this.listView1.Items.Remove(this.listView1.SelectedItems[i]);
            }
        }

        void MenuClicked2(object sender, string strValue)
        {
            TreeNode node = FindNode(strValue);//目的根节点
            string str = (string)this.treeView1.SelectedNode.Text;
            int p = this.treeView1.SelectedNode.ImageIndex;
            TreeNode node1 = new TreeNode();
            node1.Text = str;
            node1.ImageIndex = p;
            node1.SelectedImageIndex = p;
            node.Nodes.Add(node1);
            //-------------------------------------------------
            treeView1.Nodes.Remove(treeView1.SelectedNode);    
        }
        private TreeNode FindNode(string strValue)
        {
            foreach (TreeNode tn in list)
            {
                if (tn.Text == strValue) return tn;
            }
            return null;
        }

        private void TeamDiscussNew_FormClosing(object sender, FormClosingEventArgs e)//进行一些释放和“复位”操作
        {
            TNUMBER = 1;
            list = null;
            count = 0;
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    listView1.ContextMenuStrip = null;
                    //liscontextMenuStrip1.Hide();
                }
                else
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                    listView1.ContextMenuStrip = contextMenuStrip1;
                }
                return;
            }
        }
     

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {     
            if (e.Button == MouseButtons.Right)
            {
                 TreeNode tn=treeView1.GetNodeAt(e.X,e.Y);
                 if (tn != null)
                 {
                     treeView1.SelectedNode = tn;

                     if (tn.ImageIndex == 0)
                     {
                         treeView1.ContextMenuStrip = null;
                     }
                     else
                     {
                         contextMenuStrip2.Items[0].Enabled = false;
                         contextMenuStrip2.Items[1].Enabled = true;
                         //treeView1.ContextMenuStrip = contextMenuStrip2;
                         treeView1.ContextMenuStrip = contextMenuStrip3;
                     }
                 }
                 else
                 {
                     this.treeView1.SelectedNode = null;
                     contextMenuStrip2.Items[0].Enabled = true;
                     contextMenuStrip2.Items[1].Enabled = false;
                     treeView1.ContextMenuStrip = contextMenuStrip2;
                 }          
                return;
            }
        }

        private void 新建小组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(this, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(this, e);
        }

        private void button4_Click(object sender, EventArgs e)//完成分组
        {
           List<groupNode> groupNodeInfo = new List<groupNode>();
            foreach (TreeNode m in treeView1.Nodes)//将最后的分组信息保存到static链表中
            {
                listAll.Add(m);
                foreach (TreeNode n in m.Nodes)
                {
                    listAll.Add(n);                   
                    int begin = n.Text.IndexOf("(");
                    int middle = n.Text.IndexOf(":");
                    int end = n.Text.IndexOf(")");                                              
                    groupNode gNode = new groupNode();
                    gNode.nodeName = m.Text;
                    gNode.ip = n.Text.Substring(begin + 1, middle - begin - 1);
                    gNode.port = int.Parse(n.Text.Substring(middle + 1, end - middle - 1));
                    groupNodeInfo.Add(gNode);                 
                }    
            }
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.discussList;
            msg.time = System.DateTime.Now.ToString();
            msg.content = JsonConvert.SerializeObject(groupNodeInfo);
            MainForm.clientConnect.SendMessage(msg);
        }


        class TreeNodes
        {
            private TreeNode[] tn; //这里我就声明了系统的TreeNode类的数组，把那某个节点下的一级节点都保存进去
            private string groupName;
            public TreeNodes(TreeNode treenode) //构造函数就是把一级节点保存到数组里了呢
            {
                tn = new TreeNode[treenode.Nodes.Count];
                for (int i = 0; i < treenode.Nodes.Count; i++)
                {
                    tn[i] = treenode.Nodes[i];
                }
                groupName = treenode.Text;
            }
        }

       public class groupInfo
        {
            private string groupName;
            public string GroupName
            {
                get { return groupName; }
                set { groupName = value; }
            }
            private string[] IPs; //

            public string[] IPs1
            {
                get { return IPs; }
                set { IPs = value; }
            }
            private string[] Ports;//

            public string[] Ports1
            {
                get { return Ports; }
                set { Ports = value; }
            }
            public groupInfo(TreeNode parentNode) //构造函数就是把一级节点保存到数组里了呢
            {
                int tn = parentNode.Nodes.Count;
                IPs1 = new String[tn];
                Ports1 = new String[tn];
                for (int i = 0; i < tn; i++)
                {
                    int begin = parentNode.Nodes[i].Text.IndexOf("(");
                    int middle = parentNode.Nodes[i].Text.IndexOf(":");
                    int end = parentNode.Nodes[i].Text.IndexOf(")");
                    if ((begin != -1) && (middle != -1) || (end != -1))
                    {
                        string _ip = parentNode.Nodes[i].Text.Substring(begin+1, middle -begin-1);
                        string _port = parentNode.Nodes[i].Text.Substring(middle+1,end-middle-1);
                        IPs1[i] =_ip;
                        Ports1[i] = _port;
                    }
                }
                GroupName = parentNode.Text;
            }
        }
       public class groupInfo2//没有用到
       {
           private string groupName;
           public string GroupName
           {
               get { return groupName; }
               set { groupName = value; }
           }
           private string memberIP; //
           public string MemberIP
           {
               get { return memberIP; }
               set { memberIP = value; }
           }
           private string memberPort;//
           public string MemberPort
           {
               get { return memberPort; }
               set { memberPort = value; }
           }           
       }
     }
    }
