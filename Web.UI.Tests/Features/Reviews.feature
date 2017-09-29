Feature: Reviews
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Read review
	Given a movie
	When the user views the details page for a movie
	Then the page shows a Reviews section that lists all of the review comments for that movie
