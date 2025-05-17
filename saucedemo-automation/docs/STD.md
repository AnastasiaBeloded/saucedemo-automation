# 🧾 Software Test Design (STD) – SauceDemo Automation

## 1. Introduction
This document defines the detailed design of test cases for functional validation of the SauceDemo web application.

## 2. Features to be Tested
1. Login functionality  
2. Inventory page and product sorting  
3. Cart operations  
4. Checkout process  
5. Logout and navigation

## 3. Test Design

### 🔐 Login Tests
| TC ID | Title                   | Input                                | Expected Output                          |
|-------|-------------------------|--------------------------------------|------------------------------------------|
| TC01  | Valid login             | standard_user / secret_sauce         | Redirect to inventory page               |
| TC02  | Invalid login           | wrong_user / secret_sauce            | Error message                            |
| TC03  | Invalid password        | standard_user / wrong_pass           | Error message                            |
| TC04  | Empty username          | [empty] / secret_sauce               | Error: Username is required              |
| TC05  | Empty password          | standard_user / [empty]              | Error: Password is required              |
| TC06  | Empty fields            | [empty] / [empty]                    | Error: Username is required              |
| TC07  | Locked out user         | locked_out_user / secret_sauce       | Error: User has been locked out          |
| TC08  | Problem user            | problem_user / secret_sauce          | Page loads with broken images            |
| TC09  | Performance glitch user | performance_glitch_user / secret_sauce | Login successful with delay           |

### 🛍️ Inventory Page
| TC ID | Title                  | Input                       | Expected Output                             |
|-------|------------------------|-----------------------------|---------------------------------------------|
| TC10  | View product list      | N/A                         | Product list displayed                      |
| TC11  | Sort A-Z               | Select A-Z from sort menu   | Products sorted alphabetically              |
| TC12  | Sort Z-A               | Select Z-A from sort menu   | Products sorted reverse-alphabetically      |
| TC13  | Sort Low to High       | Sort by price (low to high) | Products sorted in ascending price order    |
| TC14  | Sort High to Low       | Sort by price (high to low) | Products sorted in descending price order   |

### 🛒 Cart
| TC ID | Title                         | Input                                 | Expected Output                              |
|-------|-------------------------------|---------------------------------------|----------------------------------------------|
| TC15  | Add single item               | Click Add to Cart on one product      | Cart badge shows 1, item appears in cart     |
| TC16  | Add multiple items            | Add 2–3 items                         | Cart badge shows correct count               |
| TC17  | Remove item (list)            | Remove from inventory page            | Item removed, badge updates                  |
| TC18  | View cart                     | Click cart icon                       | Cart page opens with added items             |
| TC19  | Remove item (cart page)       | Remove from cart page                 | Item removed from cart                       |
| TC20  | Checkout with empty cart      | Click Checkout with empty cart        | Checkout blocked or stays on cart page       |

### ✅ Checkout
| TC ID | Title                    | Input                                                 | Expected Output                          |
|-------|--------------------------|--------------------------------------------------------|------------------------------------------|
| TC21  | Complete flow            | Add → Cart → Fill form → Finish                       | Redirect to confirmation page            |
| TC22  | Missing first name       | Leave first name empty                                | Error: First Name is required            |
| TC23  | Missing last name        | Leave last name empty                                 | Error: Last Name is required             |
| TC24  | Missing postal code      | Leave postal code empty                               | Error: Postal Code is required           |
| TC25  | Cancel checkout          | Click cancel on checkout step                         | Redirect to inventory/cart               |

### 🔚 Logout & Navigation
| TC ID | Title                 | Input                                   | Expected Output                          |
|-------|-----------------------|-----------------------------------------|------------------------------------------|
| TC26  | Logout                | Open menu → Click Logout                | Redirect to login page                   |
| TC27  | Reset app state       | Add item → Reset app via menu           | Cart clears, inventory resets            |
| TC28  | Back to products      | From cart → Click Back to Products      | Return to inventory page                 |

## 4. References
- SauceDemo App: https://www.saucedemo.com  
- [Test Plan (STP)](./SauceDemo_TestPlan.md)  
- [Automation Repo](https://github.com/AnastasiaBeloded/saucedemo-automation)

## 5. Status
Test design approved and automated.  
Responsible: **Anastasia Beloded**
