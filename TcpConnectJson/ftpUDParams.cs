// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.ftpUDParams
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System.Windows.Forms;

namespace TcpConnectJson
{
  public class ftpUDParams
  {
    public Messages msg { get; set; }

    public string filename { get; set; }

    public string path { get; set; }

    public string filenameSave { get; set; }

    public ProgressBar progressBar { get; set; }

    public Label label { get; set; }

    public double progress { get; set; }

    public ftpUDParams(Messages msgs, string fileName, string Path)
    {
      this.msg = msgs;
      this.filename = fileName;
      this.path = Path;
    }

    public ftpUDParams(Messages msgs, string fileName, string Path, ProgressBar bar, Label lab)
    {
      this.msg = msgs;
      this.filename = fileName;
      this.path = Path;
      this.progressBar = bar;
      this.label = lab;
    }
  }
}
