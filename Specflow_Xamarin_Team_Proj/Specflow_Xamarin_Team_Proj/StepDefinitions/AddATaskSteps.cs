using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using NUnit.Framework;
using Specflow_Xamarin_Team_Proj.SystemTasks;
using Specflow_Xamarin_Team_Proj.Features;

namespace Specflow_Xamarin_Team_Proj.StepDefinitions
{
    [Binding]
    public class AddATaskSteps
    {

        public ITasks app_tasks;
       
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            app_tasks = FeatureBase.app_tasks;
        }
        
        [When(@"I add a task called ""(.*)""")]
        public void WhenIAddATaskCalled(string taskName)
        {
            app_tasks
                .AddTask()
                .AddTitle(taskName)
                .AddNote("Get milk from shop");
        }
                
        [When(@"I save the task")]
        public void WhenISaveTheTask()
        {
            app_tasks.SaveTask();
        }
        
        [Then(@"I should see ""(.*)"" on the homepage")]
        public void ThenIShouldSeeOnTheHomepage(string taskName)
        {
            Assert.IsTrue(app_tasks.HasTask(taskName));
        }
    }
}