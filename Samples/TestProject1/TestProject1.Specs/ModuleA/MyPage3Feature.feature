Feature: MyPage3
	In order to test page MyPage3
	As a tester
	I want to run some tests on this page

Scenario: My first test
	Given I go to the MyPage3 on url 'http://specbyexamplesamplewebsite.azurewebsites.net/'
	When I remember the current url
		And I click the HomeLink
	Then I am no longer on the original url


