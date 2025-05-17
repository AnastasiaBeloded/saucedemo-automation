# 🧪 Software Test Plan (STP) – SauceDemo Automation

## 1. Introduction
This document outlines the overall strategy, objectives, scope, and approach to testing the SauceDemo web application using automated UI tests written in C# and Selenium.

## 2. Objectives and Tasks
- Validate the core user flows in the SauceDemo app
- Ensure regression coverage through automated tests
- Detect UI functionality and sorting issues
- Track and report defects to stakeholders

## 3. Scope
### ✅ In Scope:
- Login functionality
- Product inventory view and sorting
- Cart operations (add/remove/view)
- Checkout process and validation
- Navigation and logout

### ❌ Out of Scope:
- Backend API testing
- Security testing
- Localization testing

## 4. Test Approach
- Automated UI tests using Selenium WebDriver
- NUnit as the test framework
- GitHub Actions for CI
- Structured test coverage based on user journey scenarios
- Page Object Model for test maintainability

## 5. Test Deliverables
- `TestCases.md`: All test scenarios and expected results
- Automation code: Stored in GitHub repository
- CI test summary: GitHub Actions reports
- Bug reports (if any): Raised via GitHub Issues

## 6. Entry and Exit Criteria
### Entry Criteria:
- Application is accessible at https://www.saucedemo.com/
- ChromeDriver available and working
- Automation framework compiles and passes smoke tests

### Exit Criteria:
- All high-priority test cases are automated and passing
- No critical or major open defects
- CI pipeline runs green for 3 consecutive builds

## 7. Schedule
| Phase               | Start Date | End Date   |
|--------------------|------------ |------------|
| Test Planning       | 2025-05-10 | 2025-05-17 |
| Test Case Design    | 2025-05-10 | 2025-05-17 |
| Test Automation     | 2025-05-10 | 2025-05-17 |
| Test Execution      | 2025-05-10 | 2025-05-17 |

## 8. Tools
- Selenium WebDriver
- NUnit
- GitHub Actions
- ChromeDriver

## 9. Risks
- Flaky tests due to headless browser timing
- UI changes in SauceDemo site affecting selectors
- Dependency on GitHub infrastructure for CI

## 10. Approvals
| Name               | Role              | Approval Date |
|--------------------|-------------------|----------------|
| Anastasia Beloded  | QA Automation Lead| 2025-05-17     |


---

Document Owner: **Anastasia Beloded**  
Version: 1.0  
Date: 2025-05-17 
