// Decompiled with JetBrains decompiler
// Type: TcpConnectJson.RecordVoice
// Assembly: TcpConnect, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22F34CB8-D6B3-4751-8C6A-D41233928FAE
// Assembly location: D:\Study2\教育系统\1209\Teach\TeacherUser\Libs\DLL\TcpConnect.dll

using AxWMPLib;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace TcpConnectJson
{
  public class RecordVoice
  {
    private Ffmpeg f = (Ffmpeg) null;
    private AxWindowsMediaPlayer mediaPlayer = (AxWindowsMediaPlayer) null;
    private RecordVoice.playVoiceCallBackHandler voicePlayer;

    public RecordVoice(AxWindowsMediaPlayer player)
    {
      this.f = new Ffmpeg();
      this.mediaPlayer = player;
      this.voicePlayer = new RecordVoice.playVoiceCallBackHandler(this.playVoiceInvoke);
    }

    [DllImport("winmm.dll", CharSet = CharSet.Auto)]
    public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

    public void beginRecord()
    {
      RecordVoice.mciSendString("set wave bitpersample 8", "", 0, 0);
      RecordVoice.mciSendString("set wave samplespersec 20000", "", 0, 0);
      RecordVoice.mciSendString("set wave channels 1", "", 0, 0);
      RecordVoice.mciSendString("set wave format tag pcm", "", 0, 0);
      RecordVoice.mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
      RecordVoice.mciSendString("record movie", "", 0, 0);
    }

    public string stopRecord()
    {
      RecordVoice.mciSendString("stop movie", "", 0, 0);
      string name = this.generateName();
      string str1 = "cache\\video\\" + name + ".wav";
      RecordVoice.mciSendString("save movie " + str1, "", 0, 0);
      RecordVoice.mciSendString("close movie", "", 0, 0);
      string str2 = "cache\\video\\" + name + ".amr";
      this.f.execute(" -y -i " + str1 + " -ar 8000 -ab 12.2k -ac 1 " + str2);
      return str2;
    }

    public void playVoice(string voiceName)
    {
      if (this.mediaPlayer == null)
        return;
      string[] strArray = voiceName.Split('.');
      string str1 = strArray[0];
      if (strArray.Length > 1 && !strArray[1].Equals("amr"))
      {
        this.voicePlayer("cache\\video\\" + voiceName);
      }
      else
      {
        string str2 = "cache\\video\\" + str1 + ".amr";
        string voice = "cache\\video\\" + str1 + ".mp3";
        this.f.execute(" -y -i " + str2 + " -ar 8000 -ab 12.2k -ac 1 " + voice);
        this.voicePlayer(voice);
      }
    }

    private void playVoiceInvoke(string voiceName)
    {
      if (this.mediaPlayer == null)
        return;
      this.mediaPlayer.URL = voiceName;
      this.mediaPlayer.Ctlcontrols.play();
    }

    private string generateName()
    {
      return DateTime.Now.ToString("MMddHHmmssff", (IFormatProvider) DateTimeFormatInfo.InvariantInfo);
    }

    private byte[] GetFileByte(string fileName)
    {
      FileStream fileStream = (FileStream) null;
      byte[] numArray = new byte[0];
      try
      {
        fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
        binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
        return binaryReader.ReadBytes((int) binaryReader.BaseStream.Length);
      }
      catch
      {
        return numArray;
      }
      finally
      {
        if (fileStream != null)
          fileStream.Close();
      }
    }

    private bool writeFile(byte[] pReadByte, string fileName)
    {
      FileStream fileStream = (FileStream) null;
      try
      {
        fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
        fileStream.Write(pReadByte, 0, pReadByte.Length);
      }
      catch
      {
        return false;
      }
      finally
      {
        if (fileStream != null)
          fileStream.Close();
      }
      return true;
    }

    private delegate void playVoiceCallBackHandler(string voice);
  }
}
