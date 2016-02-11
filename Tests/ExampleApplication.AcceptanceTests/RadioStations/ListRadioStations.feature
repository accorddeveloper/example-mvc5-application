Feature: List radio stations
	In order to find out which radio stations the system is aware of
	As an API client
	I want to be given the list of all the radio stations with their names and countries

@api
Scenario: Listing the radio stations
	Given the API is up and running
	When I make a GET request to the /api/radiostations endpoint
	Then the result should contain NRJ in France
	Then the result should contain Radio Plus in Poland
	Then the result should contain BBC Radio 1 in the United Kindgom