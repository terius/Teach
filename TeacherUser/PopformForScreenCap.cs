using Microsoft.DirectX.DirectSound;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpConnectJson;

namespace TeacherUser
{
    public partial class PopformForScreenCap : Form
    {
        private Ffmpeg f = null;
        private string savePath = null;
        private string soundSource = null;
        private string command = null;
        private MainForm mainForm;
        public PopformForScreenCap()
        {
            InitializeComponent();
        }

        public PopformForScreenCap(MainForm mainForm)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mainForm = mainForm;
        }


        private void startScreenCapBtn_Click(object sender, EventArgs e)//开始屏幕录制
        {
            if (savePath==null)
            {
                MessageBox.Show("请先选择文件保存路径！");
                return;
            }
            this.stopScreenCapBtn.Enabled = true;
            f = new Ffmpeg();
            string time = DateTime.Now.ToString();            // 2008-9-4 20:02:10
            if (soundSource != null)
            {
                command = "-f gdigrab -i desktop -f dshow -i audio=" + "\"" + soundSource + "\"" + " -r 5 -vcodec libx264 -preset:v ultrafast -tune:v zerolatency -acodec libmp3lame " + savePath;
               //command = "-f gdigrab -i desktop -f dshow -i audio=" + "\"" + soundSource + "\""+" -r 5 -acodec libmp3lame -f mpegts "+savePath+
            }
            else
            {
                command = "-f gdigrab -i desktop -r 5 -vcodec libx264 -preset:v ultrafast " + savePath;
            }
            //MessageBox.Show(command);
            try
            {
               // f.execute(command);
                f.beginExecute(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }     
        }

        private void stopScreenCapBtn_Click(object sender, EventArgs e)//停止屏幕录制
        {
            f.dispose();
            this.Close();
           // this.mainForm.screenCapStop();
        }

        private void PopformForScreenCap_Load(object sender, EventArgs e)//加载屏幕录制窗体
        {
            this.stopScreenCapBtn.Enabled = false;
            CaptureDevicesCollection sound_devices = new CaptureDevicesCollection();
            if (sound_devices.Count > 0)
            {
                int i = 0;
                while (i < sound_devices.Count)
                {
                    string text = sound_devices[i].Description;
                    if (text.Contains("麦克风"))
                    {
                        string descrip = sound_devices[i].Description;
                        int len = descrip.Length;
                        if (len > 31)
                            soundSource = descrip.Substring(0, 31);
                        else
                            soundSource = descrip;
                        this.soundChBox.Checked = true;
                        //return;
                        break;
                    }
                    i++;
                }
            }
        }

        private void selectPathbt_Click(object sender, EventArgs e)
        {
           // this.saveFileDialog1.Filter = "mkv文件(*.mkv)|*.mkv";

            this.saveFileDialog1.Filter = "mp4文件(*.mp4)|*.mp4";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savePath = saveFileDialog1.FileName;
                this.textBox1.Text = savePath;
            }    
        }

        private void PopformForScreenCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.screenCapStop();
        }
    }
}
