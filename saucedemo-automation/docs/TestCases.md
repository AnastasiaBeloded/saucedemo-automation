
# 📋 Test Cases – SauceDemo Automation

## 🔐 Login Tests

| ID   | Title                      | Steps                                                   | Expected Result                          |
|------|----------------------------|---------------------------------------------------------|------------------------------------------|
| TC01 | Valid login                | Login as `standard_user`                                | Redirected to product page               |
| TC02 | Invalid login              | Use invalid username                                    | Error message shown                      |
| TC03 | Invalid password           | Use invalid password with valid user                    | Error message shown                      |
| TC04 | Empty username             | Leave username empty, enter password                    | Error message shown                      |
| TC05 | Empty password             | Enter username, leave password empty                    | Error message shown                      |
| TC06 | Empty fields               | Leave both fields empty                                 | Error message shown                      |
| TC07 | Locked out user login      | Login as `locked_out_user`                              | Error message: user locked out           |
| TC08 | Problem user login         | Login as `problem_user`                                 | Products load with broken images         |
| TC09 | Performance glitch user    | Login as `performance_glitch_user`                      | Login succeeds, but load may be delayed  |

## 🛍️ Inventory Page

| ID   | Title                            | Steps                                               | Expected Result                              |
|------|----------------------------------|-----------------------------------------------------|----------------------------------------------|
| TC10 | View product list                | Login and view product page                         | Product list is displayed                    |
| TC11 | Filter A-Z                       | Apply A-Z sort                                      | Products sorted alphabetically               |
| TC12 | Filter Z-A                       | Apply Z-A sort                                      | Products sorted reverse-alphabetically       |
| TC13 | Filter Low to High price         | Apply sort by price (low to high)                   | Products sorted ascending by price           |
| TC14 | Filter High to Low price         | Apply sort by price (high to low)                   | Products sorted descending by price          |

## 🛒 Cart Functionality

| ID   | Title                            | Steps                                                 | Expected Result                               |
|------|----------------------------------|-------------------------------------------------------|-----------------------------------------------|
| TC15 | Add single item to cart          | Click "Add to Cart" on one product                    | Cart badge shows "1", item in cart            |
| TC16 | Add multiple items to cart       | Add 2–3 items                                         | Cart badge updates accordingly                |
| TC17 | Remove item from cart (list page)| Click "Remove" after adding item                      | Item is removed, badge updated                |
| TC18 | View cart                        | Click on cart icon                                    | Cart page shows added items                   |
| TC19 | Remove item from cart (cart page)| Go to cart and remove an item                         | Item is removed from cart                     |
| TC20 | Proceed to checkout (empty cart) | Open cart with no items, click checkout               | Checkout not allowed or redirect blocked      |

## ✅ Checkout Process

| ID   | Title                            | Steps                                                  | Expected Result                               |
|------|----------------------------------|--------------------------------------------------------|-----------------------------------------------|
| TC21 | Complete checkout flow           | Add item → Cart → Checkout → Fill info → Finish        | Order completed page shown                    |
| TC22 | Missing first name               | Leave first name empty during checkout                 | Error message shown                           |
| TC23 | Missing last name                | Leave last name empty                                  | Error message shown                           |
| TC24 | Missing postal code              | Leave postal code empty                                | Error message shown                           |
| TC25 | Cancel checkout                  | Start checkout, then click Cancel                      | Return to inventory/cart                      |

## 🔚 Logout & Navigation

| ID   | Title                         | Steps                                                  | Expected Result                             |
|------|-------------------------------|--------------------------------------------------------|---------------------------------------------|
| TC26 | Logout from menu              | Login → Open menu → Click Logout                       | Redirect to login page                      |
| TC27 | Reset app state               | Add item → Open menu → Reset app                       | Cart and state are cleared                  |
| TC28 | Back to products button       | From item detail/cart → Click "Back to products"       | Return to inventory                         |