Feature: DeletingATask
	So I don't get confused
	I would like to delete tasks
	That I no longer need to track


@deletingTasks
Scenario: Deleting a task
	Given I am on the homepage
	Given I have added a task "Get Milk"
	When I tap delete for "Get Milk"
	Then The "Get Milk" task should no longer exist

	