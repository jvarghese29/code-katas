# Shopping Cart Kata in C#

This kata is (shamelessly) based on the original [Back to the Checkout Kata](http://codekata.com/kata/kata09-back-to-the-checkout/) by [PragDave](https://pragdave.me/).

## Goals

We’ll implement the code for a supermarket checkout system that handles various pricing schemes such as “apples cost 50 pence, three apples cost £1.30.”

The supermarket has a catalogue with different types of products (rice, apples, milk, toothbrushes,...). Each product has a price, and the total price of the shopping cart is the total of all the prices.

As in the real world, from time to time, the supermarket also runs special offers. 

This week the price list is:

| Item       | Unit Price | Offer Price |
|------------|------------|-------------|
| Apple      | 20         | 5 for 80    |
| Orange     | 25         | 5 for 60    |
| Banana     | 30         |             |
| Toothbrush | 75         | 3 for 175   |

### Rules / suggestions

* Items may be scanned in any order
* The system should produce the correct total
* The system should produce an itemised receipt
* There is a failing test - __if__ you want to test drive your solution!
* Have fun 😁 

