using SharedForms;
using System;
using System.Windows.Forms;

namespace NewTeacher
{
    public partial class fmEditTeamName : Form
    {
        string _teamGuid;
    
        public fmEditTeamName(string _guid,string oldName)
        {
            InitializeComponent();
            _teamGuid = _guid;
            textBox1.Text = oldName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //   this.Opacity = 0.1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(newName))
            {
                GlobalVariable.ShowError("新组名不能为空");
                return;
            }
            bool rs = GlobalVariable.EditTeamName(_teamGuid, newName);
            if (rs)
            {
                GlobalVariable.ShowSuccess("分组名修改成功");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
