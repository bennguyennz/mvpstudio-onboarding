Feature: Seller Profile

As a Seller I want the feature to add my Profile details
So that the people seeking for some skills can look into my details

@Login
	Scenario: A-Login
	Given I logged into the TradeYourSkills portal successfully
	Then I am able to see my profile page



@Description
Scenario: B-Add or Edit Description
	Given I logged into the TradeYourSkills portal successfully
	When I add or edit a description
	Then The description should be displayed texts same as I added



@Languages
Scenario Outline: C1-Add a language
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Languages
	And I add a '<language>' at a '<language level>'
	Then The '<language>' with '<language level>' should be added successfully

	Examples:
	| language   | language level |
	| English    | Fluent         |
	| Vietnamese | Conversational |

@Languages
Scenario Outline: C2-Edit a language
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Languages
	And I edit the last '<language>' at a different '<language level>'
	Then The '<language>' and '<language level>' should be edited successfully

	Examples:
	| language   | language level   |
	| Vietnamese | Native/Bilingual |

@Languages
Scenario Outline: C3-Delete a language
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Languages
	And I delete the last '<language>'
	Then The '<language>' should be deleted successfully

	Examples: 
	| language   |
	| Vietnamese |



@Skills
Scenario Outline: D1-Add a skill
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Skills
	And I add '<Skill>' at '<Skill Level>'
	Then The '<Skill>' with '<Skill Level>'should be added successfully

	Examples: 
	| Skill              | Skill Level  |
	| C#                 | Beginner     |
	| Python             | Beginner     |
	| Selenium WebDriver | Intermediate |

@Skills
Scenario Outline: D2-Edit a skill
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Skills
	And I edit last skill into '<Skill>' with '<Skill Level>'
	Then '<Skill>' with '<Skill Level>' should be edited successfully

	Examples:
	| Skill | Skill Level |
	| Java  | Beginner    |

@Skills
Scenario Outline: D3-Delete a skill
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Skills
	And I delete a '<Skill>'
	Then The '<Skill>' should be deleted accordingly
	
	Examples:
	| Skill  |
	| Java   |



@Education
Scenario Outline: E1-Add education
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Education
	And I add my education including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'
	Then I am able to see my education details including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'

	Examples:
	| Country     | University                      | Title  | Degree  | Graduation Year |
	| New Zealand | Whitireia Community Polytechnic | M.Tech | Diploma | 2021            |
	| Venezuela   | Hhutech University              | B.A    | Diploma | 2011            |



@Education
Scenario Outline: E2-Edit education
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Education
	And I edit education including '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'
	Then The education should be displayed as '<Country>', '<University>', '<Title>', '<Degree>', '<Graduation Year>'

	Examples:
	| Country | University        | Title | Degree  | Graduation Year |
	| Vietnam | Hutech University | B.Sc  | Diploma | 2014            |

@Education
Scenario Outline: E3-Delete education
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Education
	And I delete education by '<University>'
	Then The education by that '<University>' should be deleted successfully

	Examples:
	| University        |
	| Hutech University |



@Certifications
Scenario Outline: F1-Add a certification
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Certifications
	And I add a '<Certificate>' '<From>' '<Year>'
	Then I am able to see my '<Certificate>' '<From>' '<Year>' in my Certifications tab

	Examples: 
	| Certificate  | From       | Year |
	| ISTQB CTFL   | ISTQB NZ   | 2022 |
	| Test Analyst | MVP Studio | 2021 |

@Certifications
Scenario Outline: F2-Edit a certification
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Certifications
	And I edit a '<Certificate>' '<From>' '<Year>'
	Then The existing certificate is edited as '<Certificate>' '<From>' '<Year>'

	Examples: 
	| Certificate                      | From             | Year |
	| Professional Expert Test Analyst | Industry Connect | 2022 |

@Certifications
Scenario Outline: F3-Delete a certification
	Given I logged into the TradeYourSkills portal successfully
	When I click on tab Certifications
	And I delete '<Certificate>'
	Then The existing '<Certificate>' should be deleted accordingly

	Examples: 
	| Certificate                      | From             | Year |
	| Professional Expert Test Analyst | Industry Connect | 2022 |

@Contact
Scenario Outline: G-Edit contact details
	Given I logged into the TradeYourSkills portal successfully
	When I edit my contact details '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'
	Then My contact details should be edited as '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'

	Examples:
	| First Name | Last Name | Availability | Hours                    | Earn Target                      |
	| Binh       | Nguyen    | Part Time    | Less than 30hours a week | Less than $500 per month         |
	| Binh       | Nguyeen   | Full Time    | More than 30hours a week | Between $500 and $1000 per month |
	| Binh       | Nguyen    | Full Time    | As needed                | More than $1000 per month        |