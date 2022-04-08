using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoAPP.Core;

namespace ToDoAPP.Interfaces
{
    public interface APIInterface
    {
        Result<JObject> UserLogin(string username, string pwd);

        Result<JObject> AddParentListName(string ParentTitleName, string UserID);


        Result<List<JObject>> GetListTile(string UserID);


        Result<JObject> AddSchedule(string title, string content, string remindtime, string listid);

        Result<List<JObject>> GetSchedule(string listid);

        Result<JObject> DeleteDetail(string DetaillID);

        Result<JObject> DeleteList(string id);

        Result<JObject> ModifyListName(string id, string name);
    }
}
