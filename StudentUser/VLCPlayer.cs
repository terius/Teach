using Helpers;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

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
        }
        private void vlcControl1_VlcLibDirectoryNeeded_1(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        public void StartPlayStream(string url)
        {
            Uri uri = new Uri(url);
            var option = ":network-caching=300:rtsp-caching=300:no-video-title-show";
            Loger.LogMessage("接收到rtsp地址：" + url);
            vlcControl1.Play(uri, option);
        }

        public void StartPlayLocation(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            vlcControl1.Play(fi);
        }

        public void StopPlay()
        {
      
            vlcControl1.Stop();
        }
    }
}
