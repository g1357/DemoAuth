using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCanteen.ViewModels;
using Xamarin.Forms;

namespace MyCanteen.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            //DependencyService.Register<CanteenDemoService>();
            var vm = new CurrentMenuViewModel(null);

            // Act


            // Assert
        }
    }

    class CanteenDemoService
    {

    }
}
