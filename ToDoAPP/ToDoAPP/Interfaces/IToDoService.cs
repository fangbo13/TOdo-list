using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Module;

namespace ToDoApp.Interfaces
{
    public interface IToDoService
    {
        // Get a list of home page data
        Task<List<Checklist>> GetToDoListAsync();

        // Get a list of data for the inventory details
        Task<SingleChecklist> GetToDoListDetailAsync(string id);

        // Search results by content
        Task<List<ChecklistDetail>> GetToDoListDetailByTextAsync(string text);


        // Add a new listing to the home page
        Task<bool> AddToDoGroupAsync(Checklist checklist);

        // Delete the list from the front page
        Task<bool> DeleteToDoGroupByIdAsync(string id);

        // Delete books from the list
        Task<bool> DeleteToDoInfoByIdAsync(string id);


        // Update the name of the home list
        Task<bool> UpdateToDoGroupNameAsync(string id, string name);

        // Add details
        Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail);

        // To delete or not to delete
        Task<bool> UpdateDeleteStatus(string id, bool status);

        // To collect or not to collect
        Task<bool> UpdateFavoriteStatus(string id, bool status);

    }
}
