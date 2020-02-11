"""
Author: Joshua Powell
Program: rightTriangle.py
Description: Prints a triangle oriented to the left
"""

Height = int(input("Please enter a positive height: "))
LineNum = 0
NumStar = 0
StarsPrinted = False

while Height <= 0:
    Height = int(input("Please enter a positive height: "))

print("Here is your art")

while LineNum < Height:
    StarsPrinted = False
    for NumStar in range(0, LineNum + 1):
        for NumSpace in range(1, Height - LineNum):
            if(StarsPrinted == False):
                print("  ", end="")
        print("* ", end="")
        StarsPrinted = True
    LineNum = LineNum + 1
    print()
