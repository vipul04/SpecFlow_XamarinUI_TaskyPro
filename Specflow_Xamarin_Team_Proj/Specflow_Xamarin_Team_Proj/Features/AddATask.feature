Feature: AddATask
	In order to keep track of tasks
	I would like to add tasks
	So I can keep track of my day

@AddTask
Scenario: Adding a task
	Given I am on the homepage
	When I add a task called "Get Milk"
	And I save the task
	Then I should see "Get Milk" on the homepage