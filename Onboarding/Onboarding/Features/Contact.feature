Feature: Contact

As a Seller I want the feature to manage my education details.
So that I am able to add, edit or delete my education records.


@Contact
Scenario Outline: 1-Edit contact details
	Given I logged into the web portal successfully
	When I edit my contact details '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'
	Then My contact details should be edited as '<First Name>' '<Last Name>' '<Availability>' '<Hours>' '<Earn Target>'

	Examples:
	| First Name | Last Name | Availability | Hours                    | Earn Target                      |
	| Binh       | Nguyen    | Part Time    | Less than 30hours a week | Less than $500 per month         |
	| Binh       | Nguyeen   | Full Time    | More than 30hours a week | Between $500 and $1000 per month |
	| Binh       | Nguyen    | Full Time    | As needed                | More than $1000 per month        |


@Description
Scenario: 2-Edit Description
	Given I logged into the web portal successfully
	When I add or edit a description
	Then The description should be displayed texts same as I added
