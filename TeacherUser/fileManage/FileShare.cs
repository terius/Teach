using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class FileShare : Form
    {
        public FileShare()
        {
            InitializeComponent();
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.Columns.Add("添加文件", 500, HorizontalAlignment.Left); //一步添加 
        }

        private void FileShare_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void file_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);       
            int i;
            for (i = 0; i < s.Length; i++)
            {
                if (s[i].Trim() != "")
                {
                    //listBox1.Items.Add(s[i].ToString());
                    string type=Path.GetExtension(s[i].ToString());
                   // MessageBox.Show(type);
                    ListViewItem lvi = new ListViewItem();
                    switch (type)
                    { 
                        case (".doc"):
                        case (".docx"):   
                            lvi.ImageIndex = 0;
                            break;
                        case (".txt"):
                            lvi.ImageIndex = 1;
                            break;
                        case (".pdf"):
                            lvi.ImageIndex = 2;
                            break;
                        case (".rar"):
                            lvi.ImageIndex = 3;
                            break;
                    
                        default :
                            break;
                    
                    }
                    lvi.Text = s[i].ToString();
                    this.listView1.Items.Add(lvi);  
                }
            }
        }

        private void file_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
