"""
File Name: discountPrice.py
Author: Joshua Powell
Description: Discounts a price by an inputted percentage
"""

Price = float(input("Pleae enter the original price: "))
Discount = float(input("Please enter the percentage off: "))

DisPer = (100 - Discount)/100
DisPri = round(Price*DisPer,2)

print("The sale price is $" + str(DisPri))
