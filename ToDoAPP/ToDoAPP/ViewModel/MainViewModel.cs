using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Module;
using ToDoApp.View;
using ToDoAPP.Interfaces;
using ToDoAPP.Module;
using ToDoAPP.View;
using Xamarin.Forms;

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IToDoService toDoService;
        APIInterface APIservice;
        string Detailid = string.Empty;
        public MainViewModel()
        {
            APIservice = ServiceProvider.Instance.Get<APIInterface>();
            InitUser();
            Checklists = new ObservableCollection<Checklist>();
            CheckDetailList = new ObservableCollection<ChecklistDetail>();
            QueryCheckList();
            //toDoService = ServiceProvider.Instance.Get<IToDoService>();
            //OpenCommand = new RelayCommand<Checklist>(t => OpenPage(t));
            //AddCommand = new RelayCommand(() =>
            //{
            //    Messenger.Default.Send("", "Add");
            //});
            //QueryCommand = new RelayCommand(() =>
            //  {
            //      Messenger.Default.Send("", "Query");
            //  });

        }

        public void InitUser()
        {
            UserModel.UserName = UserContext.UserName;
            UserModel.Remark = UserContext.Remark;
        }
        #region Declare variable
        private ObservableCollection<Checklist> checklists;

        public ObservableCollection<Checklist> Checklists
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ChecklistDetail> _ChecklistDetail;

        public ObservableCollection<ChecklistDetail> ChecklistDetail
        {
            get { return _ChecklistDetail; }
            set { _ChecklistDetail = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ChecklistDetail> _CheckDetailList;

        public ObservableCollection<ChecklistDetail> CheckDetailList
        {
            get { return _CheckDetailList; }
            set { _CheckDetailList = value; RaisePropertyChanged(); }
        }



        private UserInfo _UserModel = new UserInfo();

        public UserInfo UserModel
        {
            get { return _UserModel; }
            set { _UserModel = value; RaisePropertyChanged(nameof(UserModel)); }
        }

        private string _AddTitleName;

        public string AddTitleName
        {
            get { return _AddTitleName; }
            set { _AddTitleName = value; RaisePropertyChanged(nameof(AddTitleName)); }
        }

        private string _ChildContent;

        public string ChildContent
        {
            get { return _ChildContent; }
            set { _ChildContent = value; RaisePropertyChanged(nameof(ChildContent)); }
        }

        private string _DetailContent;

        public string DetailContent
        {
            get { return _DetailContent; }
            set { _DetailContent = value; RaisePropertyChanged(nameof(DetailContent)); }
        }
        #endregion

        #region Command
        public RelayCommand AddCommand => new RelayCommand(Add);

        public async void Add()
        {
            Application.Current.MainPage = new AddListPage();

        }

        public RelayCommand BackMainPageCommand => new RelayCommand(BackMainPage);

        public async void BackMainPage()
        {
            Application.Current.MainPage = new MainPage();
        }

        public RelayCommand AddListSubmitCommand => new RelayCommand(AddListSubmit);

        public async void AddListSubmit()
        {
            var result = APIservice.AddParentListName(AddTitleName, UserContext.UserID);
            if (result.IsSuccess)
            {

                QueryCheckList();
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                Application.Current.MainPage.DisplayAlert("Error", result.ResultMsg, "OK"));
            }

        }

        public RelayCommand<ChecklistDetail> DeleteDetailCommand => new RelayCommand<ChecklistDetail>(DeleteDetail);

        public async void DeleteDetail(ChecklistDetail model)
        {
            var result = APIservice.DeleteDetail(model.Id);
            if (result.IsSuccess)
            {
                LoadDetailList();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                Application.Current.MainPage.DisplayAlert("Error", result.ResultMsg, "OK"));
            }

        }

        public async void GetDetailList()
        {

            //ChecklistDetail.Add();
        }

        public RelayCommand AddDetailCommand => new RelayCommand(AddDetail);

        public async void AddDetail()
        {
            var result = APIservice.AddSchedule("", DetailContent, "", UserContext.UserParameter);
            if (result.IsSuccess)
            {
                //加载列表数据
                LoadDetailList();
            }
            else
            {
                Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
               Application.Current.MainPage.DisplayAlert("Error", result.ResultMsg, "OK"));
            }
        }


        public async void LoadDetailList()
        {
            CheckDetailList.Clear();
            var list = APIservice.GetSchedule(UserContext.UserParameter);
            foreach (var item in list.ResultData)
            {

                ChecklistDetail d = new ChecklistDetail();
                d.Id = item["ID"].ToString();
                d.Content = item["CONTENT"].ToString();
                CheckDetailList.Add(d);
            }
        }
        #endregion

        public async void AddCheckList(Checklist c)
        {
            var r = await toDoService.AddToDoGroupAsync(c);
            if (r)
                Checklists.Add(c);
        }

        public async void QueryCheckList()
        {
            Checklists.Clear();
            var result = APIservice.GetListTile(UserContext.UserID);
            if (result.IsSuccess)
            {
                foreach (var item in result.ResultData)
                {
                    Checklist checkinfo = new Checklist();
                    checkinfo.Id = item["ID"].ToString();
                    checkinfo.Title = item["LISTNAME"].ToString();
                    checkinfo.IconFont = "\xe63b";
                    checkinfo.BackColor = "#009ACD";
                    checkinfo.Count = Convert.ToInt32(item["CHILDTOTAL"].ToString());
                    Checklists.Add(checkinfo);
                }
            }
            else
            {
                Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
               Application.Current.MainPage.DisplayAlert("Error", result.ResultMsg, "OK"));
            }
        }

        public RelayCommand<Checklist> OpenCommand => new RelayCommand<Checklist>(Open);

        public async void Open(Checklist check)
        {
            UserContext.UserParameter = check.Id;

            Application.Current.MainPage = new ScheduleListPage();
        }



        //public RelayCommand QueryCommand { get; private set; }

        //public async void InitMainViewModel()
        //{
        //    var cks = await toDoService.GetToDoListAsync();
        //    if (cks != null)
        //    {
        //        Checklists = new ObservableCollection<Checklist>();
        //        cks.ForEach(arg =>
        //        {
        //            Checklists.Add(arg);
        //        });
        //    }
        //}

        //public async void OpenPage(Checklist c)
        //{
        //    if (c != null)
        //    {
        //        var cks = await toDoService.GetToDoListDetailAsync(c.Id);
        //        Messenger.Default.Send(cks, "OpenDetailPage");
        //    }
        //}
    }
}
