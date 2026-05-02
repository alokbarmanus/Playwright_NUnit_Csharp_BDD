Feature: Dashboard Page
    As an admin user
    I want to verify dashboard features after login
    So that I can ensure dashboard functionality is correct

    @regression @dashboard01 @smoke
    Scenario: Dashboard is visible after successful login
        Given I am on the login page
        When I login with static valid credentials "Admin" and "admin123"
        Then I should see the dashboard

    @regression @dashboard02 @widgets
    Scenario: Dashboard widgets are displayed
        Given I am on the login page
        When I login with static valid credentials "Admin" and "admin123"
        Then I should see dashboard widgets
