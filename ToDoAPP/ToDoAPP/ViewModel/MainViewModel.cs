using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Module;

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            menuModels.Add(new MenuModel() { IconFont = "\xe635", Title = "My day", BackColor = "#218868", });
            menuModels.Add(new MenuModel() { IconFont = "\xe6b6", Title = "Important", BackColor = "#EE3B3B", });
            menuModels.Add(new MenuModel() { IconFont = "\xe6e1", Title = "Planned", BackColor = "#218868", });
            menuModels.Add(new MenuModel() { IconFont = "\xe614", Title = "Assigned Task", BackColor = "#EE3B3B", });
            menuModels.Add(new MenuModel() { IconFont = "\xe755", Title = "Task", BackColor = "#218868", });
        }
        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }
        }

    }
}