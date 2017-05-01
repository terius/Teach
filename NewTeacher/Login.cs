using Common;
using Helper;
using Helpers;
using Model;
using MyTCP;
using SharedForms;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTeacher
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        //   private delegate void messageListCallback(string content);
        //  private messageListCallback messageCallback;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.rbTeacher.Checked = true;
            this.ContextMenuStrip = contextMenuStrip1;
            Login_Btn.SetButtonHoverLeave();
            btnExit.SetButtonHoverLeave();
            GlobalVariable.client = new MyTcpClient();
            GlobalVariable.client.OnReveieveData += Client_OnReveieveData;
            this.textBox1.Text = "tech1";
            this.textBox2.Text = "1";
            //TestAES();
        }

        private void Client_OnReveieveData(ReceieveMessage message)
        {
            Invoke(new Action(() =>
            {
                var result = JsonHelper.DeserializeObj<LoginResult>(message.DataStr);
                if (result.success)
                {
                    this.DialogResult = DialogResult.OK;
                    GlobalVariable.client.OnReveieveData -= Client_OnReveieveData;
                    GlobalVariable.LoginUserInfo = new LoginUserInfo
                    {
                        DisplayName = "老师",
                        UserName = textBox1.Text.Trim(),
                        UserType = ClientRole.Teacher,
                        No = textBox2.Text.Trim()
                    };
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.msg);
                }
            }));
        }

        //Action<string> TranMessage;
        //private void MessageDue_OnReceieveMessage(Model.ReceieveMessage message)
        //{
        //    TranMessage = resStr =>
        //    {
        //        var result = JsonHelper.DeserializeObj<LoginResult>(resStr);
        //        if (result.success)
        //        {
        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show(result.msg);
        //        }
        //    };
        //    //Action<string> action = (data) =>
        //    //{
        //    //    Thread.Sleep(3000);
        //    //    txtBox.AppendText(data);
        //    //};
        //    Invoke(TranMessage, message.DataStr);

        //}


        //private void TestAES()
        //{
        //    string original = "水电费第三个富*)(^$#@#$^%商大贾说得对是否%……*&*……&啊实打实3434的assdfsdfsdfsdfsdfsdfsd23423412f";

        //    using (RijndaelManaged myRijndael = new RijndaelManaged())
        //    {

        //        myRijndael.GenerateKey();
        //        myRijndael.GenerateIV();
        //        // Encrypt the string to an array of bytes. 
        //        byte[] encrypted = AESHelper3.EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

        //        // Decrypt the bytes to a string. 
        //        string roundtrip = AESHelper3.DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

        //        //Display the original data and the decrypted data.
        //        Console.WriteLine("Original:   {0}", original);
        //        Console.WriteLine("Round Trip: {0}", roundtrip);
        //    }
        //}




        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private async void button1_Click(object sender, EventArgs e)//登录 
        {
            //string connectionString = "Database='" + ConfigurationManager.AppSettings["Database"] + "';Data Source='" + ConfigurationManager.AppSettings["serverIP"]+ "';User Id='" + ConfigurationManager.AppSettings["User ID"]+ "';Password='" + ConfigurationManager.AppSettings["Password"]+ "'";//默认端口3306 
            string displayName = this.textBox1.Text.Trim();
            string userPass = this.textBox2.Text.Trim();
            int userRole = rbTeacher.Checked ? 1 : 2;

            if (displayName == string.Empty)
            {
                MessageBox.Show("请输入姓名！");
                return;
            }
            if (userPass == string.Empty)
            {
                MessageBox.Show("请输入密码！");
                return;
            }

            await GlobalVariable.client.Send_UserLogin(displayName,displayName, userPass, ClientRole.Teacher);

            //this.Hide();
            //MainForm f = new MainForm();
            //f.Show();
            //string serverIP = ConfigurationManager.AppSettings["serverIP"];
            //string sql = string.Format("SELECT * from " + ConfigurationManager.AppSettings["Table"] + " where name='" + userName + "' and password='" + userPass + "'" + " and role=" + userRole);
            //if (MysqlHelper.ExecuteScalar(sql) == null)
            //{
            //    MessageBox.Show("用户名或密码或角色选择不正确！");
            //    return;
            //}
            //else
            //{
            //    if (Convert.ToInt32(MysqlHelper.ExecuteScalar(sql)) == -1)
            //    {
            //        ConfServerIP f = new ConfServerIP();
            //        f.Show();
            //    }
            //    else
            //    {

            //    }
            //}
        }




       

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}

