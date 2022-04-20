Feature: GoogleSearch

Scenario: Search Google for Edgewords
	Given I am on the Google home page
	When I search for Edgewords
	Then Edgewords is on the first page of results


