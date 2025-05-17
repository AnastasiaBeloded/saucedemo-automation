# 📦 SauceDemo Automation – UI Test Suite

Automated UI test framework for validating functionality on the [SauceDemo](https://www.saucedemo.com) demo web application.

## 🧪 Project Overview
This project includes end-to-end functional tests covering:
- Login functionality (positive/negative)
- Product listing and sorting
- Cart operations
- Checkout flow and form validation
- Logout and app reset

## 🛠 Tech Stack
- **Language:** C#
- **Test Framework:** NUnit
- **Automation:** Selenium WebDriver
- **CI/CD:** GitHub Actions
- **Reporting (optional):** Allure

## 📁 Project Structure
```
├── Pages/            # Page Object Models (LoginPage, InventoryPage, etc.)
├── Tests/            # Test classes grouped by feature (LoginTests, CartTests, ...)
├── Utils/            # Utilities, test data helpers, waits
├── docs/             # STP, STD, TestCases in markdown
├── .github/workflows # CI pipelines
├── SauceDemo_TestPlan.md     # High-level test strategy
├── SauceDemo_TestDesign.md   # Test case details
└── README.md
```

## 🧾 Test Documents
- [📋 Test Plan (STP)](saucedemo-automation/docs/STP.md)
- [🧾 Test Design (STD)](saucedemo-automation/docs/STD.md)
- [✅ Test Cases List](saucedemo-automation/docs/TestCases.md)

## ▶️ Running Tests
From the root directory:
```bash
# Restore dependencies
$ dotnet restore

# Run tests with results
$ dotnet test --logger "trx;LogFileName=test-results.trx" --results-directory TestResults
```

## 🚀 CI Pipeline
Tests run automatically on each push via GitHub Actions. Results are published as summaries with detailed annotations.

## 👩‍💻 Author
Anastasia Beloded – [LinkedIn](https://www.linkedin.com/in/anastasia-beloded/)
