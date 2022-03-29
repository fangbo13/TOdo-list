using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPP.Core;
using ToDoAPP.Core.Helper;

namespace ToDoAPP.Service
{
    public class APIService
    {
        private const string GET_FTPINFO_URL = "/api/jkcEquipment/GetFtpInfo";
     
        public Result<string> GetFtpInfo()
        {
            try
            {
                var Api_result = HttpHelper.Instance.Request<Result<string>>(GET_FTPINFO_URL, System.Net.Http.HttpMethod.Post);
                List<JObject> result = JsonConvert.DeserializeObject<List<JObject>>(Api_result.ResultData);
                foreach (var item in result)
                {
                    //MapInfo m = new MapInfo { Name = item.SHIFTNAME, Value = item.SHIFTNAME };
                    //MInfo.Add(m);
                }

                if (result == null)
                    return new Result<string>();
                return Api_result;
            }
            catch (Exception e)
            {
                Result<string> result = new Result<string>();
                result.ResultMsg= e.Message ;
                result.ResultCode = "201";
                return result;
            }
        }
    }
}
