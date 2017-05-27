using Microsoft.DirectX.DirectSound;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string soundSource = "";
            //CaptureDevicesCollection sound_devices = new CaptureDevicesCollection();
            //if (sound_devices.Count > 0)
            //{
            //    int i = 0;
            //    while (i < sound_devices.Count)
            //    {
            //        string text = sound_devices[i].Description;
            //        if (text.Contains("麦克风"))
            //        {
            //            string descrip = sound_devices[i].Description;
            //            int len = descrip.Length;
            //            if (len > 31)
            //                soundSource = descrip.Substring(0, 31);
            //            else
            //                soundSource = descrip;
                      
            //            //return;
            //            break;
            //        }
            //        i++;
            //    }
            //}
        }
    }
}
