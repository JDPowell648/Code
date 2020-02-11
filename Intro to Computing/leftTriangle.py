"""
Author: Joshua Powell
Program: rightTriangle.py
Description: Prints a positive number os stars
"""

Height = int(input("Please enter a positive height: "))
LineNum = 0
NumStar = 0

while Height <= 0:
    Height = int(input("Please enter a positive height: "))

print("Here is your art")

while LineNum < Height:
    for NumStar in range(0, LineNum + 1):
        print("* ", end="")
    LineNum = LineNum + 1
    print()
