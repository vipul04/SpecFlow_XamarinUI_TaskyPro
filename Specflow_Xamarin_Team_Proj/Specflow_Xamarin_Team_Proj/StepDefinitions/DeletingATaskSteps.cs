using NUnit.Framework;
using Specflow_Xamarin_Team_Proj.SystemTasks;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Specflow_Xamarin_Team_Proj.StepDefinitions
{
    [Binding]
    public class DeletingATaskSteps
    {
        Platform platform;
        ITasks tasks;

        [Given(@"I have added a task ""(.*)""")]
        public void GivenIHaveAddedATask(string taskName)
        {
            tasks = AppInitializer.StartApp(platform);

            tasks
            .AddTask()
            .AddTitle(taskName)
            .AddNote("Please delete this")
            .SaveTask();

        }

        [When(@"I tap delete for ""(.*)""")]
        public void WhenITapDeleteFor(string taskName)
        {
            tasks.DeleteTask(taskName);
        }

        [Then(@"The ""(.*)"" task should no longer exist")]
        public void ThenTheTaskShouldNoLongerExist(string taskName)
        {
            Assert.IsFalse(tasks.HasTask(taskName));
        }
    }
}
