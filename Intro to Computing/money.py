"""
Author: Joshua Powell
File: money.py
Description: Calculates interest
"""


Invest = float(input("Please enter the amount you wish to invest: "))
PercentIn = float(input("Enter the interest percentage rate: "))
Years = int(input("Enter the years to compute: "))

Percent = (PercentIn/100)+1

for YearsComp in range(0,Years):
    Invest = Invest*Percent
    Invest = round(Invest,2)
    print(str(Invest))
