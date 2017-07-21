using Common;
using System;

namespace Model
{
    public class PrivateChatRequest: SendFileView
    {
        public string receivename { get; set; }

        public string SendUserName { get; set; }

        public string msg { get; set; }

        public string guid { get; set; }

        public string SendDisplayName { get; set; }

        public ClientRole clientRole { get; set; }
    }


    //public class AddChatRequest
    //{

    //    public ChatType ChatType { get; set; }
    //    //   public string SendUserName { get; set; }

    //    //  public string SendDisplayName { get; set; }

    //    public string UserName { get; set; }

    //    public string DisplayName { get; set; }


    //    public ClientRole UserType { get; set; }


    //    public string Message { get; set; }
    //}


    public class ChatMessage : SendFileView
    {
        /// <summary>
        /// 聊天类型
        /// </summary>
        public ChatType ChatType { get; set; }
        /// <summary>
        /// 发送者用户名
        /// </summary>
        public string SendUserName { get; set; }
        /// <summary>
        /// 发送者姓名
        /// </summary>
        public string SendDisplayName { get; set; }
        /// <summary>
        /// 接收者用户名
        /// </summary>
        public string ReceieveUserName { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 发送者身份
        /// </summary>
        public ClientRole UserType { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get { return SendDisplayName + " (" + SendTime.ToString("yyyy-MM-dd HH:mm:ss") + ")"; } }

        // public ChatBoxContent Content { get; set; }
        ///// <summary>
        ///// 消息类型
        ///// </summary>
        //public MessageType MessageType { get; set; }
        ///// <summary>
        ///// 下载地址
        ///// </summary>
        //public string DownloadFileUrl { get; set; }



        public ChatMessage(string _sendUserName,
            string _sendDisplayName,
            string _receieveUserName,
            string _message,
            ClientRole _userType
            )
        {
            this.SendUserName = _sendUserName;
            this.SendDisplayName = _sendDisplayName;
            this.ReceieveUserName = _receieveUserName;
            this.SendTime = DateTime.Now;
            this.Message = _message;
            UserType = _userType;
            MessageType = MessageType.String;
        }

        public ChatMessage(string _sendUserName,
          string _sendDisplayName,
          string _receieveUserName,
          string _message,
          ClientRole _userType,
          MessageType MessageType
          ) : this(_sendUserName, _sendDisplayName, _receieveUserName, _message, _userType)
        {
            this.MessageType = MessageType;

        }


        public ChatMessage()
        {

        }
    }
}
