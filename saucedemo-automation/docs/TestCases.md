# Test Cases – SauceDemo

| ID   | Title                        | Steps                                      | Expected Result                         |
|------|------------------------------|--------------------------------------------|------------------------------------------|
| TC01 | Valid login                  | Login as `standard_user`                  | Redirected to product page               |
| TC02 | Invalid login                | Use wrong password                         | Error message shown                      |
| TC03 | Add product to cart          | Click "Add to Cart" on first item          | Item appears in cart                     |
| TC04 | Sort by price (low to high) | Select "Price (low to high)" from dropdown | Products are sorted accordingly          |
| TC05 | Complete checkout            | Fill form and click finish                 | "Thank you for your order" message shown |
