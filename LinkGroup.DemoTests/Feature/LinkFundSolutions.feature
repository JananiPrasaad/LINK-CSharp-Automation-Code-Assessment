Feature: LinkFundSolutions

@linkFundSolutions
Scenario Outline: Jurisdictions
	When I open the Fund Solutions page
	Then I can select the <Jurisdiction name> jurisdiction
	Examples:
	|Jurisdiction name| 
	|UK| 
	|Swiss|