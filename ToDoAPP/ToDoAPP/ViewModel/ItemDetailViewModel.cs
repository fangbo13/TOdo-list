using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
            this.TaskInfos = TaskInfos;

            TaskInfos.Add(new TaskInfo() {Content = "fdgjkhdfgjhdfg" });
            TaskInfos.Add(new TaskInfo() { Content = "fdgjkhdfgjhdfg" });


            ExcludeCommand = new RelayCommand<TaskInfo>(arg =>
            {
                if (arg.IsDeleted)
                    arg.IsDeleted = false;
                else
                    arg.IsDeleted = true;
            });

           KeppCommand = new RelayCommand<TaskInfo>(arg =>
            {
                if (arg.IsFavorite)
                    arg.IsFavorite = false;
                else
                    arg.IsFavorite = true;
            });
        }
        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }

        //触发时间为Taskinfo，去触发收藏功能和完成任务功能
        public RelayCommand<TaskInfo> ExcludeCommand { get; private set; }/*移除添加内容*/
        public RelayCommand<TaskInfo> KeppCommand { get; private set; }/*收藏内容*/
    }
}
   
