using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Interfaces;
using ToDoApp.Module;

namespace ToDoAPP.Service
{
    public class ToDoService : IToDoService
    {
        public Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddToDoGroupAsync(Checklist checklist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDoGroupByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDoInfoByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Checklist>> GetToDoListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ChecklistDetail>> GetToDoListDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChecklistDetail>> GetToDoListDetailByTextAsync(string text)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDeleteStatus(string id, bool status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFavoriteStatus(string id, bool status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoGroupNameAsync(string id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
