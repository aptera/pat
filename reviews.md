# Reviews

An Epic of modest proportions

## Feature: Anonymous Reviews
### Read a movie's reviews
**As a user view the details for a movie,  
I want to read reviews for the movie,  
So that I can find out what other users think about it.**

When the user views the details page for a movie,  
Then the page shows a Reviews section that lists all of the review comments for that movie.

### Add a Review
**As an anonymous user who has seen a listed movie,  
I want to add a review to a movie,  
So that I can safely express my feelings about it to other visitors.**

The user can add a Review to a Movie.

A review has a long-form text field named Comments.

Given a movie,  
When the user adds a review,  
Then the review is listed on the movie's detail view.  

Given a review has no Comments,  
When the user tries to save the Review,  
Then the app shows an error message and does not save the review.

### Delete a Review
**As an anonymous user viewing a movie's reviews,  
I want to delete a review,  
So that I can remove something I disagree with from the Internet.** 

When the user attempts to delete a review,  
Then the app asks the user to confirm: "Are you sure you want to delete this review?"  

When the user cancels,  
Then the app does not delete the review.  

When the user confirms,  
Then the app deletes the review.  

### Edit a Review
**As an anonymous user viewing a review,  
I want to edit the comments,  
So that I can change its content and correct someone who is wrong on the Internet.**

Given a review has been saved,  
When the user changes its comments  
AND then cancels,  
Then the app does not update the review.  

Given a review has been saved,  
When the user changes its comments  
AND then saves,  
Then the app updates the review.

### Hide trigger words from an offensive review
**As a user who is sensitive to strong language,  
I want to see certain words obscured in review comments,  
So that I am not triggered.**

Given a review comment with a black-listed word,  
When the app displays the comment,  
Then the word is obscured using asterisks (*).  

## Feature: User Reviews
### Add a Signed Review
### Delete only my Reviews
### Edit only my Reviews

## Feature: Starred Reviews
### Review using stars
### See star icons on reviews
### Set stars on a review using star icons