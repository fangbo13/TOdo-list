using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Module;

//后台业务代码
namespace ToDoAPP.ViewModel
{
    class ItemDetailViewModel : ViewModelBase
    {
        public ItemDetailViewModel(ObservableCollection<TaskInfo> TaskInfos)
        {
            this.TaskInfos = TaskInfos;//绑定值

            TaskInfos.Add(new TaskInfo() { });//添加测试内容
            TaskInfos.Add(new TaskInfo() { });
            TaskInfos.Add(new TaskInfo() { });
        }

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }
    }
}

