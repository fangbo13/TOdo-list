using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Module;

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IToDoService toDoServive;
        public MainViewModel()
        {
            toDoServive = ServiceProvider.Instance.Get<IToDoService>();
            Checklists = new ObservableCollection<Checklist>();
            Checklists.Add(new Checklist() { IconFont = "\xe635", Title = "My day", BackColor = "#218868", });
            Checklists.Add(new Checklist() { IconFont = "\xe6b6", Title = "Important", BackColor = "#EE3B3B", });
            Checklists.Add(new Checklist() { IconFont = "\xe6e1", Title = "Planned", BackColor = "#218868", });
            Checklists.Add(new Checklist() { IconFont = "\xe614", Title = "Assigned Task", BackColor = "#EE3B3B", });
            Checklists.Add(new Checklist() { IconFont = "\xe755", Title = "Task", BackColor = "#218868", });
            Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "Shopping List", BackColor = "#00BFFF", });
            Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "Grocery list", BackColor = "#00BFFF", });
            Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "To-Do List", BackColor = "#00BFFF", });


        }

        private ObservableCollection<Checklist> checklists;

        public ObservableCollection<Checklist> Checklists
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }
    }
}