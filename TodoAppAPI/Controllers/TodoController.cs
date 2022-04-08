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
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        public Result Login(string username,string userpwd)
        {
            Result result = new Result();
            string sql = "SELECT * FROM userinfo WHERE username='"+ username + "'";
            DataSet dt= SQLiteHelper.ExecuteDataset(sql,new Dictionary<string, string>());
            if (dt.Tables[0].Rows.Count>0)
            {
                if (dt.Tables[0].Rows[0]["password"].ToString()==userpwd)
                {
                    result.ResultCode = "200";
                    result.Success = true;
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
    }
}