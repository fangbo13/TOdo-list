using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoAPP.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleListPageFlyout : ContentPage
    {
        public ListView ListView;

        public ScheduleListPageFlyout()
        {
            InitializeComponent();

            BindingContext = new ScheduleListPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class ScheduleListPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ScheduleListPageFlyoutMenuItem> MenuItems { get; set; }

            public ScheduleListPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<ScheduleListPageFlyoutMenuItem>(new[]
                {
                    new ScheduleListPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new ScheduleListPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new ScheduleListPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new ScheduleListPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new ScheduleListPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}