using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpConnectJson;

namespace TeacherUser
{
    public partial class FileDispatch : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        int userCount = 0;
        public FileDispatch()
        {
            InitializeComponent();
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            this.listView1.SmallImageList = MainForm.imgList;
            this.listView1.Columns.Add("设备", 90, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("身份", 90, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("IP地址", 120, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("端口号", 90, HorizontalAlignment.Left); //一步添加 
            this.receiverRtb.AllowDrop = true;
            this.listView1.AllowDrop = true;
            this.receiverRtb.DragEnter+=receiverRtb_DragEnter;
            this.receiverRtb.DragDrop+=receiverRtb_DragDrop;
            if (MainForm.userlist != null)
            {
                foreach (UserInfm user in MainForm.userlist)
                {
                    switch (user.deviceType)
                    {
                        case "COMPUTER":
                            this.listView1.Items.Add("计算机");
                            this.listView1.Items[userCount].SubItems.Add(user.role);
                            this.listView1.Items[userCount].SubItems.Add(user.ip);
                            this.listView1.Items[userCount].SubItems.Add(user.port.ToString());
                            this.listView1.Items[userCount].ImageIndex = 3;
                            userCount++;
                            break;
                        case "ANDRIOD":
                            this.listView1.Items.Add("计算机");
                            this.listView1.Items[userCount].SubItems.Add(user.role);
                            this.listView1.Items[userCount].SubItems.Add(user.ip);
                            this.listView1.Items[userCount].SubItems.Add(user.port.ToString());
                            this.listView1.Items[userCount].ImageIndex = 1;
                            userCount++;
                            break;
                    }          
                }     
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
 
        }

        private void button1_Click(object sender, EventArgs e)//选择文件
        {
             //string resultFile = "";
             openFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 this.textBox1.Text = openFileDialog1.FileName;
             
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FileDispatch_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void FileDispatch_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /*
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }
        */
        private void listView1_DoubleClick(object sender, EventArgs e)//
        {
            textBox2.Text += listView1.SelectedItems[0].SubItems[2].Text+" ";
           // receiverRtb.Text += listView1.SelectedItems[0].SubItems[2].Text + " ";
        }


        private void receiverRtb_DragEnter(object sender, DragEventArgs e)
        {
            // If the data is text, copy the data to the RichTextBox control.
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void receiverRtb_DragDrop(object sender, DragEventArgs e)
        {
            // Paste the text into the RichTextBox where at selection location.
            receiverRtb.AppendText(e.Data.GetData(DataFormats.Text).ToString()+'\n');
        }


        /*
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MessageBox.Show("y");
            
            }
            this.listView1.DoDragDrop(this.listView1.SelectedItems[0].SubItems[2].Text, DragDropEffects.Copy);
        }
        */


        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.listView1.DoDragDrop(this.listView1.SelectedItems[0].SubItems[2].Text, DragDropEffects.Move);
        }


    }
}
