"""
File Name: fuelSavings.py
Author: Joshua Powell
Description: Calculates fuel savings
"""
Miles = int(input("Please enter the miles you drive per year: "))
MPG = int(input("Please enter your current car's MPG: "))
NewMPG = int(input("Please enter the MPG of the new car: "))
GasPrice = float(input("Please enter the current cost of gas per gallon: "))

OldCost = (Miles/MPG) * GasPrice
NewCost = (Miles/NewMPG) * GasPrice

Savings = OldCost - NewCost

print("Fuel cost for your current car is", "$" + str(OldCost))
print("Fuel cost for the new car is", "$" + str(NewCost))
print("Savings (or loss) is", "$" + str(Savings))
