using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class UserManage : Form
    {
       
        public UserManage()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                tabPage1.Show();
                tabPage2.Hide();
                tabPage3.Hide();
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                tabPage1.Hide();
                tabPage2.Show();
                tabPage3.Hide();
            }
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                tabPage1.Hide();
                tabPage2.Hide();
                tabPage3.Show();
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)//注册TabControl控件的DrawItem事件： 
        {
            //获取TabControl主控件的工作区域 
            Rectangle rec = tabControl1.ClientRectangle;
            //获取背景图片，我的背景图片在项目资源文件中。 
            // Image backImage = Resources.枫叶; 
            //新建一个StringFormat对象，用于对标签文字的布局设置 
            StringFormat StrFormat = new StringFormat();
            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中 
            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中          
            // 标签背景填充颜色，也可以是图片 
            SolidBrush bru = new SolidBrush(Color.FromArgb(72, 181, 250));
            SolidBrush bruFont = new SolidBrush(Color.FromArgb(0, 0, 0));// 标签字体颜色 
            Font font = new System.Drawing.Font("微软雅黑", 10F);//设置标签字体样式 
            //绘制主控件的背景 
            //  e.Graphics.DrawImage(backImage, 0, 0,  tabControl1.Width,  tabControl1.Height); 
            //绘制标签样式 
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头的工作区域 
                Rectangle recChild = tabControl1.GetTabRect(i);
                //绘制标签头背景颜色 
                e.Graphics.FillRectangle(bru, recChild);
                //绘制标签头的文字 
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, font, bruFont, recChild, StrFormat);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//密码修改 “确定”
        {
            if(this.textBox1.Text=="")
            {
                MessageBox.Show("请输入原密码！");
                return;
            }
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("请输入新密码！");
                return;
            }
            if (this.textBox3.Text == "")
            {
                MessageBox.Show("请再次输入新密码！");
                return;
            }
            if (this.textBox2.Text != this.textBox3.Text)
            {
                MessageBox.Show("密码错误！请重新确认新密码！");
                this.textBox3.Text = "";
                return;
            }
            if (this.textBox1.Text == this.textBox2.Text)
            {
                MessageBox.Show("新旧密码相同！请重置");
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                return;
            }
            string sqlforUpdate = string.Format("UPDATE "+ ConfigurationManager.AppSettings["Table"]+" SET password ='"+this.textBox2.Text+"'where password='" + this.textBox1.Text + "'");

            if (MysqlHelper.ExecuteNonQuery(sqlforUpdate) == 1)
            {
                MessageBox.Show("修改成功！");
                ShowAllUsers();//显示当前最新所有用户
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void button2_Click(object sender, EventArgs e)// 新建用户 保存
        {
            if (this.textBox4.Text == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (this.textBox5.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (this.textBox6.Text == "")
            {
                MessageBox.Show("请再次输入密码！");
                return;
            }
            if (this.textBox5.Text != this.textBox6.Text)
            {
                MessageBox.Show("密码错误！请重新确认新密码！");
                this.textBox6.Text = "";
                return;
            }
             int userRole = -1;
             if (this.radioButton1.Checked) userRole = 0;
             else
             {
                 if (radioButton2.Checked) userRole = 1;
                 else
                 {
                     if (radioButton3.Checked) userRole = 2;
                     else
                     {
                         MessageBox.Show("请选择用户角色！");
                         return;
                     }
                 
                 }
             }
            string sqlforCheck = string.Format("SELECT * FROM "+ ConfigurationManager.AppSettings["Table"]+ " WHERE name='" + this.textBox4.Text + "'");
            string sqlforAdd = string.Format("INSERT INTO "+ ConfigurationManager.AppSettings["Table"]+"(name,password,role) VALUES('" + this.textBox4.Text + "','"+this.textBox5.Text+ "',"+userRole+")");

            if (MysqlHelper.ExecuteScalar(sqlforCheck) != null)
            {
                MessageBox.Show("用户名已存在！");
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                return;
            }
            else
            {
                if (MysqlHelper.ExecuteNonQuery(sqlforAdd) == 1)
                {
                    MessageBox.Show("保存成功！");
                    ShowAllUsers();//显示当前最新所有用户
                }
            }
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            ShowAllUsers();//显示当前最新所有用户
        }

        private void ShowAllUsers()//显示当前最新所有用户
        {
            MysqlHelper helper = new MysqlHelper();
            string sql = string.Format("SELECT * FROM " + ConfigurationManager.AppSettings["Table"]);
            dataGridView1.DataSource = MysqlHelper.ExecuteDataTable(sql);       
        }    
    }
}