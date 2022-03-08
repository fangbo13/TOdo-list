using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using ToDoApp.Module;

namespace ToDoApp.Core
{
    public class Constants
    {
        // Local database script path
        public static string DatabasePath
        {
            get
            {          //Return to database
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ToDo.db");
            }
        }

        public static async void InitAsync(ToDoContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Checklists.Any())
                {
                    await context.Checklists.AddRangeAsync(new Checklist[]
                    {
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe635", Title = "My Day", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe6b6", Title = "Important", BackColor = "#EE3B3B", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe6e1", Title = "Planned ", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe614", Title = "Assigned to me", BackColor = "#EE3B3B", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe755", Title = "Tasks", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "Shopping List", BackColor = "#009ACD", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "Grocery list", BackColor = "#009ACD", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "To-Do List", BackColor = "#009ACD", },
                });
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
