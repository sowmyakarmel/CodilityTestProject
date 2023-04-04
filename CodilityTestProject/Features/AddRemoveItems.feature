Feature: Add and Remove Items from Cart
    Scenario: Add four random items to cart and remove the lowest priced item
        Given I am on the home page
        When I add four random items to my cart
        Then I should see four items in my cart
        When I search for the lowest priced item
        And I remove the lowest priced item from my cart
        Then I should see three items in my cart