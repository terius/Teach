// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.Ffmpeg
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyTCP
{
    public class Ffmpeg
  {
    private Process myProcess = (Process) null;

    public event MessageReceivedEventHandler MessageReceived;

    public void execute(string para)
    {
      try
      {
        this.myProcess = new Process();
        ProcessStartInfo processStartInfo = new ProcessStartInfo("ffmpeg.exe", para);
        this.myProcess.StartInfo = processStartInfo;
        processStartInfo.UseShellExecute = false;
        processStartInfo.WorkingDirectory = Application.StartupPath;
        processStartInfo.CreateNoWindow = true;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardInput = true;
        this.myProcess.Start();
        StreamReader standardOutput = this.myProcess.StandardOutput;
        this.myProcess.WaitForExit();
        while (!standardOutput.EndOfStream)
          this.MessageReceived.BeginInvoke(standardOutput.ReadLine(), (AsyncCallback) null, (object) null);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void beginExecute(string para)
    {
      try
      {
        new Thread(() =>
       {
           this.myProcess = new Process();
           ProcessStartInfo processStartInfo = new ProcessStartInfo("ffmpeg.exe", para);
           this.myProcess.StartInfo = processStartInfo;
           processStartInfo.UseShellExecute = false;
           processStartInfo.WorkingDirectory = Application.StartupPath;
           processStartInfo.CreateNoWindow = true;
           processStartInfo.RedirectStandardOutput = true;
           processStartInfo.RedirectStandardInput = true;
           this.myProcess.Start();
           StreamReader standardOutput = this.myProcess.StandardOutput;
           this.myProcess.WaitForExit();
           while (!standardOutput.EndOfStream)
               this.MessageReceived.BeginInvoke(standardOutput.ReadLine(), (AsyncCallback)null, (object)null);
       }).Start();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void dispose()
    {
      if (this.myProcess.HasExited)
        return;
      this.myProcess.Refresh();
      this.myProcess.CloseMainWindow();
      this.myProcess.Kill();
      this.myProcess.Dispose();
      this.myProcess.Close();
    }

    public delegate void MessageReceivedEventHandler(string msg);
  }
}
