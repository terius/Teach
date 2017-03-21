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
    public partial class CallTheRoll : Form
    {
        public CallTheRoll()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, EventArgs e)//开始点名
        {
            MainForm.beingCallTheRoll = true;
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.callTheRoll;
            msg.time = System.DateTime.Now.ToString();
            // msg.content = "ls";
            MainForm.clientConnect.BeginSendMessage(msg);
           // this.CallTheRollToolStripMenuItem.Enabled = false;
        }

        private void stop_btn_Click(object sender, EventArgs e)//停止点名
        {

        }
    }
}
