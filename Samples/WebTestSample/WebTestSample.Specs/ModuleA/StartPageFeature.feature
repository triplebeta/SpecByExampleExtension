Feature: StartPage
	In order to test page StartPage
	As a tester
	I want to run some tests on this page

Scenario: My first test
	Given I go to the StartPage on url 'http://localhost:64861/'
	When I remember the current url
		And I click the AboutLink link
	Then I am no longer on the original url

	
Scenario: Register a new user
	Given I go to the StartPage on url 'http://localhost:64861/'
	When I click the RegisterLink link
		And I type "NewUser" in text EmailTextbox
		And I type "Boo" in text PasswordTextbox
		And I type "Boo" in text ConfirmPasswordTextbox
		And I click the RegisterButton
	Then I am no longer on the original url


