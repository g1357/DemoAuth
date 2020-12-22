using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MyCanteen.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(@"C:\Users\Dukar\Source\Repos\g1357\DemoAuth\MyCanteen\MyCanteen.Android\bin\Debug\com.companyname.mycanteen.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}