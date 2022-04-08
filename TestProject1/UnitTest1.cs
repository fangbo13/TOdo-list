using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Core;
using ToDoAPP.Service;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ToDoContext context = new ToDoContext(Constants.DatabasePath);
            Constants.InitAsync(context);
        }

        [TestMethod]
        public void UserLogin()
        {
            APIService api = new APIService();
            string username = "haibo fang";
            string password = "123456";
            Assert.AreEqual(api.UserLogin(username, password), 230);
        }

        [TestMethod]
        public void DeleteDetail()
        {
            APIService api = new APIService();
            string DetailID = "5";
            Assert.AreEqual(api.DeleteDetail(DetailID), 230);
        }

        [TestMethod]
        public void AddParentListName()
        {
            APIService api = new APIService();
            string ParentTitleName = "My First Title";
            string Userid = "0";
            Assert.AreEqual(api.AddParentListName(ParentTitleName, Userid), 230);
        }

        [TestMethod]
        public void AddParentListName1()
        {
            APIService api = new APIService();
            string listid = "0";
            Assert.AreEqual(api.GetSchedule(listid), 230);
        }
    }
}
