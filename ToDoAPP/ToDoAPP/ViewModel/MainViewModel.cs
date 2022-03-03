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
            //功能模块
            MenuModels = new ObservableCollection<MenuGroup>();

            MenuModels.Add(new MenuGroup("", new List<MenuModel>()
            {
                 new MenuModel() { IconFont = "\xe635", Title = "My day", BackColor = "#218868", },
                 new MenuModel() { IconFont = "\xe6b6", Title = "Important", BackColor = "#EE3B3B", },
                 new MenuModel() { IconFont = "\xe6e1", Title = "Planned", BackColor = "#218868", },
                 new MenuModel() { IconFont = "\xe614", Title = "Assigned Task", BackColor = "#EE3B3B", },
                 new MenuModel() { IconFont = "\xe755", Title = "Task", BackColor = "#218868", }


        }));
            //清单模块
            MenuModels.Add(new MenuGroup("", new List<MenuModel>()
            {
                 new MenuModel() { IconFont = "\xe63b", Title = "LIST", BackColor = "#00BFFF", },
                 new MenuModel() { IconFont = "\xe63b", Title = "LIST2", BackColor = "#00BFFF", },

            }));

        }
        private ObservableCollection<MenuGroup> menuModels;


        public ObservableCollection<MenuGroup> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }

        }

    }
}