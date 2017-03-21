// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.ftpDLParams
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System.Windows.Forms;

namespace TcpConnectJson
{
  public class ftpDLParams
  {
    public string filename { get; set; }

    public string path { get; set; }

    public string filenameSave { get; set; }

    public ProgressBar progressBar { get; set; }

    public Label label { get; set; }

    public double progress { get; set; }

    public ftpDLParams(string fileName, string Path, string fileSave)
    {
      this.filename = fileName;
      this.path = Path;
      this.filenameSave = fileSave;
    }

    public ftpDLParams(string fileName, string Path, string fileSave, ProgressBar bar, Label lab)
    {
      this.filename = fileName;
      this.path = Path;
      this.filenameSave = fileSave;
      this.progressBar = bar;
      this.label = lab;
    }
  }
}
