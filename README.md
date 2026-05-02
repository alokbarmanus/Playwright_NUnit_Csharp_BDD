# Playwright-NUnit-Csharp-BDD Automation Framework

This project is an industry-standard automation framework using Playwright, C#, and SpecFlow, following the Page Object Model (POM) design pattern.

## Folder Structure

- **.github/**: Project instructions and workflows
- **Properties/**: Contains `application.properties` for configuration
- **Pages/**: Page Object classes (locators and functions)
- **Tests/**: SpecFlow feature files and step definitions (test cases)
- **Base/**: `BasePage` and `BaseTest` for browser setup and teardown
- **Utils/**: Utility/helper classes
- **Drivers/**: WebDriver/Playwright driver management (if needed)

## Configuration
- `application.properties` contains:
  - `baseUrl=https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
  - `browser=chromium`
  - `retryCount=2`
  - `defaultWait=10`

## Getting Started
1. Install dependencies (Playwright, SpecFlow, NUnit, etc.)
2. Update `application.properties` as needed
3. Implement Page Objects in `Pages/`
4. Write tests in `Tests/`
5. Use `Base/` for browser setup/teardown
6. Add utilities in `Utils/`

## Best Practices
- Keep locators and page actions in Page Object classes
- Use SpecFlow for BDD-style test cases
- Centralize browser setup in `BasePage`/`BaseTest`
- Store reusable code in `Utils/`

---

This README will be updated as the framework evolves.
