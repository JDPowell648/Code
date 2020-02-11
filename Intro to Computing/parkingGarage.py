"""
File Name: parkingGarage.py
Author: Joshua Powell
Description: Calculates change in dollars and quarters
"""

Charge = float(input("What is the parking charge in multiples of 25 cents? "))
Payment = float(input("What is the total payment in multiples of quarters, $1, $5, or $10? "))

Change = Payment - Charge
Dollars = Change // 1
Quarters = (Change - Dollars) / .25

print("Your change is:", str(Dollars) + "$", str(Quarters), "Quarters")
