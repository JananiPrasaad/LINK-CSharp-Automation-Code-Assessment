Feature: LinkGroup

@linkGroup
Scenario: Smoke test
	When I open the home page
	Then the page is displayed


@linkGroup
Scenario: Search results
	Given I have opened the home page
	And I have agreed to the cookie policy
	When I search for "Leeds"
	Then the search results are displayed