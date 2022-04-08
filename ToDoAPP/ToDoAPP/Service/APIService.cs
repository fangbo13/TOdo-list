using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPP.Core;
using ToDoAPP.Core.Helper;
using ToDoAPP.Interfaces;

namespace ToDoAPP.Service
{
    public class APIService : APIInterface
    {
        private const string GET_LOGIN_URL = "/api/Todo/Login";

        private const string GET_ADDPARENTLISTNAME_URL = "/api/Todo/AddParentListName";

        private const string GET_LISTTILE_URL = "/api/Todo/GetListTile";

        private const string GET_ADDSCHEDULE_URL = "/api/Todo/AddSchedule";

        private const string GET_SCHEDULE_URL = "/api/Todo/GetSchedule";

        private const string GET_DELETEDETAIL_URL = "/api/Todo/DeleteDetail";

        private const string GET_DELETELIST_URL = "/api/Todo/DeleteList";

        private const string GET_MODIFYLISTNAME_URL = "/api/Todo/ModifyListName";

        public Result<JObject> UserLogin(string username, string pwd)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_LOGIN_URL, new { username = username, userpwd = pwd }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }
        public Result<JObject> AddParentListName(string ParentTitleName, string UserID)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_ADDPARENTLISTNAME_URL, new { ParentTitleName = ParentTitleName, UserID = UserID }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

        public Result<List<JObject>> GetListTile(string UserID)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<List<JObject>>>(GET_LISTTILE_URL, new { UserID = UserID }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<List<JObject>> result = new Result<List<JObject>>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

        public Result<JObject> AddSchedule(string title, string content, string remindtime, string listid)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_ADDSCHEDULE_URL, new
                {
                    title = title,
                    content = content,
                    remindtime = remindtime,
                    listid = listid
                }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

        public Result<List<JObject>> GetSchedule(string listid)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<List<JObject>>>(GET_SCHEDULE_URL, new
                {
                    listid = listid
                }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<List<JObject>> result = new Result<List<JObject>>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

        public Result<JObject> DeleteDetail(string DetaillID)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_DELETEDETAIL_URL, new { id = DetaillID }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

        public Result<JObject> DeleteList(string id)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_DELETELIST_URL, new { id = id }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }


        public Result<JObject> ModifyListName(string id, string name)
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<object, Result<JObject>>(GET_MODIFYLISTNAME_URL, new { id = id, name = name }, System.Net.Http.HttpMethod.Post);
                return Api_result;
            }
            catch (Exception e)
            {
                Result<JObject> result = new Result<JObject>();
                result.ResultMsg = e.Message;
                result.ResultCode = "201";
                return result;
            }
        }

    }
}
