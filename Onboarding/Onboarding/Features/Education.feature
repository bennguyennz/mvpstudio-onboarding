Feature: Education

As a Seller I want the feature to manage my education details.
So that I am able to add, edit or delete my education records.

@Education
Scenario Outline: 1-Add education
	Given I logged into the portal
	When I click on tab Education
	And I add my education including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'
	Then I am able to see my education details including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'

	Examples:
	| Country     | University                      | Title  | Degree  | Graduation Year |
	| New Zealand | Whitireia Community Polytechnic | M.Tech | Diploma | 2021            |
	| Venezuela   | Hhutech University              | B.A    | Diploma | 2011            |



@Education
Scenario Outline: 2-Edit education
	Given I logged into the portal
	When I click on tab Education
	And I edit education including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'
	Then The education should be displayed as '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'

	Examples:
	| Country | University        | Title | Degree  | Graduation Year |
	| Vietnam | Hutech University | B.Sc  | Diploma | 2014            |

@Education
Scenario Outline: 3-Delete education
	Given I logged into the portal
	When I click on tab Education
	And I delete education by '<University>'
	Then The education by that '<University>' should be deleted successfully

	Examples:
	| University        |
	| Hutech University |


