Feature: Feature1

A short sumAs a TurnUp portal user
I would like to create, edit and delete employee record
So that I can manage employees successfully


	Scenario: 01 Create employee record with valid details
	Given I loged into TurnUp portal successfully Driver1
	When I navigate to employee page
	Then I create a new employee record
	Then the employee record should be created successfully


	Scenario: 02 Edit employee record with valid details
	Given I loged into TurnUp portal successfully Driver1
	When I navigate to employee page
	Then I edit a employee record
	Then the employee record should be edited successfully

	Scenario: 03 Delete employee record with valid details
	Given I loged into TurnUp portal successfully Driver1
	When I navigate to employee page
	Then I delete a employee record
	Then the employee record should be deleted successfully
