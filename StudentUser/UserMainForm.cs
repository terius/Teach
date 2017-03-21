using Helpers;
using Model;
using System;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class UserMainForm : Form
    {
        
        Cls.UserActivityHook actHook;
        private  BlackScreen bsForm = null;
        private delegate void DoSomething();
        // MyTcpClient client;
        ViewRtsp videoPlayer;
        public UserMainForm()
        {
            InitializeComponent();
        }

        private void UserMainForm_Load(object sender, System.EventArgs e)
        {
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
        

            //string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            //var player = new VlcPlayerBase(pluginPath);
            //player.SetRenderWindow((int)this.Handle);//panel
            //player.LoadFile("d:\\1.mkv");//视频文件路径
        }

        



        private void Client_OnReveieveData(ReceieveMessage message)
        {

            switch (message.Action)
            {
                case 7:
                    ScreenInteract_Response resp = JsonHelper.DeserializeObj<ScreenInteract_Response>(message.DataStr);
                    showViewRtsp(resp.url);
                    break;
                case 11:
                    LockScreenReponse lsresp = JsonHelper.DeserializeObj<LockScreenReponse>(message.DataStr);
                    // BlockInput(true);
                    LockScreen();
                    break;
                default:
                    break;
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
            actHook = new Cls.UserActivityHook();
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            //actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
            //actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            actHook.Start();
          
            this.BeginInvoke(new Action(() =>
            {
                BlackScreen frm = new BlackScreen();
                frm.Show();
                bsForm = frm;
            }));

        }

        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            LockScreen();
        }
    }
}
