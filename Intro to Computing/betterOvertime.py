"""
File Name: betterOvertime
Author: Joshua Powell
Description: Calculates pay and Overtime Pay
"""



Hours = float(input("How many hours did you work? "))
Payrate = float(input("What is your base pay? "))
OverTime = Hours - 40

if Hours <= 40:
    print("The total pay is", str(Hours * Payrate) + "$")
if Hours > 40:
    Hours = 40
    print("The total pay is", str((Hours * Payrate) + (OverTime*Payrate*1.5)) + "$")