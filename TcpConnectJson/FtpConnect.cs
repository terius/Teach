// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.FtpConnect
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace TcpConnectJson
{
  public class FtpConnect
  {
    private string _FtpServerIP;
    private string _UserName;
    private string _Password;
    private ClientConnectTcp clientConnect;
    private FtpConnect.UploadFileEventHandler uploadFile;
    private FtpConnect.ProcessBarValueEventHandler processBarValue;
    private FtpConnect.ProcessBarMaxmumEventHandler processBarMaxmum;

    public event FtpConnect.FtpUploadFileSuccessEventHandler ftpUploadFileSuccess;

    public event FtpConnect.FtpUploadFileFailedEventHandler ftpUploadFileFailed;

    public event FtpConnect.FtpDownloadFileSuccessEventHandler ftpDownLoadFileSuccess;

    public event FtpConnect.FtpDownloadFileFailedEventHandler ftpDownLoadFileFailed;

    public event FtpConnect.FtpConnectFailedEventHandler ftpConnectFailed;

    public FtpConnect(ClientConnectTcp ConnectTcp, string ftpIP, string username, string password)
    {
      this.clientConnect = ConnectTcp;
      this._FtpServerIP = ftpIP;
      this._UserName = username;
      this._Password = password;
      this.processBarValue = new FtpConnect.ProcessBarValueEventHandler(this.setBarValue);
      this.processBarMaxmum = new FtpConnect.ProcessBarMaxmumEventHandler(this.setBarMaxmum);
    }

    private void uploadfile(ref ftpUDParams ftpParam)
    {
      this.uploadFile = new FtpConnect.UploadFileEventHandler(this.beginUploadFile1);
      this.uploadFile.BeginInvoke(ref ftpParam, (AsyncCallback) null, (object) null);
    }

    private FtpStatusCode beginUploadFile1(ref ftpUDParams ftpParam)
    {
      FtpStatusCode ftpStatusCode = FtpStatusCode.Undefined;
      string path = ftpParam.path;
      string filename = ftpParam.filename;
      FtpWebResponse ftpWebResponse = (FtpWebResponse) null;
      Stream stream = (Stream) null;
      FileStream fileStream = (FileStream) null;
      string requestUriString = string.Format("ftp://{0}/{1}/{2}", (object) this._FtpServerIP, (object) path, (object) filename.Substring(filename.LastIndexOf("\\") + 1));
      try
      {
        FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
        ftpWebRequest.Method = "STOR";
        ftpWebRequest.UseBinary = true;
        stream = ftpWebRequest.GetRequestStream();
        fileStream = new FileStream(filename, FileMode.Open);
        byte[] buffer = new byte[1024];
        while (true)
        {
          int count = fileStream.Read(buffer, 0, buffer.Length);
          if (count != 0)
            stream.Write(buffer, 0, count);
          else
            break;
        }
        this.ftpUploadFileSuccess.BeginInvoke(filename, (AsyncCallback) null, (object) null);
        stream.Close();
        ftpWebResponse = (FtpWebResponse) ftpWebRequest.GetResponse();
        ftpStatusCode = ftpWebResponse.StatusCode;
      }
      catch (Exception ex)
      {
        this.ftpUploadFileFailed.BeginInvoke(filename, ex.Message, (AsyncCallback) null, (object) null);
      }
      finally
      {
        if (ftpWebResponse != null)
          ftpWebResponse.Close();
        if (fileStream != null)
          fileStream.Close();
        if (stream != null)
          stream.Close();
      }
      return ftpStatusCode;
    }

    private FtpStatusCode beginUploadFile2(ref ftpUDParams ftpParam)
    {
      FtpStatusCode ftpStatusCode = FtpStatusCode.Undefined;
      string path = ftpParam.path;
      string filename = ftpParam.filename;
      FtpWebResponse ftpWebResponse = (FtpWebResponse) null;
      Stream stream = (Stream) null;
      FileStream fileStream = (FileStream) null;
      string requestUriString = string.Format("ftp://{0}/{1}/{2}", (object) this._FtpServerIP, (object) path, (object) filename.Substring(filename.LastIndexOf("\\") + 1));
      try
      {
        FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
        ftpWebRequest.KeepAlive = false;
        ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
        ftpWebRequest.Method = "STOR";
        ftpWebRequest.UseBinary = true;
        stream = ftpWebRequest.GetRequestStream();
        fileStream = new FileStream(filename, FileMode.Open);
        int length1 = 1048576;
        int num1 = (int) (fileStream.Length / (long) length1);
        int length2 = (int) (fileStream.Length % (long) length1);
        ftpParam.progressBar.Maximum = num1;
        if (length2 != 0)
          ++ftpParam.progressBar.Maximum;
        for (int index = 0; index < num1; ++index)
        {
          byte[] buffer = new byte[length1];
          fileStream.Read(buffer, 0, buffer.Length);
          stream.Write(buffer, 0, buffer.Length);
          ftpParam.progressBar.Value = index;
          double num2 = Convert.ToDouble(index) / Convert.ToDouble(num1) * 100.0;
          ftpParam.label.Text = num2.ToString() + "%";
        }
        if (length2 != 0)
        {
          byte[] buffer = new byte[length2];
          fileStream.Read(buffer, 0, buffer.Length);
          stream.Write(buffer, 0, buffer.Length);
          ++ftpParam.progressBar.Value;
        }
        this.ftpUploadFileSuccess.BeginInvoke(filename, (AsyncCallback) null, (object) null);
        stream.Close();
        ftpWebResponse = (FtpWebResponse) ftpWebRequest.GetResponse();
        ftpStatusCode = ftpWebResponse.StatusCode;
      }
      catch (Exception ex)
      {
        this.ftpUploadFileFailed.BeginInvoke(filename, ex.Message, (AsyncCallback) null, (object) null);
      }
      finally
      {
        if (ftpWebResponse != null)
          ftpWebResponse.Close();
        if (fileStream != null)
          fileStream.Close();
        if (stream != null)
          stream.Close();
      }
      return ftpStatusCode;
    }

    private FtpStatusCode beginUploadFile3(ftpUDParams ftpParam)
    {
      FtpStatusCode statuscode = FtpStatusCode.Undefined;
      string path = ftpParam.path;
      string fileName = ftpParam.filename;
      new Thread((ThreadStart) (() =>
      {
        FtpWebResponse ftpWebResponse = (FtpWebResponse) null;
        Stream stream = (Stream) null;
        FileStream fileStream = (FileStream) null;
        string requestUriString = string.Format("ftp://{0}/{1}", (object) this._FtpServerIP, (object) fileName.Substring(fileName.LastIndexOf("\\") + 1));
        try
        {
          FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
          ftpWebRequest.KeepAlive = false;
          ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
          ftpWebRequest.Method = "STOR";
          stream = ftpWebRequest.GetRequestStream();
          fileStream = new FileStream(fileName, FileMode.Open);
          int length1 = 1048576;
          int num = (int) (fileStream.Length / (long) length1);
          int length2 = (int) (fileStream.Length % (long) length1);
          ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) num);
          if (length2 != 0)
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) (num + 1));
          for (int index = 0; index < num; ++index)
          {
            byte[] buffer = new byte[length1];
            fileStream.Read(buffer, 0, buffer.Length);
            stream.Write(buffer, 0, buffer.Length);
            string str = (Convert.ToDouble(index) / Convert.ToDouble(num) * 100.0).ToString() + "%";
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) index, (object) str);
          }
          if (length2 != 0)
          {
            byte[] buffer = new byte[length2];
            fileStream.Read(buffer, 0, buffer.Length);
            stream.Write(buffer, 0, buffer.Length);
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) (num + 1), (object) "100%");
          }
          this.ftpUploadFileSuccess.BeginInvoke(fileName, (AsyncCallback) null, (object) null);
          stream.Close();
          ftpWebResponse = (FtpWebResponse) ftpWebRequest.GetResponse();
          statuscode = ftpWebResponse.StatusCode;
        }
        catch (Exception ex)
        {
          this.ftpUploadFileFailed.BeginInvoke(fileName, ex.Message, (AsyncCallback) null, (object) null);
        }
        finally
        {
          if (ftpWebResponse != null)
            ftpWebResponse.Close();
          if (fileStream != null)
            fileStream.Close();
          if (stream != null)
            stream.Close();
        }
      })).Start();
      return statuscode;
    }

    public FtpStatusCode beginUploadFile(ftpUDParams ftpParam)
    {
      FtpStatusCode statuscode = FtpStatusCode.Undefined;
      string path = ftpParam.path;
      string fileName = ftpParam.filename;
      new Thread((ThreadStart) (() =>
      {
        string requestUriString = string.Format("ftp://{0}/{1}/{2}", (object) this._FtpServerIP, (object) path, (object) fileName.Substring(fileName.LastIndexOf("\\") + 1));
        FtpWebRequest ftpWebRequest;
        Stream requestStream;
        try
        {
          ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
          ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
          ftpWebRequest.Method = "STOR";
          ftpWebRequest.UseBinary = true;
          requestStream = ftpWebRequest.GetRequestStream();
        }
        catch (Exception ex)
        {
          this.ftpConnectFailed.BeginInvoke(fileName, ex.Message, (AsyncCallback) null, (object) null);
          return;
        }
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        if (ftpParam.progressBar != null)
        {
          int length1 = 1048576;
          int num = (int) (fileStream.Length / (long) length1);
          int length2 = (int) (fileStream.Length % (long) length1);
          ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) num);
          if (length2 != 0)
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) (num + 1));
          for (int index = 0; index < num; ++index)
          {
            byte[] buffer = new byte[length1];
            fileStream.Read(buffer, 0, buffer.Length);
            requestStream.Write(buffer, 0, buffer.Length);
            string str = (Convert.ToDouble(index) / Convert.ToDouble(num) * 100.0).ToString() + "%";
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) index, (object) str);
          }
          if (length2 != 0)
          {
            byte[] buffer = new byte[length2];
            fileStream.Read(buffer, 0, buffer.Length);
            requestStream.Write(buffer, 0, buffer.Length);
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) (num + 1), (object) "100%");
          }
        }
        else
        {
          byte[] buffer = new byte[1024];
          while (true)
          {
            int count = fileStream.Read(buffer, 0, buffer.Length);
            if (count != 0)
              requestStream.Write(buffer, 0, count);
            else
              break;
          }
        }
        if (this.clientConnect != null && this.clientConnect._tcpConnectState && ftpParam.msg != null)
          this.clientConnect.SendMessage(ftpParam.msg);
        requestStream.Close();
        FtpWebResponse response = (FtpWebResponse) ftpWebRequest.GetResponse();
        statuscode = response.StatusCode;
        if (fileStream != null)
        {
          fileStream.Dispose();
          fileStream.Close();
        }
        if (response != null)
          response.Close();
        if (this.ftpUploadFileSuccess != null)
          this.ftpUploadFileSuccess.BeginInvoke(fileName, (AsyncCallback) null, (object) null);
        Thread.CurrentThread.Abort();
      }))
      {
        IsBackground = true
      }.Start();
      return statuscode;
    }

    public FtpStatusCode beginDownloadFile(ftpDLParams ftpParam)
    {
      FtpStatusCode statuscode = FtpStatusCode.Undefined;
      string path = ftpParam.path;
      string fileName = ftpParam.filename;
      string fileNameSaveAs = ftpParam.filenameSave;
      new Thread((ThreadStart) (() =>
      {
        string requestUriString = string.Format("ftp://{0}/{1}/{2}", (object) this._FtpServerIP, (object) path, (object) fileName.Substring(fileName.LastIndexOf("\\") + 1));
        FtpWebResponse response;
        try
        {
          FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
          ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
          ftpWebRequest.Method = "RETR";
          ftpWebRequest.UseBinary = true;
          response = (FtpWebResponse) ftpWebRequest.GetResponse();
        }
        catch (Exception ex)
        {
          this.ftpConnectFailed.BeginInvoke(fileName, ex.Message, (AsyncCallback) null, (object) null);
          return;
        }
        Stream responseStream = response.GetResponseStream();
        FileStream fileStream = new FileStream(fileNameSaveAs, FileMode.Create);
        if (ftpParam.progressBar != null)
        {
          FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(requestUriString);
          ftpWebRequest.Credentials = (ICredentials) new NetworkCredential(this._UserName, this._Password);
          ftpWebRequest.Method = "SIZE";
          long contentLength = ftpWebRequest.GetResponse().ContentLength;
          int length = 1048576;
          int num = (int) (contentLength / (long) length);
          int count1 = (int) (contentLength % (long) length);
          ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) num);
          if (count1 != 0)
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarMaxmum, (object) ftpParam.progressBar, (object) (num + 1));
          for (int index = 0; index < num; ++index)
          {
            byte[] buffer = new byte[length];
            int count2 = responseStream.Read(buffer, 0, buffer.Length);
            fileStream.Write(buffer, 0, count2);
            string str = (Convert.ToDouble(index) / Convert.ToDouble(num) * 100.0).ToString() + "%";
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) index, (object) str);
          }
          if (count1 != 0)
          {
            byte[] buffer = new byte[count1];
            for (int count2 = responseStream.Read(buffer, 0, count1); count2 > 0; count2 = responseStream.Read(buffer, 0, count1))
              fileStream.Write(buffer, 0, count2);
            ftpParam.progressBar.BeginInvoke((Delegate) this.processBarValue, (object) ftpParam.progressBar, (object) ftpParam.label, (object) (num + 1), (object) "100%");
          }
        }
        else
        {
          int count1 = 2048;
          byte[] buffer = new byte[count1];
          for (int count2 = responseStream.Read(buffer, 0, count1); count2 > 0; count2 = responseStream.Read(buffer, 0, count1))
            fileStream.Write(buffer, 0, count2);
        }
        responseStream.Close();
        statuscode = response.StatusCode;
        if (fileStream != null)
        {
          fileStream.Dispose();
          fileStream.Close();
        }
        if (response != null)
          response.Close();
        if (this.ftpDownLoadFileSuccess != null)
          this.ftpDownLoadFileSuccess.BeginInvoke(fileName, (AsyncCallback) null, (object) null);
        Thread.CurrentThread.Abort();
      }))
      {
        IsBackground = true
      }.Start();
      return statuscode;
    }

    private void setBarMaxmum(ProgressBar proBar, int value)
    {
      proBar.Maximum = value;
    }

    private void setBarValue(ProgressBar proBar, Label label, int value, string percent)
    {
      proBar.Value = value;
      label.Text = percent;
    }

    private delegate FtpStatusCode UploadFileEventHandler(ref ftpUDParams ftpParam);

    private delegate void ProcessBarValueEventHandler(ProgressBar proBar, Label label, int value, string percent);

    private delegate void ProcessBarMaxmumEventHandler(ProgressBar proBar, int value);

    public delegate void FtpUploadFileSuccessEventHandler(string filename);

    public delegate void FtpUploadFileFailedEventHandler(string filename, string msg);

    public delegate void FtpDownloadFileSuccessEventHandler(string filename);

    public delegate void FtpDownloadFileFailedEventHandler(string filename, string msg);

    public delegate void FtpConnectFailedEventHandler(string filename, string msg);
  }
}
