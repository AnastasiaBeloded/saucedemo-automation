# 🧪 Test Plan – SauceDemo Automation Project

## 1. Objective
To validate the core UI functionality of the https://www.saucedemo.com demo site through automated tests, covering login, product interaction, cart flow, and checkout.

## 2. Scope
### ✅ In Scope:
- Positive and negative login
- Product sorting and selection
- Cart operations
- Checkout flow
- Logout and reset app state

### ❌ Out of Scope:
- Backend or API testing
- Performance or load testing
- Localization or accessibility

## 3. Test Types
- Functional UI Testing
- Regression Testing
- CI-based test automation
- (Optional) Cross-browser support

## 4. Tools and Frameworks
- **Language:** C#
- **Test Framework:** NUnit
- **UI Automation:** Selenium WebDriver
- **CI/CD:** GitHub Actions
- **Version Control:** Git
- **Reporting (optional):** Allure

## 5. Environment
- **Test URL:** https://www.saucedemo.com/
- **Browser:** Google Chrome (latest stable)
- **Execution Platforms:** macOS (local), Ubuntu (CI)

## 6. Entry Criteria
- The site is live and publicly available
- GitHub repo is set up with CI workflow
- ChromeDriver and dependencies are installed
- Sample smoke test passes

## 7. Exit Criteria
- All critical test cases are automated and pass
- No high or critical open bugs remain
- CI runs pass consistently for 3 builds

## 8. Risks
- Site UI may change without notice (demo site)
- Browser driver version mismatch
- Unstable test elements in headless mode
- CI delays or outages on GitHub

---
Document Owner: **Anastasia Beloded**
Version: 1.1
Last Updated: 2025-05-17
