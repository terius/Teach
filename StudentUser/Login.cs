using Common;
using Helpers;
using Model;
using MySocket;
using SharedForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string userGuid;

        //   private delegate void messageListCallback(string content);
        //  private messageListCallback messageCallback;
        private async void Form2_Load(object sender, EventArgs e)
        {
            Login_Btn.SetButtonHoverLeave();
            btnExit.SetButtonHoverLeave();
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            //    GlobalVariable.client.messageDue.OnReceieveMessage += MessageDue_OnReceieveMessage;
            this.textBox1.Text = "Stu" + DateTime.Now.ToString("MMddHHmmss");
            this.textBox2.Text = "8888";
            await LoginIn();

            //TestAES();
        }

        private void Client_OnReveieveData(ReceieveMessage message)
        {
            TranMessage = resStr =>
            {
                if (message.Action == 2)
                {
                    var result = JsonHelper.DeserializeObj<LoginResult>(resStr);
                    if (result.success)
                    {
                        this.DialogResult = DialogResult.OK;
                        GlobalVariable.client.OnReveieveData -= Client_OnReveieveData;
                        GlobalVariable.LoginUserInfo = new LoginUserInfo
                        {
                            DisplayName = textBox1.Text.Trim(),
                            UserName = textBox1.Text.Trim(),
                            UserType = ClientRole.Student,
                            No = textBox2.Text.Trim()
                        };
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.msg);
                    }
                }
            };
            //Action<string> action = (data) =>
            //{
            //    Thread.Sleep(3000);
            //    txtBox.AppendText(data);
            //};
            Invoke(TranMessage, message.DataStr);
        }

        Action<string> TranMessage;






        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private async void button1_Click(object sender, EventArgs e)//登录 
        {
            //string connectionString = "Database='" + ConfigurationManager.AppSettings["Database"] + "';Data Source='" + ConfigurationManager.AppSettings["serverIP"]+ "';User Id='" + ConfigurationManager.AppSettings["User ID"]+ "';Password='" + ConfigurationManager.AppSettings["Password"]+ "'";//默认端口3306 
            await LoginIn();
        }

        private async Task LoginIn()
        {
            string nickName = "学生"+ DateTime.Now.ToString("yyyyMMddHHmmss");
            string userName = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (userName == string.Empty)
            {
                MessageBox.Show("请输入登陆用户名！");
                return;
            }
            if (password == string.Empty)
            {
                MessageBox.Show("请输入登陆密码！");
                return;
            }
          //  userGuid = Guid.NewGuid().ToString();
             GlobalVariable.client.Send_UserLogin(userName, nickName, password, ClientRole.Student);
        }




        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

