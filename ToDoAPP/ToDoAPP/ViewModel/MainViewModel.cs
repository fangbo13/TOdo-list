using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Module;


//Checklists = new ObservableCollection<Checklist>();
//Checklists.Add(new Checklist() { IconFont = "\xe635", Title = "My day", BackColor = "#218868", });
//Checklists.Add(new Checklist() { IconFont = "\xe6b6", Title = "Important", BackColor = "#EE3B3B", });
//Checklists.Add(new Checklist() { IconFont = "\xe6e1", Title = "Planned", BackColor = "#218868", });
//Checklists.Add(new Checklist() { IconFont = "\xe614", Title = "Assigned Task", BackColor = "#EE3B3B", });
//Checklists.Add(new Checklist() { IconFont = "\xe755", Title = "Task", BackColor = "#218868", });
//Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "Shopping List", BackColor = "#00BFFF", });
//Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "Grocery list", BackColor = "#00BFFF", });
//Checklists.Add(new Checklist() { IconFont = "\xe63b", Title = "To-Do List", BackColor = "#00BFFF", });

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IToDoService toDoService;
        public MainViewModel()
        {
            toDoService = ServiceProvider.Instance.Get<IToDoService>();
            OpenCommand = new RelayCommand<Checklist>(t => OpenPage(t));
            AddCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send("", "Add");
            });
            QueryCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send("", "Query");
            });
        }

        private ObservableCollection<Checklist> checklists;

        public ObservableCollection<Checklist> Checklists
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }

        public RelayCommand<Checklist> OpenCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand QueryCommand { get; private set; }

        public async void InitMainViewModel()
        {
            var cks = await toDoService.GetToDoListAsync();
            if (cks != null)
            {
                Checklists = new ObservableCollection<Checklist>();
                cks.ForEach(arg =>
                {
                    Checklists.Add(arg);
                });
            }
        }

        public async void OpenPage(Checklist c)
        {
            if (c != null)
            {
                var cks = await toDoService.GetToDoListDetailAsync(c.Id);
                Messenger.Default.Send(cks, "OpenDetailPage");
            }
        }

        public async void AddCheckList(Checklist c)
        {
            var r = await toDoService.AddToDoGroupAsync(c);
            if (r)
                Checklists.Add(c);
        }
    }
}