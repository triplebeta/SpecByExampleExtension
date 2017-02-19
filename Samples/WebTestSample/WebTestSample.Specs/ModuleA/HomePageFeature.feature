Feature: HomePage
	In order to test page HomePage
	As a tester
	I want to run some tests on this page

Scenario: My first test
	Given I go to the HomePage on url 'http://localhost:64861/'
	When I remember the current url
		And I click the HomeLink link
	Then I am no longer on the original url


