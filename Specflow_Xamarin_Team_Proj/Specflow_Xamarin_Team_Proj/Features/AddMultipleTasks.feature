Feature: Adding Multiple Tasks
	In order to keep track of my week
	I want to be able to add multiple tasks
	So that I can stick to my schedule

@AddMultipleTasks
Scenario: Add multiple tasks
Given I am on the homepage
When I add the following tasks:
| taskName  | taskNote   |
| Task 1    | Add Task 1 |
| Task 2    | Add Task 2 |
| Task 3    | Add Task 3 |
Then I should see the tasks on the homepage
