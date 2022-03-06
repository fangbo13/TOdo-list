using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Core;

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
    }
}
