using Specflow_Xamarin_Team_Proj.SystemTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Specflow_Xamarin_Team_Proj.Features
{
    [Binding]
    public class FeatureBase
    {
        public static ITasks app_tasks;
        static Platform platform;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            app_tasks = AppInitializer.StartApp(platform);
            Console.WriteLine("BeforeTestRun");
        }
    }
}
