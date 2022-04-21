@tag1
Feature: GoogleSearch

@tag2 
Scenario: Search Google for Edgewords
	Given I am on gOOgle Search
	When I search for Edgewords
	Then Edgewords is on the first page of results

@tag3 @tag4
Scenario: Alternative search terms
	Given I am on the Google home page
	When I search for 'bbc'
	Then 'bbc' is on the first page of results


Scenario Outline: Multiple search terms
	Given I am on the Google home page
	When I search for '<searchTerm>'
	Then '<searchTerm>' is on the first page of results
Examples:
	| searchTerm |
	| edgewords  |
	| bbc        |
	| netflix    |


Scenario: Inline Table

	Given I am on the Google home page
	When I search for 'edgewords'
	Then I should see in the results
		| title                                                    | url                                 |
		| Edgewords Training - Automated Software Testing Training | https://www.edgewordstraining.co.uk |
		| Edgewords - Twitter                                      | https://twitter.com › edgewords     |

	Given SOmething else