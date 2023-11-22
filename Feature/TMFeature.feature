Feature: TMFeature

A short sumAs a TurnUp portal user
I would like to create, edit and delete time and material records
So that I can manage employees time and material successfully

@tag1
Scenario Outline: 01 Create time record with valid details
	Given I loged into TurnUp portal successfully
	When I navigate to time and material page
	Then I create a new '<Code>', '<Description>', '<price>' in time record
	Then the time record should be created '<Code>', '<Description>', '<price>' successfully

        Examples: 
    | Code      | Description      | price |
    | HelloTan1 | HelloTanEdit1Des | $111.00|


Scenario Outline: 02 Edit time record with valid details
    Given I loged into TurnUp portal successfully
    When I navigate to time and material page
    When I update the '<Code>', '<Description>' of an existing time record
    Then the time record should be updated '<Code>', '<Description>' successfully

    Examples: 
    | Code       | Description    |
    | TanEdit1   | TanEdit1Des    |	
    | TanEdit2   | TanEdit2Des    |
    | TanEdit3   | TanEdit3Des    |


Scenario Outline: 03 Delete time record with valid details
	Given I loged into TurnUp portal successfully
	When I navigate to time and material page
	Then I delete a time record '<Code>', '<Description>', '<price>'
	Then the time record should be deleted '<Code>', '<Description>', '<price>' successfully

        Examples: 
    | Code      | Description      | price   |
    | TanEdit3  | TanEdit3Des      | $111.00|

