using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TcpConnectJson;
using TeacherUser.InformationInter;




namespace TeacherUser
{
    public partial class MainForm : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public static ClientConnectTcp clientConnect=null; //定义一个客户端连接对象
        public TcpClient tcpclient;

        public static string IP = ConfigurationManager.AppSettings["serverIP"];
        public static IPAddress serverIP = IPAddress.Parse(IP);
        public static int serverPORT=8088;
        public string role = UserRole.teacher;
        public static List<UserInfm> userlist = null;
        public static int userCount = 0;
        GroupChat gcForm=null;
        public static VideoChat vcForm = null;
        public static ImageList imgList = null;
        private bool allowClassChat = false;
        //private ScreenMonitor sm = null;
        private ScreenInteract si = null;
        private string stuIPforInteract = null;
        private int stuPortforInteract = -1;


        private ViewRtsp vrForm = null;
        private string rtspAddress = null;
        public static bool beingCallTheRoll = false;//
        public static bool beingScreenBroadcast = false;//正在屏幕广播
        public static bool beingWatching = false;//正在查看学生端

       //存储打开的子窗体
        public  List<ChatForm> chatFormList = new List<ChatForm>();
        //定义委托和事件用来显示提示信息
        private delegate void messageListCallback(string content);
        private messageListCallback messageCallback;
        //定义委托和事件用来显示提示信息
        private delegate void userListCallback(string deviceType,string role,string ip,string port);
        private event userListCallback userCallback;
        //定义委托和事件用来显示提示信息
        private delegate void userOffCallback( string ip, string port);
        private userOffCallback userOfflineCallback;
        private delegate void DoSomething();

        TcpConnectJson.ScreenMonitor screenmonitor;

        public delegate void createUserControl_dl(string ip, int port);
        public delegate void removeUserControl_dl(string ip, int port);
        List<UserControl1> list_UC = new List<UserControl1>();

        // 定义节点
        private IPEndPoint ipEndPoint = null;
        // 定义UDP发送和接收
        private UdpClient udpReceive = null;
        // 定义端口
        private const int listenPort = 10000;
        UdpState udpReceiveState = null;
        // 异步状态同步
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);
        bool flag = true;  //ReceiveMeg函数开始标记
     




        public MainForm()
        {
             InitializeComponent();
             messageCallback = new messageListCallback(setMessage); //绑定信息提示事件函数
             userCallback += userListShow;//z这边写出函数名以后，可以自动生成相应的函数（函数参数与相应的委托声明相同）
             userOfflineCallback += userOffline;
            clientConnect = new ClientConnectTcp();
            clientConnect.ServerConnected += clientConnect_ServerConnected;
            clientConnect.ServerConnectFailed += clientConnect_ServerConnectFailed;
            clientConnect.MessageReceived += clientConnect_MessageReceived;
            clientConnect.ServerLost += clientConnect_ServerLost;
            imgList = this.imageList1;     
            // 本机节点
            ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            //remoteEP = new IPEndPoint(IPAddress.Parse("172.26.162.212"), remotePort);
            // 实例化
            udpReceive = new UdpClient(ipEndPoint);
            // 实例化udpReceiveState
            udpReceiveState = new UdpState();
            udpReceiveState.udpClient = udpReceive;
            udpReceiveState.ipEndPoint = ipEndPoint;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.messageList.Hide();
            this.timer1.Interval = 1000;
            this.timer1.Start();
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            this.listView1.SmallImageList = imgList;
            this.listView1.Columns.Add("设备", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("身份", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("IP地址", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("端口号", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("禁止私聊", 90, HorizontalAlignment.Left);
            this.listView1.Columns.Add("禁止群聊", 90, HorizontalAlignment.Left);
            asc.controllInitializeSize(this);
            string screenState = ConfigurationManager.AppSettings["screenState"];
            clientConnect.ConnectToServer(serverIP, serverPORT, role, screenState);//连接服务器
        }
        //显示用户列表
        private void userListShow(string deviceType, string role, string ip, string port)
        {
            switch (deviceType)
            { 
                case "COMPUTER":
                    this.listView1.Items.Add("计算机");
                    this.listView1.Items[userCount].SubItems.Add(role);
                    this.listView1.Items[userCount].SubItems.Add(ip);
                    this.listView1.Items[userCount].SubItems.Add(port);
                    this.listView1.Items[userCount].SubItems.Add("否");
                    this.listView1.Items[userCount].SubItems.Add("否");
                    this.listView1.Items[userCount].ImageIndex = 0;
                    userCount++;
                    break;
                case "ANDROID":
                    this.listView1.Items.Add("移动端");
                    this.listView1.Items[userCount].SubItems.Add(role);
                    this.listView1.Items[userCount].SubItems.Add(ip);
                    this.listView1.Items[userCount].SubItems.Add(port);
                    this.listView1.Items[userCount].ImageIndex = 1;
                    this.listView1.Items[userCount].SubItems.Add("否");
                    this.listView1.Items[userCount].SubItems.Add("否");
                    userCount++;
                    break;
            }
        }

//用户下线
        private void userOffline(string ip, string port)
        {
           int total=listView1.Items.Count;
           if(total>=2)//教师端肯定在线
           {
               for(int i=0;i<total;i++)
                {
                    if(ip==listView1.Items[i].SubItems[2].Text&&port==listView1.Items[i].SubItems[3].Text)
                    {
                        listView1.Items.RemoveAt(i);
                            break;
                    }   
                }
               for (int i = 0; i < total; i++)
               {
                   if (ip ==userlist[i].ip && port == userlist[i].port.ToString())
                   {
                       userlist.RemoveAt(i);
                       break;
                   }
               }
               userCount--;      
            }   
        }

 

//窗体大小自适应
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
                notifyIcon1.Visible = true;  //托盘图标可见
            }       
            asc.controlAutoSize(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.ScreenBroadcastToolStripMenuItem.Text == "关闭广播")
                {
                    DialogResult r = MessageBox.Show("屏幕广播尚未关闭，确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if(rtspAddress!=null)
                        si.stopScreenInteract();
                        if (clientConnect != null)
                        {
                            clientConnect.ServiceClose();//用户退出程序时，释放连接
                            clientConnect = null;
                        }
                        System.Environment.Exit(0);
                    }
                }
                else {
                    DialogResult r = MessageBox.Show("确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r != DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (clientConnect != null)
                        {
                            clientConnect.ServiceClose();//用户退出程序时，释放连接
                            clientConnect = null;
                        }
                        System.Environment.Exit(0);
                    }     
                }              
            }
        }

//主界面实时显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel3.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //注意小时的hh和HH不同，HH是24小时制
        }


    
//双击右下角小图标时，恢复大窗口
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
                notifyIcon1.Visible = false;  //托盘图标隐藏
            }
        }

      

       
//教师端成功连接服务器
        void clientConnect_ServerConnected(TcpClient tclient)
        {
            messageList.Invoke(messageCallback, string.Format("与服务器:{0}连接成功", tclient.Client.RemoteEndPoint));
            this.tcpclient = tclient;
            string temp = ((IPEndPoint)tcpclient.Client.LocalEndPoint).ToString();
            int i = temp.IndexOf(':');
            _localIP=temp.Substring(0, i);
            _localPort = ((IPEndPoint)tcpclient.Client.LocalEndPoint).Port;
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.userList;
            msg.time = System.DateTime.Now.ToString();
            clientConnect.BeginSendMessage(msg);
           // sm = new ScreenMonitor(clientConnect, IP, _localIP, _localPort);
            si = new ScreenInteract(clientConnect, IP, _localIP, _localPort);
            screenmonitor = new TcpConnectJson.ScreenMonitor(clientConnect, IP, _localIP, _localPort);
        }



//教师端连接服务器失败
        void clientConnect_ServerConnectFailed(string error)
        {
            messageList.Invoke(messageCallback, string.Format("与服务器连接失败:{0}", error));
        }

//对接收消息的处理函数
        void clientConnect_MessageReceived(TcpConnectJson.Messages msg)
        {
            messageList.Invoke(messageCallback, string.Format("{0}:{1}:{2}", tcpclient.Client.RemoteEndPoint, msg.order, msg.content));
            switch (msg.order)
            {
                case OrderBySev.loginRepeatShutdown:  //教师端重复登录
                    this.BeginInvoke(new DoSomething(delegate()
                    {
                        MessageBox.Show("当前教师端已有多个!您将被迫下线","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        Application.Exit();
                    }));
                    break;
                case OrderByStu.alreadyPushVideo://监视学生端
                    //MessageBox.Show("教师端收到命令");
                    this.BeginInvoke(new DoSomething(delegate()
                    {
                        ViewRtsp f = new ViewRtsp(msg.content,screenmonitor,msg.ipSend,msg.portSend);
                        //Thread th = new Thread(new ThreadStart(f.Show));
                        //th.Start();
                        vrForm = f;
                        f.Show();
                        f.startPlay();
                    }));
                    break;
                case OrderByStu.prepareForInteract://学生演示
                    showViewRtsp(msg.content);
                    break;
                case OrderByTec.stopStudentInteract://停止学生演示
                    this.Invoke(new Action(() =>
                    {
                        if (vrForm != null)
                        {
                            vrForm.Close();
                            vrForm = null;
                        }
                    })); 
                    break;
                case OrderBySev.requirePlaySucceed:
                  
                    break;
                case OrderByStu.signIn:

                    break;
                case OrderByStu.acceptVideoCall:
                    messageList.Invoke(messageCallback, string.Format("role:{0}", "对方接受视话请求！"));
                    vcForm.receiveAccpet(msg.content);
                    break;
                case OrderByStu.refuseVideoCall:
                    messageList.Invoke(messageCallback, string.Format("role:{0}", "对方拒绝视话请求！"));
                    vcForm.requireRefused();
                    break;
                case OrderBySev.studentConnect:
             
                  //  UserInfm userOnline= JsonConvert.DeserializeObject<UserInfm>(msg.content);                   
                  //-----------------------------------------------------------               
                    int index = msg.content.IndexOf(":");
                    int indexScreenState = msg.content.LastIndexOf(":");
                    string screenState = msg.content.Substring(indexScreenState + 1);
                    string deviceType = msg.content.Substring(index+1,indexScreenState-index-1);
                   // MessageBox.Show(screenState);

                    UserInfm newUser = new UserInfm(msg.ipSend, msg.portSend);
                    newUser.deviceType = deviceType;
                    newUser.role = msg.clientStyle;
                    userlist.Add(newUser);
                    messageList.Invoke(messageCallback, string.Format("role:{0},deviceType:{1},ip:{2},port:{3}", msg.clientStyle,deviceType,msg.ipSend,msg.portSend));
                    listView1.Invoke(userCallback, deviceType, msg.clientStyle, msg.ipSend, msg.portSend.ToString());
                    if (deviceType == "COMPUTER")
                    {
                        //Mre.WaitOne();
                        /*
                        if (screenState == "1")
                        {
                            Messages msgBlock = new Messages();
                            msgBlock.clientStyle = UserRole.teacher;
                            msgBlock.order = OrderByTec.forbidMouseKb;
                            msgBlock.time = System.DateTime.Now.ToString();
                            msgBlock.ipReceive = msg.ipSend;
                            msgBlock.portReceive = msg.portSend;
                            clientConnect.BeginSendMessage(msg);
                        }
                         * */
                        this.Invoke(new createUserControl_dl(create_UserControl), new object[] { msg.ipSend, msg.portSend });
                        if (flag)
                        {
                            Thread t = new Thread(new ThreadStart(ReceiveMsg));
                            t.Start();
                            flag = false;
                        }                       
                    }
                   

                    //userlist.Add(new UserInfm(msg.ipSend, msg.portSend));
                    if (rtspAddress != null)
                    {
                        Messages videoMsg = new Messages();
                        videoMsg.clientStyle = UserRole.teacher;
                        videoMsg.order = OrderByTec.requireSomeonePlayVideo;
                        videoMsg.time = System.DateTime.Now.ToString();
                        videoMsg.ipReceive = msg.ipSend;//学生端ip
                        videoMsg.portReceive = msg.portSend;//学生端port
                        videoMsg.ipSend = _localIP;
                        videoMsg.portSend = _localPort;
                        videoMsg.content = rtspAddress;
                        //videoMsg.content = "123";
                        clientConnect.BeginSendMessage(videoMsg);
                    }
                    if (beingCallTheRoll)
                    {
                        Messages signInMsg = new Messages();
                        signInMsg.clientStyle = UserRole.teacher;
                        signInMsg.order = OrderByTec.requireSomeoneSignin;
                        signInMsg.time = System.DateTime.Now.ToString();
                        signInMsg.ipReceive = msg.ipSend;//学生端ip
                        signInMsg.portReceive = msg.portSend;//学生端port
                        signInMsg.ipSend = _localIP;
                        signInMsg.portSend = _localPort;
                        //videoMsg.content = "123";
                        clientConnect.BeginSendMessage(signInMsg);
                    }
                    break;
                case OrderBySev.studentLost:
                    messageList.Invoke(messageCallback, string.Format("role:{0},ip:{1},port:{2}", msg.clientStyle,msg.ipSend,msg.portSend));
                    
                    if (this.vrForm != null)
                    {
                        string [] s=msg.ipSend.Split('.');
                        string ipPort="";
                        foreach (string i in s)
                            ipPort += i;

                        ipPort += msg.portSend.ToString();
                        string rtspAddr = vrForm.playAddress;
                        int index1 = rtspAddr.LastIndexOf('/');
                        int index2 = rtspAddr.LastIndexOf('.');
                        int len = index2 - index1;
                        string total=rtspAddr.Substring(index1+1, len);
                        string source = " ";
                        for (int i = 0; i < total.Length; i++)
                        {
                            if (total[i] >= '0' && total[i] <= '9')
                                source += total[i];
                        }
                        if (ipPort .Equals(source.Trim()))
                        {
                            vrForm.Close();
                        }
                   }
                    this.Invoke(new removeUserControl_dl(remove_UserControl), new object[] { msg.ipSend, msg.portSend });
                    listView1.Invoke(userOfflineCallback, msg.ipSend, msg.portSend.ToString());
                    break;
                 //获取用户列表
                case OrderByTec.userList:                 
                       // userlist = new List<UserInfm>();
                        userlist = JsonConvert.DeserializeObject<List<UserInfm>>(msg.content);
                        messageList.Invoke(messageCallback, string.Format("userCount:{0}", userlist.Count));
                        if (userlist.Count > 0)
                        {
                            for (int i = 0; i < userlist.Count; i++)
                            {
                                UserInfm user = userlist[i];
                                messageList.Invoke(messageCallback, string.Format("role:{0},name:{1},device:{2},ip:   {3},port:{4}", user.role, user.name, user.deviceType, user.ip, user.port));
                                listView1.Invoke(userCallback, user.deviceType, user.role, user.ip, user.port.ToString());
                                if (user.deviceType == "COMPUTER" && user.role=="STUDENT")
                               {
                                this.Invoke(new createUserControl_dl(create_UserControl), new object[] { user.ip, user.port });
                                if (flag == true)
                                {
                                    flag = false;
                                    Thread t = new Thread(new ThreadStart(ReceiveMsg));
                                    t.Start();
                                }
                            }
                          }
                        }        
                    break;
                case OrderByTec.privateChat:
                    {
                        messageList.Invoke(messageCallback, string.Format("ipSend:{0},portSend:{1},content:{2}", msg.ipSend, msg.portSend, msg.content));
                        {
                            foreach (ChatForm cf in chatFormList)
                            {
                                if ((cf._ip == msg.ipSend) && (cf._port == msg.portSend))
                                {
                                        if (msg.type.Equals(MessType.picture))//发送图片
                                        {
                                            cf._cform.setPicture(msg.ipSend, msg.portSend, msg.content);
                                        }
                                        if (msg.type.Equals(MessType.video))//发送语音
                                        {


                                        }
                                        if (msg.type.Equals(MessType.text))//
                                        {
                                            cf._cform.RecvMess(msg.ipSend, msg.portSend, msg.content);
                                        }
                                } 
                            }
                        }
                    }
                    break;
                case OrderByTec.groupChat:
                    {
                        messageList.Invoke(messageCallback, string.Format("ipSend:{0},portSend:{1},content:{2}", msg.ipSend, msg.portSend, msg.content));
                        switch (msg.type)
                        {
                            case MessType.picture:
                                gcForm.setPicture(msg.ipSend, msg.portSend, msg.content);
                                break;
                            case MessType.voice:
                                gcForm.setVoice(msg.ipSend, msg.portSend, msg.content);
                                break;
                            default:
                                gcForm.setMessage(msg.ipSend, msg.portSend, msg.content);
                                messageList.Invoke(messageCallback, string.Format("{0}:{1}:{2}", msg.ipSend, msg.portSend, msg.content));
                                break;
                        }
                    }
                 break;
                case OrderBySev.groupSucceed:
                    this.Invoke(new Action(() =>    
                    {
                        MessageBox.Show("分组成功！");
                    })); 
                 break;
                case OrderByStu.privateLetter:
                 this.Invoke(new Action(() =>
                 {
                     PrivateLetter f = new PrivateLetter(msg.ipSend,msg.portSend,msg.content,this.chatFormList,this);
                     f.Show();
                     messageList.Invoke(messageCallback, string.Format("{0}:{1}:{2}", msg.ipSend, msg.portSend, msg.content));
                 }));
                 break;     
            }          
        }

//播放视频
        private void showViewRtsp(string rtspAddess)
        {
            //throw new NotImplementedException();
            this.Invoke(new Action(() =>
            {
                ViewRtsp f = new ViewRtsp(rtspAddess);
                f.Show();
                vrForm = f;
                f.startPlay();
            }));
        }   

//与服务器连接断开
        void clientConnect_ServerLost(TcpClient tclient)
        {
            messageList.Invoke(messageCallback, string.Format("与服务器连接丢失"));
        }

//显示提示信息
        public void setMessage(string content)//
        {
            if (content != null)
            {
                messageList.AppendText(content + "\n");
            }
            else
            {
                messageList.AppendText("");
            }
        }


//课堂点名
        private void CallTheRollToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /*
            beingCallTheRoll = true;
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.callTheRoll;
            msg.time = System.DateTime.Now.ToString();
           // msg.content = "ls";
            clientConnect.BeginSendMessage(msg);
            this.CallTheRollToolStripMenuItem.Enabled = false;
            */
            CallTheRoll form = new CallTheRoll();
            form.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            form.Show();
            this.CallTheRollToolStripMenuItem.Enabled = false;           
        }

//分组讨论
        private void TeamDisussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamDiscuss form = new TeamDiscuss();
            form.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            form.Show();
        }

//查看分组
        private void TeamViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamView form = new TeamView();
            form.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            form.Show();
        }

//文件分发
        private void FileDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDispatch form = new FileDispatch();
            form.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            form.Show();
        }

        private void FileShareToolStripMenuItem_Click(object sender, EventArgs e)//文件共享
        {       
            System.Diagnostics.Process.Start("Explorer.exe", "ftp://" + ConfigurationManager.AppSettings["serverIP"]);//****************************************
        }

//账号管理
        private void UserManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage form = new UserManage();
            form.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            form.Show();
        }

        private void StudentOperateToolStripMenuItem_Click(object sender, EventArgs e)//学生演示
        {
         
        }


        public static void showTip()//如果教师端同时操作视频广播和学生端大窗口监控，则给出提示
        {
            showTipForm f = new showTipForm();
            f.Show();
        }
//屏幕广播
        private void ScreenBroadcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = this.ScreenBroadcastToolStripMenuItem.Text;
            if (text == "屏幕广播")
            {
                if (!beingWatching)
                {
                    rtspAddress = si.beginScreenInteract();
                    this.ScreenBroadcastToolStripMenuItem.Text = "关闭广播";
                    beingScreenBroadcast = true;
                }
                else
                {
                    showTip();
                    return;
                }            
            }
            else
            {
                si.stopScreenInteract();
                this.ScreenBroadcastToolStripMenuItem.Text = "屏幕广播";
                rtspAddress = null;
                beingScreenBroadcast = false;
            }       
        }
 //右键菜单 私聊
        private void PrivateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrivateChat f = null;
            string ipRecv=this.listView1.SelectedItems[0].SubItems[2].Text;
            int portRecv=Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);                      
             this.Invoke(new Action(() =>
             {
                 if (this.chatFormList.Count != 0)
                 {
                     foreach (ChatForm cf in chatFormList)
                     {
                         if ((cf._ip == ipRecv) && (cf._port == portRecv))
                         {
                             f = cf._cform;
                             if (cf._cform.WindowState == FormWindowState.Minimized)
                             {
                                 cf._cform.WindowState = FormWindowState.Normal;//如果私聊窗体的当前状态是最小化，则将其调整到正常状态
                                 cf._cform.BringToFront();//将相应的私聊窗体置顶显示(前提是窗体不能处于最小化状态)
                             }
                         }
                     }
                     if (f == null)
                     {
                         f = new PrivateChat(ipRecv, portRecv, this);
                         f.Show();
                     }
                 }
                 else {
                     f = new PrivateChat(ipRecv, portRecv, this);
                     f.Show();  
                 }
             }));        
        }

//班级群聊
        private void GroupChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.GroupChatToolStripMenuItem.Enabled = false;
            GroupChat f = new GroupChat();
            f.StartPosition = FormStartPosition.CenterScreen;//窗口居中显示
            f.Show();
            gcForm = f;
            allowClassChat = true;
        }

 //保存签到
        private void SaveSignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls|txt文件(*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int i = sfd.FileName.LastIndexOf('.');
                string ext = sfd.FileName.Substring(i);
                switch (ext)
                {
                    case ".xls":
                        ExportToExcel(this.listView1, sfd.FileName);
                        break;
                    case ".txt":
                        ExportToTXT(this.listView1, sfd.FileName);
                        break;
                }
            }          
        }


//导出到TXT
        public void ExportToTXT(ListView listView, string strFileName)
        {         
            System.IO.StreamWriter sw = new System.IO.StreamWriter(strFileName, false, System.Text.Encoding.GetEncoding("gb2312"));
            try
            {
                int len = 0;
                string line = "";
                string temp = "";
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    temp = listView.Columns[i].Text;
                    len = 30 - Encoding.Default.GetByteCount(temp) + temp.Length; //考虑中英文的情况
                    temp = temp.PadRight(len, ' ');//左对齐此字符串中的字符，在右边用空格或指定的 Unicode 字符填充以达到指定的总长度。
                    line += temp;
                }
                sw.WriteLine(line);//先写入列标题
                line = "";
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    for (int j = 0; j < listView.Items[i].SubItems.Count; j++)
                    {
                        temp = listView.Items[i].SubItems[j].Text;
                        len = 30 - Encoding.Default.GetByteCount(temp) + temp.Length;
                        temp = temp.PadRight(len, ' ');
                        line += temp;
                    }
                    sw.WriteLine(line);
                    line = "";
                }
                sw.Flush();
            }
            finally
            {
                if (sw != null) sw.Close();
                MessageBox.Show("保存成功！");   
            }  
        }


    /// <summary>
    /// 具体导出的方法
    /// </summary>
    /// <param name="listView">ListView</param>
    /// <param name="strFileName">导出到的文件名</param>
        private void ExportToExcel(ListView listView, string strFileName)
        {         
            //int rowNum = listView.Items.Count;//数据行数（不包括列标题行）
            //int columnNum = listView.Items[0].SubItems.Count;//列数
            //int rowIndex = 1;
            //int columnIndex = 0;
            //if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            //{
            //    return;
            //}
            //if (rowNum > 0)
            //{
            //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //    if (xlApp == null)
            //    {
            //        MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
            //        return;
            //    }
            //    xlApp.DefaultFilePath = "";
            //    xlApp.DisplayAlerts = true;
            //    xlApp.SheetsInNewWorkbook = 1;
            //    // xlApp.Visible = true;
            //    Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
            //    //将ListView的列名导入Excel表第一行（列标题）
            //    foreach (ColumnHeader dc in listView.Columns)
            //    {
            //        columnIndex++;
            //        xlApp.Cells[rowIndex, columnIndex] = dc.Text;
            //    }
            //    //将ListView中的数据导入Excel中
            //    for (int i = 0; i < rowNum; i++)
            //    {
            //        rowIndex++;
            //        columnIndex = 0;
            //        for (int j = 0; j < columnNum; j++)
            //        {
            //            columnIndex++;
            //            //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
            //            xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
            //        }
            //    }
            //    //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
            //    xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //    xlApp = null;
            //    xlBook = null;
            //    MessageBox.Show("保存成功！");
            //}          
        }




        public static string _localIP { get; set; }
        public static int _localPort { get; set; }

 //屏幕肃静或解除  
        private void ScreenSlientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string orderStr= ScreenSlientToolStripMenuItem.Text;
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            if (orderStr == "屏幕肃静")
            {
                msg.order = OrderByTec.blackScreen;
                ScreenSlientToolStripMenuItem.Text = "解除屏幕肃静";
            }
            else
            {
                msg.order = OrderByTec.reliefBlackScreen;
                ScreenSlientToolStripMenuItem.Text = "屏幕肃静";
           
            }
            msg.time = System.DateTime.Now.ToString();
            msg.ipReceive = "ALL";
           // msg.portReceive = portRecv;
            clientConnect.BeginSendMessage(msg);
        }
//禁用鼠标键盘或解除
        private void MouseKeyboardMenuItem_Click(object sender, EventArgs e)
        {
            string orderStr =this.MouseKeyboardMenuItem.Text;
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            if (orderStr == "禁用鼠标键盘")
            {
                msg.order = OrderByTec.forbidMouseKb;
                MouseKeyboardMenuItem.Text = "允许鼠标键盘";
            }
            else
            {
                msg.order = OrderByTec.reliefForbidMouseKb;
                MouseKeyboardMenuItem.Text = "禁用鼠标键盘";
            }
            msg.time = System.DateTime.Now.ToString();
            msg.ipReceive = "ALL";
            // msg.portReceive = portRecv;
            clientConnect.BeginSendMessage(msg);
        }
//右键菜单 禁止私聊
        private void forbidPrivateChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ipRecv = this.listView1.SelectedItems[0].SubItems[2].Text;
            int portRecv = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
            this.Invoke(new Action(() =>
            {
                PrivateChat f = null;
                if (this.chatFormList.Count != 0)
                {
                    foreach (ChatForm cf in chatFormList)
                    {
                        if ((cf._ip == ipRecv) && (cf._port == portRecv))
                        {
                            f = cf._cform;                           
                        }
                    }
                    if (f != null)
                    {
                        Messages msg = new Messages();
                        msg.clientStyle = UserRole.teacher;
                        msg.order = OrderByTec.forbidPrivateChat;
                        msg.time = System.DateTime.Now.ToString();
                        msg.ipReceive = ipRecv;
                        msg.portReceive = portRecv;
                        clientConnect.BeginSendMessage(msg);
                        //f.Close();//关闭与对方建立的私聊窗体
                        //this.forbidPrivateChatToolStripMenuItem.Text = "允许私聊";
                        //this.listView1.SelectedItems[0].ImageIndex=2;
                        this.listView1.SelectedItems[0].SubItems[4].Text="是";
                        f.setState("已禁止对方私聊!");
                    }
                }
                else
                {
                    MessageBox.Show("未与对方建立私聊！");
                }
            }));
        }
//右键菜单 禁止群聊
        private void forbidGroupChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowClassChat)//判断班级群聊是否开启
            {
                string ipRecv = this.listView1.SelectedItems[0].SubItems[2].Text;
                int portRecv = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
                Messages msg = new Messages();
                msg.clientStyle = UserRole.teacher;
                msg.order = OrderByTec.forbidGroupChat;
                msg.time = System.DateTime.Now.ToString();
                msg.ipReceive = ipRecv;
                msg.portReceive = portRecv;
                clientConnect.BeginSendMessage(msg);
            }
            else
            {
                MessageBox.Show("班级群聊未开启！");
            }        
        }

        private void ScreenRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopformForScreenCap f = new PopformForScreenCap(this);
            f.Show();
            this.ScreenRecordToolStripMenuItem.Enabled = false;
        }

        private void HomeworkCollectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void remove_UserControl(string ip,int port)
        {
            UserControl1 uc;
            if (list_UC.Count > 0)
            {
                for (int i = 0; i < list_UC.Count; i++)
                {
                    uc = list_UC[i];
                    if (uc.Name == ip+ port.ToString())
                    {
                        list_UC.Remove(uc);
                        this.flowLayoutPanel1.Controls.Remove(uc);
                    }
                }
            }
        }
        public void create_UserControl(string ip, int port)
        {
            UserControl1 Uc1 = new UserControl1(screenmonitor, ip, port);
            string info = ip + ":"+port.ToString();
            string path = "welcome.jpg";
            Uc1.Set(info, path);
            Uc1.Name = ip + port.ToString();
            flowLayoutPanel1.Controls.Add(Uc1);
            list_UC.Add(Uc1);
        }
        public void ReceiveMsg()
        {
            while (true)
            {
                lock (this)
                {
                    // 调用接收回调函数
                    try
                    {
                        IAsyncResult iar = udpReceive.BeginReceive(new AsyncCallback(ReceiveCallback), udpReceiveState);
                        receiveDone.WaitOne();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("接收消息："+e.ToString());
                    }
                    Thread.Sleep(200);
                }
            }
        }
 // 接收回调函数
        private void ReceiveCallback(IAsyncResult iar)
        {
            UdpState udpReceiveState = iar.AsyncState as UdpState;
            if (iar.IsCompleted)
            {
                Byte[] receiveBytes = udpReceiveState.udpClient.EndReceive(iar, ref udpReceiveState.ipEndPoint);

                Thread th = new Thread(new ParameterizedThreadStart(Show));
                th.Start(receiveBytes);

                //Thread.Sleep(200);
                receiveDone.Set();
            }
        }
        public void Show(object ReceiveBytes)
        {
            try
            {
                byte[] receiveBytes = (byte[])ReceiveBytes;

                byte[] packet_length = new byte[4];
                byte[] ip_length = new byte[4];
                byte[] rec_port = new byte[4];

                Array.Copy(receiveBytes, 0, packet_length, 0, 4);
                Array.Copy(receiveBytes, 4, ip_length, 0, 4);

                int PacketLength = System.BitConverter.ToInt32(packet_length, 0);
                int Ip_length = System.BitConverter.ToInt32(ip_length, 0);
                int pic_length = PacketLength - 12 - Ip_length;

                byte[] rec_pic = new byte[pic_length];
                byte[] rec_ip = new byte[Ip_length];
                Array.Copy(receiveBytes, 8, rec_ip, 0, Ip_length);
                Array.Copy(receiveBytes, 8 + Ip_length, rec_port, 0, 4);
                Array.Copy(receiveBytes, 12 + Ip_length, rec_pic, 0, pic_length);

                string IP = System.Text.Encoding.ASCII.GetString(rec_ip);
                int PORT = System.BitConverter.ToInt32(rec_port, 0);

                //MessageBox.Show(PacketLength.ToString());

                MemoryStream ms = new MemoryStream(rec_pic);
                Image image = Image.FromStream(ms);
                //将图片显示出来
                UserControl1 Uc;
                if (list_UC.Count > 0)
                {
                    for (int i = 0; i < list_UC.Count; i++)
                    {
                        Uc = list_UC[i];
                        if (Uc.Name == IP + PORT.ToString())
                        {
                            Uc.set_PictureBox(image);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("显示图片"+e.ToString());
            }
        }
//右键菜单执行学生演示
        private void StudentInteractToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // string stuIP = this.listView1.SelectedItems[0].SubItems[2].Text;
            //int stuPort= Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
            stuIPforInteract = this.listView1.SelectedItems[0].SubItems[2].Text;
            stuPortforInteract = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
            si = new ScreenInteract(clientConnect,IP,_localIP,_localPort);
            si.orderStudentScreenInteract(stuIPforInteract, stuPortforInteract);

        }

        private void StopStudentInteractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            si.stopStudentScreenInteract(stuIPforInteract,stuPortforInteract);
            stuIPforInteract = null;
            stuPortforInteract = -1;
        }

        private void ScreenLockToolStripMenuItem1_Click(object sender, EventArgs e)//**********   
        {
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.forbidMouseKb;          
            msg.time = System.DateTime.Now.ToString();
            //msg.ipReceive = "ALL";
            string ipRecv = this.listView1.SelectedItems[0].SubItems[2].Text;
            int portRecv = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
            msg.ipReceive = ipRecv;
            msg.portReceive = portRecv;
            clientConnect.BeginSendMessage(msg);
        }


        

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void screenCapStop()
        {
            this.ScreenRecordToolStripMenuItem.Enabled = true;
        }
//右键菜单解除鼠标键盘限制
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages();
            msg.clientStyle = UserRole.teacher;
            msg.order = OrderByTec.reliefForbidMouseKb;//
            msg.time = System.DateTime.Now.ToString();
            //msg.ipReceive = "ALL";
            string ipRecv = this.listView1.SelectedItems[0].SubItems[2].Text;
            int portRecv = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[3].Text);
            msg.ipReceive = ipRecv;
            msg.portReceive = portRecv;
            clientConnect.BeginSendMessage(msg);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void VideoPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    public class ChatForm
    {
        public string _ip { get; set; }
        public int _port { get; set; }
       // public newPrivateChat _cform { get; set; }
        public PrivateChat _cform { get; set; }
        public ChatForm(string ip, int port, PrivateChat form)
        {
            this._ip = ip;
            this._port = port;
            this._cform = form;
        }     
    }
    public class UdpState
    {
        public UdpClient udpClient;
        public IPEndPoint ipEndPoint;
        public const int BufferSize = 10240;
        public byte[] buffer = new byte[BufferSize];
        public int counter = 0;
    }
}

