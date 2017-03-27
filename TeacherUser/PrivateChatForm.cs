using Common;
using Model;
using MyTCP;
using System;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class PrivateChatForm : Form
    {
        private string _displayName;
        private string _userName;
        private MyTcpClient _client;
        public PrivateChatForm(string displayName, string userName, MyTcpClient client)
        {
            _displayName = displayName;
            _userName = userName;
            _client = client;
            InitializeComponent();
            Text = "与（" + _displayName + "）的聊天";
        }

        private void PrivateChatForm_Load(object sender, System.EventArgs e)
        {
            _client.OnReveieveData += _client_OnReveieveData;
            PrivateContentRtb.Focus();
        }

        private void _client_OnReveieveData(Model.ReceieveMessage message)
        {
            switch (message.Action)
            {
                case (int)CommandType.PrivateChat:
                    //IList<OnlineListResult> infos = JsonHelper.DeserializeObj<List<OnlineListResult>>(message.DataStr);
                    //this.Invoke(new Action(() =>
                    //{
                    //    this.messageList.AppendText(message.DataStr);
                    //    userListShow(infos);
                    //}));
                    break;
                default:
                    break;
            }
        }

        private void PrivateContentRtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                SendPrivateMsg();
            }
        }

        private void SendPrivateMsg()
        {
            string msg = PrivateContentRtb.Text.Trim();
            if (msg != "")
            {
                PrivateChatRequest request = new PrivateChatRequest();
                request.guid = Guid.NewGuid().ToString();
                request.msg = msg;
                request.receivename = _userName;
                request.sendname = GlobalVariable.LoginUserInfo.DisplayName;
               
                GlobalVariable.client.Send_PrivateChat(request);
                GlobalVariable.AddPrivateChatToChatList(_userName, GlobalVariable.LoginUserInfo.DisplayName, msg);
                PrivateContentRtb.Text = "";
                PrivateHistRtb.AppendText(request.sendname + " "
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + request.msg + "\r\n\r\n");
            }
        }


        private void SendGroupMsg()
        {
            string msg = PrivateContentRtb.Text.Trim();
            if (msg != "")
            {
                GlobalVariable.client.Send_GroupChat(
                    GlobalVariable.LoginUserInfo.DisplayName, msg);
            }
        }

        private void PrivateSendBtn_Click(object sender, System.EventArgs e)
        {
            SendPrivateMsg();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SendGroupMsg();
        }
    }
}
