using Common;
using Model;
using SharedForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewTeacher
{
    public class OnlineInfo
    {
        public IList<OnlineListResult> OnLineList { get; set; }
        public delegate void OnlineChangeHandle(object sender, OnlineEventArgs e);
        public delegate void OnlineDelHandle(UserLogoutResponse e);
        public event OnlineChangeHandle OnLineChange;
        public event OnlineChangeHandle AddOnLine;
        public event OnlineDelHandle DelOnLine;
        public IList<OnlineListResult> LoginedStuList { get; set; }

        public OnlineInfo()
        {
            OnLineList = new List<OnlineListResult>();

        }
        public IList<OnlineListResult> GetStudentOnlineList()
        {
            return OnLineList.Where(d => d.clientRole == ClientRole.Student).ToList();
        }

        public void OnOnlineChange(IList<OnlineListResult> onLineList)
        {
            this.OnLineList = onLineList;
            LoginedStuList = onLineList.Where(d => d.clientRole == ClientRole.Student).ToList(); ;
            OnlineEventArgs e = new OnlineEventArgs(onLineList);
            OnLineChange(this, e);
        }

        public void OnNewUserLoginIn(IList<OnlineListResult> onLineList)
        {
            AddNewOnLine(onLineList[0]);
            GlobalVariable.RefreshTeamMember(onLineList[0].username, true);
            OnlineEventArgs e = new OnlineEventArgs(onLineList);
            AddOnLine(this, e);

        }

        public void OnUserLoginOut(UserLogoutResponse loginOutInfo)
        {
            DeleteOnLine(loginOutInfo);
            GlobalVariable.RefreshTeamMember(loginOutInfo.username, false);
            DelOnLine(loginOutInfo);
        }


        private void AddNewOnLine(OnlineListResult newUser)
        {
            if (!OnLineList.Any(d => d.username == newUser.username))
            {
                OnLineList.Add(newUser);
            }

            if (!LoginedStuList.Any(d => d.username == newUser.username))
            {
                if (newUser.clientRole == ClientRole.Student)
                {
                    LoginedStuList.Add(newUser);
                }
            }
        }


        private void DeleteOnLine(UserLogoutResponse user)
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
