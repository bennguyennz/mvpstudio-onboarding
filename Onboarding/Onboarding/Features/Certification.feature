Feature: Certification

As a Seller I want the feature to manage my certification details.
So that I am able to add, edit or delete my certification records.


@Certifications
Scenario Outline: 1-Add a certification
	Given I signed into the portal
	When I click on tab Certifications
	And I add a '<Certificate>' '<From>' '<Year>'
	Then I am able to see my '<Certificate>' '<From>' '<Year>' in my Certifications tab

	Examples: 
	| Certificate  | From       | Year |
	| ISTQB CTFL   | ISTQB NZ   | 2022 |
	| Test Analyst | MVP Studio | 2021 |

@Certifications
Scenario Outline: 2-Edit a certification
	Given I signed into the portal
	When I click on tab Certifications
	And I edit a '<Certificate>' '<From>' '<Year>'
	Then The existing certificate is edited as '<Certificate>' '<From>' '<Year>'

	Examples: 
	| Certificate                      | From             | Year |
	| Professional Expert Test Analyst | Industry Connect | 2022 |

@Certifications
Scenario Outline: 3-Delete a certification
	Given I signed into the portal
	When I click on tab Certifications
	And I delete '<Certificate>'
	Then The existing '<Certificate>' should be deleted accordingly

	Examples: 
	| Certificate                      | From             | Year |
	| Professional Expert Test Analyst | Industry Connect | 2022 |