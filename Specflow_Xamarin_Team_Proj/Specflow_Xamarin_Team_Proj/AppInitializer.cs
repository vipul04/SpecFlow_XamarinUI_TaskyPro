using Specflow_Xamarin_Team_Proj.SystemTasks;
using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Specflow_Xamarin_Team_Proj
{
    public class AppInitializer
    {
        public static ITasks StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return new AndroidTasks (ConfigureApp
                    .Android
                    .ApkFile("../../Binaries/Android/com.xamarin.samples.taskyandroid.apk")
                    .StartApp());
            }

            else return new IOSTasks (ConfigureApp
                .iOS
                .AppBundle("../../Binaries/iOS/TaskyiOS.app")
                .StartApp());
        }
    }
}

