using SharedForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTeacher
{
    public partial class CallForm : Form
    {
        public CallForm()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            GlobalVariable.client.Send_Call();
            this.start_btn.Enabled = false;
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
          //  GlobalVariable.client.Send_EndCall();
            this.Close();
        }

        private void CallForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.start_btn.Enabled)
            {
                GlobalVariable.client.Send_EndCall();
                //DialogResult r = MessageBox.Show("是否结束课堂点名?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (r != DialogResult.OK)
                //{
                //    e.Cancel = true;
                //}
                //else
                //{
                //    this.Close();
                //}
            }
        }
    }
}
