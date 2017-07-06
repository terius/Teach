using DirectShowLib;
using MyVideo;
using System;
using System.IO;
using System.Windows.Forms;

namespace vlctest
{
    public partial class ffmpegTest : Form
    {
        private Ffmpeg _ffmpeg = null;
        bool isBegin = false;
        string videoPath;
        
        public ffmpegTest()
        {
            InitializeComponent();
            videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos");
            if (!Directory.Exists(videoPath))
            {
                Directory.CreateDirectory(videoPath);
            }
            _ffmpeg = new Ffmpeg();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
          //  GlobalVariable.client.CreateScreenInteract();



            string fileName = Path.Combine(videoPath, DateTime.Now.ToString("HHmmssfff") + ".mpg");
            string mic = GetMicName();
            if (!string.IsNullOrWhiteSpace(mic))
            {
                mic = string.Format("-f dshow -i audio=\"{0}\"", mic);
            }
           // fileName = "-f h264 udp://192.168.100.16:6666";
            string para = string.Format("-f gdigrab -i desktop {1}  -s 1920*1080 -vcodec libx264 -bufsize 2000k {0}", fileName,mic);
           // string para = string.Format("-f gdigrab -i desktop {1} -framerate 6 -g 240 -s 1920*1080 -acodec mp2 -ab 128k -vcodec libx264 -x264opts bframes=3:b-adapt=0 -bufsize 2000k -threads 16 -preset:v ultrafast -tune:v zerolatency {0}", fileName, mic);
            _ffmpeg.beginExecute(para);
            isBegin = true;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (isBegin)
            {
                _ffmpeg.dispose();
                
            }
            isBegin = false;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            var capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var item in capDevices)
            {
                textBox1.Text += "name:" + item.Name +  
                            "\r\ndeviceid:" + item.ClassID +
                            "\r\npath:" + item.DevicePath +
                            "\r\n\r\n";
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var capDevices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);
           
            foreach (var item in capDevices)
            {
                textBox1.Text += "name:" + item.Name +
                            "\r\ndeviceid:" + item.ClassID +
                            "\r\npath:" + item.DevicePath +
                            "\r\n\r\n";
            }
        }


        private string GetMicName()
        {
            var capDevices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);

            foreach (var item in capDevices)
            {
              if (item.Name.Contains("麦克风"))
                {
                    return item.Name;
                }
            }
            return "";
        }
    }
}
