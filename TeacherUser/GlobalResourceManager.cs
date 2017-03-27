/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net 
 * * 论坛：http://bbs.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2015-01-28
 * * 说明：GlobalResourceManager.cs
 * *
********************************************************************/

using Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public class GlobalResourceManager
    {
        #region 初始化表情
        public static void Initialize() {
            try {
                #region Emotion
                List<string> tempList = FileHelper.GetOffspringFiles(AppDomain.CurrentDomain.BaseDirectory + "Face\\");
                List<string> emotionFileList = new List<string>();
                foreach (string file in tempList) {
                    string name = file.ToLower();
                    if (name.EndsWith(".bmp") || name.EndsWith(".jpg") || name.EndsWith(".jpeg") || name.EndsWith(".png") || name.EndsWith(".gif")) {
                        emotionFileList.Add(name);
                    }
                }
                emotionFileList.Sort(new Comparison<string>(CompareEmotionName));
                List<Image> emotionList = new List<Image>();
                for (int i = 0; i < emotionFileList.Count; i++) {
                    emotionList.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Face\\" + emotionFileList[i]));
                }
                GlobalResourceManager.emotionList = emotionList;
                #endregion
            } catch (Exception ee) {
                MessageBox.Show("加载系统资源时，出现错误。" + ee.Message);
            }
        }
        public static int CompareEmotionName(string a, string b) {
            if (a.Length != b.Length) {
                return a.Length - b.Length;
            }
            return a.CompareTo(b);
        } 
        #endregion

        #region EmotionList、EmotionDictionary
        private static List<Image> emotionList;
        public static List<Image> EmotionList {
            get { return emotionList; }
        }
        private static Dictionary<uint, Image> emotionDictionary;
        public static Dictionary<uint, Image> EmotionDictionary {
            get {
                if (emotionDictionary == null) {
                    emotionDictionary = new Dictionary<uint, Image>();
                    for (uint i = 0; i < emotionList.Count; i++) {
                        emotionDictionary.Add(i, emotionList[(int)i]);
                    }
                }
                return emotionDictionary;
            }
        }
        #endregion
    }
}
