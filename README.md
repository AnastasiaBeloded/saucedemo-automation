# 🧪 SauceDemo Automation Project

This is a UI automation project for [saucedemo.com](https://www.saucedemo.com), built using Selenium WebDriver and NUnit in C#.  
It covers the end-to-end flow of logging in, interacting with products, managing the cart, and completing the checkout.

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** NUnit
- **Automation Tool:** Selenium WebDriver
- **Browser Driver:** ChromeDriver (managed via WebDriverManager)
- **Test Runner:** NUnit3 Console
- **Version Control:** Git + GitHub
- *(Optional later: Allure Report, GitHub Actions)*

---

## 📂 Project Structure

/saucedemo-automation
│
├── docs/ → Test documentation (Test Plan, STP, STD, Test Cases)
├── tests/ → Test classes (grouped by feature)
├── pages/ → Page Object Model classes
├── utils/ → Helper classes (e.g., WebDriverFactory)
├── test_data/ → Input data (e.g., login users, cart items)
├── .gitignore
├── README.md → This file
└── SauceDemoTests.sln → Solution file

## 🚀 How to Run Tests

1. Clone the repo:
```bash
git clone https://github.com/AnastasiaBeloded/saucedemo-automation.git
Open solution in Visual Studio or Rider.

Install dependencies via NuGet:

Selenium.WebDriver

Selenium.WebDriver.ChromeDriver

WebDriverManager

NUnit

NUnit3TestAdapter

Run tests using Test Explorer or CLI:
dotnet test

✅ Features Covered
Login page: valid, invalid, locked users

Product list: sorting, adding/removing to cart

Cart page: item persistence, remove flow

Checkout: personal info form, overview, finish

Logout functionality

📄 Documentation
See folder: /docs

Test Plan

System Test Plan (STP)

System Test Design (STD)

Test Cases

✨ Author
Anastasia Beloded
QA Manual & Automation Engineer
LinkedIn | GitHub