"""
Author: Joshua Powell
Program: starLine.py
Description: Prints a positive number os stars
"""


Num = int(input("Please enter a positive number: "))
NumPrint = 0

while Num <= 0:
    Num = int(input("Please enter a positive number: "))

print("Here is your art")

while NumPrint < Num:
    NumPrint = NumPrint + 1
    print("* ", end='')
    
print()