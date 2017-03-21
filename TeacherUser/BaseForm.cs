using CCWin;
using Common;
using Helpers;
using Model;
using MyTCP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TeacherUser.InformationInter;

namespace TeacherUser
{
    public partial class BaseForm : Skin_DevExpress
    {
        #region 自定义字段
        private static bool beingCallTheRoll = false;//
        private static bool beingScreenBroadcast = false;//正在屏幕广播
        private static bool beingWatching = false;//正在查看学生端
        private string rtspAddress = null;
        public List<ChatForm> chatFormList = new List<ChatForm>();
        #endregion

        public BaseForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            GlobalVariable.client.Send_OnlineList();
            // tcpClient.messageDue.OnReceieveMessage += MessageDue_OnReceieveMessage1;
            // beginAction();
        }

        private void Client_OnReveieveData(ReceieveMessage message)
        {

            switch (message.Action)
            {
                case (int)CommandType.OnlineList:
                    IList<OnlineListResult> infos = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);
                    this.Invoke(new Action(() =>
                    {
                        this.messageList.AppendText(message.DataStr);
                        userListShow(infos);
                    }));
                    break;
                default:
                    break;
            }
            // this.Invoke(new Action(() => this.messageList.AppendText(message.DataStr)));
        }
        //显示用户列表
        private void userListShow(IList<OnlineListResult> onLineList)
        {
            this.listView1.Clear();
            foreach (OnlineListResult item in onLineList)
            {
                ListViewItem listItem = new ListViewItem();
                //listItem.Name = item.clientStyle == ClientStyle.PC ? "计算机" : "移动端";
                listItem.Text = item.nickname;
                listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 39;
                listItem.SubItems.Add(item.username);
                this.listView1.Items.Add(listItem);
            }


            //switch (deviceType)
            //{
            //    case "COMPUTER":
            //  this.listView1.Items.Add("计算机");
            //        this.listView1.Items[userCount].SubItems.Add(role);
            //        this.listView1.Items[userCount].SubItems.Add(ip);
            //        this.listView1.Items[userCount].SubItems.Add(port);
            //        this.listView1.Items[userCount].SubItems.Add("否");
            //        this.listView1.Items[userCount].SubItems.Add("否");
            //        this.listView1.Items[userCount].ImageIndex = 0;
            //        userCount++;
            //        break;
            //    case "ANDROID":
            //        this.listView1.Items.Add("移动端");
            //        this.listView1.Items[userCount].SubItems.Add(role);
            //        this.listView1.Items[userCount].SubItems.Add(ip);
            //        this.listView1.Items[userCount].SubItems.Add(port);
            //        this.listView1.Items[userCount].ImageIndex = 1;
            //        this.listView1.Items[userCount].SubItems.Add("否");
            //        this.listView1.Items[userCount].SubItems.Add("否");
            //        userCount++;
            //        break;
            //}
        }




        private void button2_Click(object sender, EventArgs e)
        {
            //  TranMessage = d => this.textBox1.Text = d;
            //  Invoke(TranMessage, DateTime.Now.Ticks.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveSignToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// 屏幕广播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBroadcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = this.ScreenBroadcastToolStripMenuItem.Text;
            if (text == "屏幕广播")
            {
                if (!beingWatching)
                {
                    GlobalVariable.client.CreateScreenInteract();
                    GlobalVariable.client.Send_ScreenInteract();
                    this.ScreenBroadcastToolStripMenuItem.Text = "关闭广播";
                    beingScreenBroadcast = true;
                }
                else
                {
                    //  showTip();
                    return;
                }
            }
            else
            {
                //  si.stopScreenInteract();
                this.ScreenBroadcastToolStripMenuItem.Text = "屏幕广播";
                rtspAddress = null;
                beingScreenBroadcast = false;
            }
        }

        private void btnReflashOnLine_Click(object sender, EventArgs e)
        {
            GlobalVariable.client.Send_OnlineList();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    var hitTestInfo = listView1.HitTest(e.X, e.Y);
            //    if (hitTestInfo.Item != null)
            //    {
            //        var loc = e.Location;
            //        loc.Offset(listView1.Location);

            //        // Adjust context menu (or it's contents) based on hitTestInfo details
            //        this.contextMenuStrip1.Show(this, loc);
            //    }
            //}

            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = listView1.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    listView1.ContextMenuStrip = contextMenuStrip1;
                }
                else
                {
                    listView1.ContextMenuStrip = null;
                }
                return;
            }
        }

        private void ScreenLockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string username = this.listView1.SelectedItems[0].SubItems[1].Text;
            GlobalVariable.client.Send_LockScreen(username);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string username = this.listView1.SelectedItems[0].SubItems[1].Text;
            GlobalVariable.client.Send_StopLockScreen(username);
        }

        private void PrivateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = this.listView1.SelectedItems[0].SubItems[1].Text;
            string receName = this.listView1.SelectedItems[0].Text;
            PrivateChatForm f = new PrivateChatForm(receName);
            f.Show();

            
        }
    }



    public class CboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
