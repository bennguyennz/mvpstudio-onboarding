Feature: Language

As a Seller I want the feature to manage my language details.
So that I am able to add, edit or delete my language records.

@Languages
Scenario Outline: 1-Add a language
	Given I signed in the portal
	When I click on tab Languages
	And I add a '<language>' at a '<language level>'
	Then The '<language>' with '<language level>' should be added successfully

	Examples:
	| language   | language level |
	| English    | Fluent         |
	| Vietnamese | Conversational |

@Languages
Scenario Outline: 2-Edit a language
	Given I signed in the portal
	When I click on tab Languages
	And I edit the last '<language>' at a different '<language level>'
	Then The '<language>' and '<language level>' should be edited successfully

	Examples:
	| language   | language level   |
	| Vietnamese | Native/Bilingual |

@Languages
Scenario Outline: 3-Delete a language
	Given I signed in the portal
	When I click on tab Languages
	And I delete the last '<language>'
	Then The '<language>' should be deleted successfully

	Examples: 
	| language   |
	| Vietnamese |