using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Module;

namespace ToDoApp.Core
{
    // Creating the EF context DbContext
    public class ToDoContext : DbContext
    {
        private string databasePath;
        //Database path
        public ToDoContext(string databasePath)
        {
            this.databasePath = databasePath;
        }
        //Write interfaces and implementation classes for database operations
        //The following configures the database link and the initial creation of the EF
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<ChecklistDetail> ChecklistDetails { get; set; }
    }
}
