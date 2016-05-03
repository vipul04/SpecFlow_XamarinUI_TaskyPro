using NUnit.Framework;
using Specflow_Xamarin_Team_Proj.Features;
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
        ITasks app_tasks;

        [Given(@"I have added a task ""(.*)""")]
        public void GivenIHaveAddedATask(string taskName)
        {
            app_tasks = FeatureBase.app_tasks;

            app_tasks
            .AddTask()
            .AddTitle(taskName)
            .AddNote("Please delete this")
            .SaveTask();

        }

        [When(@"I tap delete for ""(.*)""")]
        public void WhenITapDeleteFor(string taskName)
        {
            app_tasks.DeleteTask(taskName);
        }

        [Then(@"The ""(.*)"" task should no longer exist")]
        public void ThenTheTaskShouldNoLongerExist(string taskName)
        {
            Assert.IsTrue(app_tasks.DoesNotHaveTask(taskName));
        }
    }
}
