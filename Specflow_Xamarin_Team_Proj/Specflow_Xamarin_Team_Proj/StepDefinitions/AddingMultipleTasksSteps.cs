using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using NUnit.Framework;
using Specflow_Xamarin_Team_Proj.SystemTasks;
using Specflow_Xamarin_Team_Proj.Features;

namespace Specflow_Xamarin_Team_Proj.StepDefinitions
{
    [Binding]
    public class AddingMultipleTasksSteps
    {
        List<Task> taskDetails;
        ITasks app_tasks;

        [When(@"I add the following tasks:")]
        public void WhenIAddTheFollowingTasks(Table table)
        {
            app_tasks = FeatureBase.app_tasks;
            taskDetails = table.CreateSet<Task>().ToList();

            foreach (Task task in taskDetails)
            {
                app_tasks
                    .AddTask()
                    .AddTitle(task.taskName)
                    .AddNote(task.taskNote)
                    .SaveTask();
            }
        }
        
        [Then(@"I should see the tasks on the homepage")]
        public void ThenIShouldSeeTheTasksOnTheHomepage()
        {
            foreach (Task task in taskDetails)
            {
                Assert.IsTrue(app_tasks.HasTask(task.taskName));
            }
        }
    }
}
