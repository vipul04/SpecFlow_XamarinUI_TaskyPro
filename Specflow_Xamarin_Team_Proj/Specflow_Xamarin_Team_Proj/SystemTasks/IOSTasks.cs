using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Specflow_Xamarin_Team_Proj.SystemTasks
{
    public class IOSTasks : ITasks
    {
        readonly IApp app;

        public IOSTasks (IApp app)
        {
            this.app = app;
        }

        public ITasks AddNote(string taskNote)
        {
            app.EnterText(c => c.Class("UITextField").Index(1), taskNote);
            return this;
        }

        public ITasks AddTask()
        {
            app.Tap("Add");
            return this;
        }

        public ITasks AddTitle(string taskTitle)
        {
            app.EnterText(c => c.Class("UITextField").Index(0), taskTitle);
            return this;
        }

        public bool HasTask(string taskTitle)
        {
            try
            {
                app.WaitForElement(c => c.Marked(taskTitle));
                return true;
            }
            catch (TimeoutException)
            {

            }
            return false;
        }

        public ITasks SaveTask()
        {
            app.Tap("Save");
            return this;
        }

        public ITasks DeleteTask(string taskName)
        {
            app.Tap(c => c.Marked(taskName));
            //app.WaitForNoElement(taskName);
            app.Tap(c => c.Id("menu_delete_task")); // This is the Android version, change to iOS

            return this;
        }
    }
}
