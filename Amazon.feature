Feature: Amazon

Scenario Outline: Search multiple products
	Given navigate to amazon portal
	And validate amazon log
	When search the <products>
	Then validate the <products>

Examples: 
	| products |
	| phone    |
	| Toy      |

Scenario: Item added to cart
	Given navigate to amazon portal
	And validate amazon log
	And search for a product
	And select the first product
	When click add to cart button
	Then validate product added to the cart

Scenario: Validate Topcategories
	Given navigate to amazon portal
	And select the Humburger menu button
	When select mainoption 'Mobiles, Computers'
	And select suboption 'Software'
	Then validate log is present under Topcategories section
