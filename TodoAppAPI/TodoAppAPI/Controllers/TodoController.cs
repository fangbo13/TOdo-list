using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoAppAPI.Common;
using TodoAppAPI.Models;

namespace TodoAppAPI.Controllers
{
    public class TodoController : ApiController
    {

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/Login")]
        public Result Login(dynamic obj)
        {
            string username = obj.username;
            string userpwd = obj.userpwd;
            Result result = new Result();
            string sql = "SELECT * FROM userinfo WHERE username='" + username + "'";
            DataTable dt = SQLiteHelper.ExecuteDataset(sql, new Dictionary<string, string>()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["password"].ToString() == userpwd)
                {
                    result.ResultCode = "200";
                    result.Success = true;
                    result.ResultData = new
                    {
                        ID = dt.Rows[0]["id"].ToString(),
                        UserName = dt.Rows[0]["username"].ToString(),
                        Remark = dt.Rows[0]["remark"].ToString()
                    };
                    result.ResultMsg = "Login successful!";
                }
                else
                {
                    result.ResultCode = "201";
                    result.Success = false;
                    result.ResultMsg = "Password error!";
                }
            }
            else
            {
                result.ResultCode = "202";
                result.Success = false;
                result.ResultMsg = "Account does not exist!";
            }
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/AddParentListName")]
        public Result AddParentListName(dynamic obj)
        {
            Result result = new Result();
            string ParentTitleName = obj.ParentTitleName;
            string UserID = obj.UserID;

            string sql_GetMaxID = "SELECT ID FROM listinfo ORDER BY ID DESC";
            DataTable dt = SQLiteHelper.ExecuteDataset(sql_GetMaxID, new Dictionary<string, string>()).Tables[0];
            int InserId = 0;
            if (dt.Rows.Count > 0)
            {
                InserId = Convert.ToInt32(dt.Rows[0]["ID"].ToString()) + 1;
            }
            string sql_Insert = "INSERT INTO listinfo(ID, LISTNAME, CREATEUSERID, CREATETIME) VALUES (" + InserId + ", '" + ParentTitleName + "', " + UserID + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            if (SQLiteHelper.ExecuteNonQuery(sql_Insert) > 0)
            {
                result.ResultCode = "200";
                result.Success = true;
                result.ResultMsg = "Added successfully!";
            }
            else
            {
                result.ResultCode = "201";
                result.Success = false;
                result.ResultMsg = "Add failed!";
            }
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/GetListTile")]
        public Result GetListTile(dynamic obj)
        {
            Result result = new Result();
            string UserID = obj.UserID;
            string sql = "SELECT *,(SELECT COUNT(*) FROM schedule WHERE LISTID=t.ID) AS CHILDTOTAL FROM listinfo t WHERE CREATEUSERID=" + UserID + " ORDER BY ID DESC";
            DataTable dt = SQLiteHelper.ExecuteDataset(sql, new Dictionary<string, string>()).Tables[0];
            result.ResultCode = "200";
            result.Success = true;
            result.ResultMsg = "Query was successful!";
            result.ResultData = dt;
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/AddSchedule")]
        public Result AddSchedule(dynamic obj)
        {
            Result result = new Result();
            string title = obj.title;
            string content = obj.content;
            string remindtime = obj.remindtime;
            string listid = obj.listid;

            string sql_GetMaxID = "SELECT ID FROM schedule ORDER BY ID DESC";
            DataTable dt = SQLiteHelper.ExecuteDataset(sql_GetMaxID, new Dictionary<string, string>()).Tables[0];
            int InserId = 0;
            if (dt.Rows.Count > 0)
            {
                InserId = Convert.ToInt32(dt.Rows[0]["ID"].ToString()) + 1;
            }
            string sql_Insert = "INSERT INTO schedule(ID, TITLE, CONTENT, CREATETIME, CREATEUSERID, REMINDTIME, LISTID) VALUES (" + InserId + ", '" + title + "', '" + content + "', '" + remindtime + "', ' ', '022-04-01 12:00:00', " + listid + ");";
            if (SQLiteHelper.ExecuteNonQuery(sql_Insert) > 0)
            {
                result.ResultCode = "200";
                result.Success = true;
                result.ResultMsg = "Added successfully!";
            }
            else
            {
                result.ResultCode = "201";
                result.Success = false;
                result.ResultMsg = "Add failed!";
            }
            return result;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/GetSchedule")]
        public Result GetSchedule(dynamic obj)
        {
            Result result = new Result();
            string listid = obj.listid;
            string sql = "SELECT * FROM schedule WHERE 1=1 ";
            if (!string.IsNullOrEmpty(listid))
            {
                sql += "AND LISTID=" + listid + "";
            }
            DataTable dt = SQLiteHelper.ExecuteDataset(sql, new Dictionary<string, string>()).Tables[0];
            result.ResultCode = "200";
            result.Success = true;
            result.ResultMsg = "Query was successful!";
            result.ResultData = dt;
            return result;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/Todo/DeleteDetail")]
        public Result DeleteDetail(dynamic obj)
        {
            Result result = new Result();
            string id = obj.id;
            string sql = "DELETE FROM schedule WHERE ID=" + id;
            if (SQLiteHelper.ExecuteNonQuery(sql)>0)
            {
                result.ResultCode = "200";
                result.Success = true;
                result.ResultMsg = "Delete was successful!";
            }
            else
            {
                result.ResultCode = "201";
                result.Success = false;
                result.ResultMsg = "Delete was failed!";
            }
            return result;
        }
    }
}