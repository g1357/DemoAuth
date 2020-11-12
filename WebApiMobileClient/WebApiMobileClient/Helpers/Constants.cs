using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WebApiMobileClient.Helpers
{
    /// <summary>
    /// Константы приложения
    /// </summary>
    public static class Constants
    {
        // WINDOWS_UWP __IOS__ __MOBILE__ WINDOWS_PHONE __TVOS__ __WATCHES__ __MACOS__
//#if WINDOWS_UWP
//        public static readonly string BaseWebApiAddress = "http://localhost:5001";
//#elif __IOS__
//        public static readonly string BaseWebApiAddress = "http://192.168.200.76:5001";
//#else // __ANDROID__
//        public static readonly string BaseWebApiAddress = "http://10.0.2.2:5001";
//#endif
        public static readonly string BaseWebApiAddress = "http://192.168.200.76:5001";
        public static string GetBaseWebApiAddress()
        {
            string address = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    address = "http://10.10.1.2:5001"; //"http://192.168.200.76:5001";
                    break;
                case Device.UWP:
                    address = "http://localhost:5001";
                    break;
                case Device.Android:
                    address = "http://10.0.2.2:5001";
                    break;
                default:
                    address = "http://localhost:5001";
                    break;
            }
            return address;
        }
    }
}
