using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentUser
{
    public partial class VLCPlayer : Form
    {
        public VLCPlayer()
        {
            InitializeComponent();
        }

        private void VLCPlayer_Load(object sender, EventArgs e)
        {
            string pluginPath = Environment.CurrentDirectory + "\\plugins\\";  //插件目录
            var player = new VlcPlayerBase(pluginPath);
            player.SetRenderWindow((int)this.Handle);//panel
            player.LoadFile(@"E:\terius\hkdg.mkv");//视频文件路径
        }
    }
}
