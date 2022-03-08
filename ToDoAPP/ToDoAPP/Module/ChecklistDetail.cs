using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Module
{
    public partial class ChecklistDetail
    {
       // Primary key
        public string Id { get; set; }

        // Associated foreign key ID
        public string ChecklistId { get; set; }

        // Details content
        public string Content { get; set; }

    }

    public partial class ChecklistDetail : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;

        // Favorite
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged(); }
        }

        // Delete
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; RaisePropertyChanged(); }
        }
    }
}