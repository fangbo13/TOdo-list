using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Module;

namespace ToDoApp.Interfaces
{
    public interface IToDoService
    {
        // 获取首页数据列表
        Task<List<Checklist>> GetToDoListAsync();

        // 获取清单明细的数据列表
        Task<List<ChecklistDetail>> GetToDoListDetailAsync(string id);

        // 根据内容搜索结果
        // </summary>
        Task<List<ChecklistDetail>> GetToDoListDetailByTextAsync(string text);

        // 首页添加新的清单
        Task<bool> AddToDoGroupAsync(Checklist checklist);

        // 删除首页的清单
        Task<bool> DeleteToDoGroupByIdAsync(string id);

        // 删除明细表当中的书
        Task<bool> DeleteToDoInfoByIdAsync(string id);

        // 更新首页清单的名称
        Task<bool> UpdateToDoGroupNameAsync(string id, string name);

        /// 添加明细
        Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail);

        // 是否删除
        Task<bool> UpdateDeleteStatus(string id, bool status);

        //是否收藏
        Task<bool> UpdateFavoriteStatus(string id, bool status);

    }
}
