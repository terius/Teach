using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewTeacher
{
    public class OnlineInfo
    {
        public IList<OnlineListResult> OnLineList { get; set; }
        public delegate void OnlineChangeHandle(object sender, OnlineEventArgs e);
        public event OnlineChangeHandle OnLineChange;
        public event OnlineChangeHandle AddOnLine;
        public event OnlineChangeHandle DelOnLine;

        public OnlineInfo()
        {
            OnLineList = new List<OnlineListResult>();

        }


        public void OnOnlineChange(IList<OnlineListResult> onLineList)
        {
            this.OnLineList = onLineList;
            OnlineEventArgs e = new OnlineEventArgs(onLineList);
            OnLineChange(this, e);
        }

        public void OnNewUserLoginIn(IList<OnlineListResult> onLineList)
        {
            AddNewOnLine(onLineList[0]);
            OnlineEventArgs e = new OnlineEventArgs(onLineList);
            AddOnLine(this, e);
        
        }

        public void OnUserLoginOut(IList<OnlineListResult> onLineList)
        {
            DeleteOnLine(onLineList[0]);
            OnlineEventArgs e = new OnlineEventArgs(onLineList);
            DelOnLine(this, e);
        }


        private void AddNewOnLine(OnlineListResult newUser)
        {
            if (!OnLineList.Any(d => d.username == newUser.username))
            {
                OnLineList.Add(newUser);
            }
        }


        private void DeleteOnLine(OnlineListResult user)
        {

            var item = OnLineList.FirstOrDefault(d => d.username == user.username);
            if (item != null)
            {
                OnLineList.Remove(item);
            }


        }
    }

    public class OnlineEventArgs : EventArgs

    {
        private IList<OnlineListResult> _onLineList;

        public OnlineEventArgs(IList<OnlineListResult> onLineList)
        {
            this._onLineList = onLineList;
        }
        public IList<OnlineListResult> OnLines
        {
            get { return _onLineList; }
        }


    }
}
