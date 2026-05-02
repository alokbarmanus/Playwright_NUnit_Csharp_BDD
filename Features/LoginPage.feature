Feature: Login
    As a user
    I want to login to OrangeHRM
    So that I can access the dashboard

    @regression @loginPage01
    @dataFile:data/${env}/loginArrayData.json
    Scenario: LoginPage 01: Successful login with static credentials
        Given I am on the login page
        When I login with valid credentials from data file row 1
        Then I should see the dashboard

    @regression @loginPage02
    Scenario: LoginPage 02: Successful login with step define credentials
        Given I am on the login page
        When I login with static valid credentials "Admin" and "admin123"
        Then I should see the dashboard

    @regression @loginPage03
    @dataFile:data/${env}/loginData.json
    Scenario: LoginPage 03: Successful login with credentials from JSON simple data
        Given I am on the login page
        When I login with valid credentials "username" and "password" from data file
        Then I should see the dashboard

    @regression @loginPage04
    @dataFile:data/${env}/loginArrayData.json
    Scenario: LoginPage 04: Successful login with credentials from JSON array data
        Given I am on the login page
        When I login with valid credentials "username" and "password" from data file
        Then I should see the dashboard

    @regression @loginPage05
    @dataFile:data/${env}/loginArrayData.json
    Scenario: LoginPage 05: Json Array nested data
        Given I am on the login page
        When I login with valid credentials "username" and "password" from data file
        When I should enter my address as "address" from data file




