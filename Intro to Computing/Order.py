"""
Author: Joshua Powell
File: Order.py
Description: Creates a latin square
"""

Repeat = "yes"

while Repeat == "yes" or Repeat == "y":
    Order = int(input("Please input the order of the square: "))

    while 0 >= Order:
        print("Please print a positive order")
        Order = int(input("Please input the order of the square: "))

    NumPrinted = 0
    NumLines = 0
    Integer = 0

    StartInt = int(input("Please enter the top left number: "))

    while 0 >= StartInt or StartInt > Order:
        print("Please print a valid starting number")
        StartInt = int(input("Please enter the top left number: "))

    print("The Latin Square is:")

    for NumLines in range(0,Order):
         Integer = StartInt

         for NumPrinted in range(0,Order):
             print(str(Integer), end = " ")
             if Integer == Order:
                 Integer = 1
             else:
                 Integer = Integer + 1

         if StartInt == Order:
             StartInt = 1
         else:
             StartInt = StartInt + 1

         print()

    Repeat = input("Would you like to continue? (yes/no): ")
