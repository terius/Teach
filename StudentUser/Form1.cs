using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();

        }

        //引入API函数

        [DllImport("user32 ")]//这个是调用windows的系统锁定
        public static extern bool LockWorkStation();

        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);


    
        private void lockTaskmgr()//锁定任务管理器

        {

            FileStream fs =

                new FileStream(Environment.ExpandEnvironmentVariables(

                    "%windir%\\system32\\taskmgr.exe"), FileMode.Open);

            //byte[] Mybyte = new byte[(int)MyFs.Length];

            //MyFs.Write(Mybyte, 0, (int)MyFs.Length);

            //MyFs.Close();

            //用文件流打开任务管理器应用程序而不关闭文件流就会阻止打开任务管理器

        }



        private void lockAll()

        {

            BlockInput(true);//锁定鼠标及键盘

        }



        private void Form1_Load(object sender, EventArgs e)

        {

            //this.lockAll();

       

        }



        private void btnUnlock_Click(object sender, EventArgs e)

        {

            //if (txtPwd.Text == "19880210")

            //{

            //    BlockInput(false);

            //    Application.Exit();

            //}

            //else

            //{

            //    MessageBox.Show("密码错误！", "消息",

            //        MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    txtPwd.Text = "";

            //    txtPwd.Focus();

            //}

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LockWorkStation();
        }
    }
}
