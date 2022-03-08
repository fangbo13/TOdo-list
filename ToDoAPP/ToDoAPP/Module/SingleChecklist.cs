
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Module
{
     // Customised acceptance of results
    public class SingleChecklist : ViewModelBase
    {
        public Checklist Checklist { get; set; }

        private ObservableCollection<ChecklistDetail> checklists;

        public ObservableCollection<ChecklistDetail> ChecklistDetails
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }
    }
}