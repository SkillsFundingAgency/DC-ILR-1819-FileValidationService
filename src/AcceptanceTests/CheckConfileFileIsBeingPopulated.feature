Feature: CheckConfileFileIsBeingPopulated
	In order to avoid silly mistakes
	As this is deployed automatically
	I want to check that the Config File is getting values set at release time

@mytag @SmokeTest
Scenario: Get a config item from Config and check it had been populated
	Given I have a config file
	Then Get a "LoggerConnectionString" from the file
	Then the config item should not contain "__"
