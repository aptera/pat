Feature: Reviews
	As a user viewing the details for a movie,
	I want to read reviews for the movie,
	So that I can find out what other users think about it.

@Global
Scenario: View Details Page
	Given A movie
	When the user views the details page for a movie,
	Then the page shows a Reviews section that lists all of the review comments for that movie.
