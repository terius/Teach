using Common;
using Helpers;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class BaseForm : CSkinBaseForm
    {
        #region 自定义字段
        private static bool beingCallTheRoll = false;//
        private static bool beingScreenBroadcast = false;//正在屏幕广播
        private static bool beingWatching = false;//正在查看学生端
        private string rtspAddress = null;
        public List<MyChatForm> chatFormList = new List<MyChatForm>();
        private MyChatForm chatForm;
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
            messageList.InvokeOnUiThreadIfRequired(() => messageList.AppendText(message.DataStr));
            switch (message.Action)
            {
                case (int)CommandType.OnlineList:
                    IList<OnlineListResult> infos = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);
                    this.InvokeOnUiThreadIfRequired(() => userListShow(infos));
                    //this.Invoke(new Action(() =>
                    //{
                    //    userListShow(infos);
                    //}));
                    break;
                case (int)CommandType.PrivateChat:
                    var PrivateChatResponse = JsonHelper.DeserializeObj<PrivateChatRequest>(message.DataStr);
                    AppendToPrivateForm(PrivateChatResponse);
                    break;
                default:
                    break;
            }
        }

        private void AppendToPrivateForm(PrivateChatRequest privateChatResponse)
        {
            var f = chatFormList.Where(d => d.Name == privateChatResponse.receivename).FirstOrDefault();
            if (f == null)
            {
                return;
            }

            f.InvokeOnUiThreadIfRequired(() => f.AddReceivedMsg(privateChatResponse));
            //if (f.InvokeRequired)
            //{
            //    f.BeginInvoke(new Action(() =>
            //    {
            //        f.AddReceivedMsg(privateChatResponse);

            //    }));
            //}
            //else
            //{
            //    f.AddReceivedMsg(privateChatResponse);
            //}

        }

        //显示用户列表
        private void userListShow(IList<OnlineListResult> onLineList)
        {

            this.onlineList.Clear();
            foreach (OnlineListResult item in onLineList)
            {
                ListViewItem listItem = new ListViewItem();
                //listItem.Name = item.clientStyle == ClientStyle.PC ? "计算机" : "移动端";
                listItem.Text = item.nickname;
                listItem.ImageIndex = item.clientRole == ClientRole.Student ? 0 : 39;
                listItem.SubItems.Add(item.username);

                this.onlineList.Items.Add(listItem);
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
            //string text = this.ScreenBroadcastToolStripMenuItem.Text;
            //if (text == "屏幕广播")
            //{
            //    if (!beingWatching)
            //    {
            //        GlobalVariable.client.CreateScreenInteract();
            //        GlobalVariable.client.Send_ScreenInteract();
            //        this.ScreenBroadcastToolStripMenuItem.Text = "关闭广播";
            //        beingScreenBroadcast = true;
            //    }
            //    else
            //    {
            //        //  showTip();
            //        return;
            //    }
            //}
            //else
            //{
            //    //  si.stopScreenInteract();
            //    this.ScreenBroadcastToolStripMenuItem.Text = "屏幕广播";
            //    rtspAddress = null;
            //    beingScreenBroadcast = false;
            //}
        }



      

        private void ScreenLockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string username = this.onlineList.SelectedItems[0].SubItems[1].Text;
            GlobalVariable.client.Send_LockScreen(username);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string username = this.onlineList.SelectedItems[0].SubItems[1].Text;
            GlobalVariable.client.Send_StopLockScreen(username);
        }

        private void PrivateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = this.onlineList.SelectedItems[0].SubItems[1].Text;
            string displayName = this.onlineList.SelectedItems[0].Text;
            AddChatRequest request = new AddChatRequest();
            request.ChatDisplatName = displayName;
            request.ChatType = ChatType.PrivateChat;
            request.ChatUserName = userName;
            GlobalVariable.AddNewChat(request);
            if (chatForm == null)
            {
                chatForm = new MyChatForm(request);
            }
            else
            {
                chatForm.BringToFront();
                chatForm.CreateChatItems(request,false);
            }
            chatForm.Show();

            //  PrivateChatForm f = new PrivateChatForm(displayName, userName, GlobalVariable.client);
          //  openChatForm(request);
            //  f = new MyChatForm(displayName, userName);
            //  f.Show();


        }


        private void CreateChatForm()
        {

        }

        private void openChatForm(AddChatRequest request)
        {
            bool isDue = false;
            foreach (var form in chatFormList)
            {
                if (form.Name == request.ChatUserName)
                {
                    isDue = true;
                    form.BringToFront();
                    break;

                }
            }
            if (!isDue)
            {
                MyChatForm chatForm = new MyChatForm(request);
                chatForm.FormClosed += ChatForm_FormClosed;
                chatForm.Name = request.ChatUserName;
                chatFormList.Add(chatForm);
                chatForm.Show();
            }
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            chatFormList.Remove((MyChatForm)sender);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            GlobalVariable.client.Send_OnlineList();
        }

        private void onlineList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = onlineList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    onlineList.ContextMenuStrip = contextMenuStrip1;
                }
                else
                {
                    onlineList.ContextMenuStrip = null;
                }
                return;
            }
        }
    }



    public class CboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
