using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using NUnit.Framework;
using Specflow_Xamarin_Team_Proj.SystemTasks;

namespace Specflow_Xamarin_Team_Proj.StepDefinitions
{
    [Binding]
    public class AddATaskSteps
    {
        ITasks tasks;
        Platform platform;

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            tasks = AppInitializer.StartApp(platform);
        }
        
        [When(@"I add a task called ""(.*)""")]
        public void WhenIAddATaskCalled(string taskName)
        {
            tasks
                .AddTask()
                .AddTitle(taskName)
                .AddNote("Get milk from shop");
        }
        
        [When(@"I save the task")]
        public void WhenISaveTheTask()
        {
            tasks.SaveTask();
        }
        
        [Then(@"I should see ""(.*)"" on the homepage")]
        public void ThenIShouldSeeOnTheHomepage(string taskName)
        {
            Assert.IsTrue(tasks.HasTask(taskName));
        }
    }
}