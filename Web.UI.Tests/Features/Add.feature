Feature: Add
	As a user
	I want to add a movie to the database
	So other users can interact with the movie

@Add
Scenario: Add New Movie
	Given I am on the home page
	When I add a new movie
	Then I am taken to the add movie screen
