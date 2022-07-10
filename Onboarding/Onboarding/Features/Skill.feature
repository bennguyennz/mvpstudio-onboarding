Feature: Skills

As a Seller I want the feature to manage my skill details.
So that I am able to add, edit or delete my skill records.

@Skills
Scenario Outline: 1-Add a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I add '<Skill>' at '<Skill Level>'
	Then The '<Skill>' with '<Skill Level>'should be added successfully

	Examples: 
	| Skill              | Skill Level  |
	| C#                 | Beginner     |
	| Python             | Beginner     |
	| Selenium WebDriver | Intermediate |

@Skills
Scenario Outline: 2-Edit a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I edit last skill into '<Skill>' with '<Skill Level>'
	Then '<Skill>' with '<Skill Level>' should be edited successfully

	Examples:
	| Skill | Skill Level |
	| Java  | Beginner    |

@Skills
Scenario Outline: 3-Delete a skill
	Given I logged into the portal successfully
	When I click on tab Skills
	And I delete a '<Skill>'
	Then The '<Skill>' should be deleted accordingly
	
	Examples:
	| Skill  |
	| Java   |
