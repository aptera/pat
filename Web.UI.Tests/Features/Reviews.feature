Feature: Reviews
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Delete a review
	Given A review
	When the user deletes a review
	Then the app removes the review
