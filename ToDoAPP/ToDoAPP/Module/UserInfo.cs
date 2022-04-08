using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAPP.Module
{
    public class UserInfo : ViewModelBase
    {
        private string _UserID;

        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                RaisePropertyChanged(nameof(UserID));
            }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        private string _UserPwd;

        public string UserPwd
        {
            get { return _UserPwd; }
            set
            {
                _UserPwd = value;
                RaisePropertyChanged(nameof(UserPwd));
            }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                RaisePropertyChanged(nameof(Remark));
            }
        }

    }
}
