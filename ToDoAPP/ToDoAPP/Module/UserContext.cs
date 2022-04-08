using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAPP.Module
{
    public class UserContext
    {

        private static string _UserID;


        public static string UserID

        {

            get { return _UserID; }

            set { _UserID = value; }

        }

        private static string _UserName;


        public static string UserName

        {

            get { return _UserName; }

            set { _UserName = value; }

        }

        private static string _Remark;


        public static string Remark

        {

            get { return _Remark; }

            set { _Remark = value; }

        }

        private static string _UserParameter;


        public static string UserParameter

        {

            get { return _UserParameter; }

            set { _UserParameter = value; }

        }

        private static string _PageTitle;


        public static string PageTitle

        {

            get { return _PageTitle; }

            set { _PageTitle = value; }

        }
    }
}
