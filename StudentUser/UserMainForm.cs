using CCWin;
using Common;
using Helpers;
using Model;
using SharedForms;
using System;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class UserMainForm : CSkinBaseForm
    {

        Cls.UserActivityHook actHook;
        private BlackScreen bsForm = null;
        private delegate void DoSomething();
        // MyTcpClient client;
        ViewRtsp videoPlayer;
        public UserMainForm()
        {
            InitializeComponent();
       
        }

     

        private void UserMainForm_Load(object sender, System.EventArgs e)
        {
        
            Text = GlobalVariable.LoginUserInfo.DisplayName;
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
         

            //string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            //var player = new VlcPlayerBase(pluginPath);
            //player.SetRenderWindow((int)this.Handle);//panel
            //player.LoadFile("d:\\1.mkv");//视频文件路径
        }





        private void Client_OnReveieveData(ReceieveMessage message)
        {
            appendMsg(JsonHelper.SerializeObj(message));
            switch (message.Action)
            {
                case 7:
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    showViewRtsp(resp.url);
                    break;
                case 11:
                    // LockScreenReponse lsresp = JsonHelper.DeserializeObj<LockScreenReponse>(message.DataStr);
                    // BlockInput(true);
                    LockScreen();
                    break;
                case 12:
                    StopLockScreen();
                    break;

                case (int)CommandType.PrivateChat:
                  
                    break;
                default:
                    break;
            }
        }


        private void appendMsg(string msg)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.richTextBox1.AppendText(msg+"\r\n");

                }));
            }
            else
            {
                this.richTextBox1.AppendText(msg + "\r\n");

            }
        }






        private void showViewRtsp(string rtsp)
        {
            // throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                videoPlayer = new ViewRtsp(rtsp);
                videoPlayer.Show();
                //  videoPlayer = f;
                videoPlayer.startPlay();
            }));
        }

        /// <summary>
        /// 锁屏（禁止鼠标和键盘)
        /// </summary>
        private void LockScreen()
        {
            //  actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            //actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            //actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            //    actHook.Start();

            this.BeginInvoke(new Action(() =>
            {
                BlackScreen frm = new BlackScreen();
                frm.Show();
                bsForm = frm;
            }));

        }

        /// <summary>
        /// 撤销锁屏
        /// </summary>
        private void StopLockScreen()
        {
            if (actHook != null)
            {
                actHook.Stop();
            }
            this.BeginInvoke(new Action(() =>
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "BlackScreen")
                    {
                        frm.Close();
                        break;
                    }
                }
            }));
        }

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            LockScreen();
        }

        private void btnStopLockScreen_Click(object sender, EventArgs e)
        {
            StopLockScreen();
        }

      

        private void UserMainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
        }

      
    }
}
