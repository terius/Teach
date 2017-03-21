using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeacherUser
{
    public partial class ConfServerIP : Form
    {
        public ConfServerIP()
        {
            InitializeComponent();
        }

        private void ServerIP_btn_Click(object sender, EventArgs e)//设置服务器IP
        {
            string ip = this.ServerIP_tb.Text;
            SetValue("serverIP",ip);
           // MessageBox.show("IP修改成功，请重新运行软件");
            this.Close();
            Application.Restart();
        }

        public static void SetValue(string AppKey, string AppValue)
        {
            System.Xml.XmlDataDocument xDoc = new System.Xml.XmlDataDocument();
            // xDoc.Load("../../App.config");
            string filePath = System.Windows.Forms.Application.ExecutablePath + ".config";
            xDoc.Load(filePath);//

            System.Xml.XmlNodeList nodeList = null;
            nodeList = xDoc.SelectSingleNode("//configuration//appSettings").ChildNodes;
            if (nodeList != null)
            {
                foreach (System.Xml.XmlNode xn in nodeList)
                {
                    System.Xml.XmlElement xe = xn as System.Xml.XmlElement;
                    if (xe != null)
                    {
                        if (xe.Name == "add")
                        {
                            string s = xe.GetAttribute("key");
                            string p = xe.GetAttribute("value");
                            if (s == AppKey)
                            {
                                xe.SetAttribute("value", AppValue);
                            }
                        }

                    }
                }
            }
            xDoc.Save(filePath);
            
        }
    }
}
