using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Module;

namespace ToDoAPP.ViewModel
{
   public class ItemDetailViewModel:ViewModelBase
    {
        public ItemDetailViewModel(ObservableCollection<TaskInfo> TaskInfos)
        {

        }
        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }
    }
}
   
