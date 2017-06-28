using SharedForms;
using System;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class CallForm : Form
    {
        public CallForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.txtName.Text = GlobalVariable.LoginUserInfo.DisplayName;
            this.txtNo.Text = GlobalVariable.LoginUserInfo.No;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            string no = txtNo.Text.Trim();
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(no))
            {
                GlobalVariable.ShowError("学号不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                GlobalVariable.ShowError("姓名不能为空！");
                return;
            }
            GlobalVariable.client.Send_StudentCall(no, name, GlobalVariable.LoginUserInfo.UserName);
            this.Close();
        }
    }
}
