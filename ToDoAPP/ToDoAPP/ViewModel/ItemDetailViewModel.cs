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
        public ItemDetailViewModel(SingleChecklist checklist)
        {
            this.SingleChecklist = checklist;

            ExcludeCommand = new RelayCommand<ChecklistDetail>(arg =>
            {
                if (arg.IsDeleted)
                    arg.IsDeleted = false;
                else
                    arg.IsDeleted = true;
            });
           KeppCommand = new RelayCommand<ChecklistDetail>(arg =>
            {
                if (arg.IsFavorite)
                    arg.IsFavorite = false;
                else
                    arg.IsFavorite = true;
            });


            AddCommand = new RelayCommand(AddTask);
            DeleteCommand = new RelayCommand<ChecklistDetail>(t=> DeleteTask(t));
        }



        private SingleChecklist singleChecklist;

        public SingleChecklist SingleChecklist
        {
            get { return singleChecklist; }
            set { SingleChecklist = value; RaisePropertyChanged(); }
        }


        private string content = string.Empty;

        // 编辑器显示内容
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }


        //触发时间为Taskinfo，去触发收藏功能和完成任务功能
        public RelayCommand<ChecklistDetail> ExcludeCommand { get; private set; }/*移除添加内容*/
        public RelayCommand<ChecklistDetail> KeppCommand { get; private set; }/*收藏内容*/



        //新增任务绑定指令
        public RelayCommand AddCommand { get; private set; }
        //删除任务绑定指令
        public RelayCommand<ChecklistDetail> DeleteCommand { get; private set; }




        //添加任务功能完成
        public void AddTask()
        {
            if (string.IsNullOrWhiteSpace(Content)) return;//哦判断是否为空
            SingleChecklist.ChecklistDetails.Add(new ChecklistDetail() { Content = Content });//添加任务到 taskinfo
            Content = string.Empty;
        }

        //添加删除任务功能完成
        public void DeleteTask(ChecklistDetail t)
        {
            SingleChecklist.ChecklistDetails.Remove(t);
        }
    }
}
   
