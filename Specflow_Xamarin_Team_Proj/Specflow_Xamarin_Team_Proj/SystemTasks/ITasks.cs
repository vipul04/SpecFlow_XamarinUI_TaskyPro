using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_Xamarin_Team_Proj.SystemTasks
{
    public interface ITasks
    {
        ITasks AddTask();
        ITasks AddTitle(string taskTitle);
        ITasks AddNote(string taskNote);
        ITasks SaveTask();
        bool HasTask(string taskTitle);
        ITasks DeleteTask(string taskName);
        bool DoesNotHaveTask(string taskName);
    }
}
