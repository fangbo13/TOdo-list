using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Module
{
    public partial class ChecklistDetail
    {
        // 主键
        public string Id { get; set; }

        // 关联的外键ID
        public string ChecklistId { get; set; }

        // 明细内容
        public string Content { get; set; }

    }

    public partial class ChecklistDetail : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;

        // 收藏
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged(); }
        }

        // 删除
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; RaisePropertyChanged(); }
        }
    }
}
