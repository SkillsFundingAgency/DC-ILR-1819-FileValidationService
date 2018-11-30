
Feature: SubmitTestILRFile
	In order to avoid silly mistakes
	As a end user
	I want to submit a file to Service Bus and Check it processes

@mytag
Scenario: Process file test file
	Given I have Created a file 
	And I have entered Create a message
	When I submit the Message to Service Bus
	Then the result file shoulf be in storage	