using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Specflow_Xamarin_Team_Proj.SystemTasks
{
    public class AndroidTasks : ITasks
    {
        readonly IApp app;

        public AndroidTasks (IApp app)
        {
            this.app = app;
        }

        public ITasks AddNote(string taskNote)
        {
            app.EnterText(c => c.Class("EditText").Index(1), taskNote);
            return this;
        }

        public ITasks AddTask()
        {
            app.Tap("Add Task");
            return this;
        }

        public ITasks AddTitle(string taskTitle)
        {
            app.EnterText(c => c.Class("EditText").Index(0), taskTitle);
            return this;
        }

        public bool HasTask(string taskTitle)
        {
            try
            {
                app.WaitForElement(taskTitle);
                AppResult[] result = app.Query(c => c.Marked(taskTitle));

                Console.WriteLine(taskTitle);
                if (result.Length == 0)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("the result length is ...drumroll...." + result.Length);
                    return true; 
                }
                

                       
                    
                //return true;
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Exception caught");
                return false;
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
            app.WaitForElement(taskName);
            app.Tap(c => c.Id("menu_delete_task"));
            app.WaitForNoElement(c => c.Marked(taskName));


            return this;
        }

        public bool DoesNotHaveTask(string taskName)
        {
            try
            {
                app.WaitForNoElement(c => c.Marked(taskName));
                app.Screenshot("No task");
                return true;
            }
            catch (TimeoutException)
            {

            }
            return false;
        }
    }
}
