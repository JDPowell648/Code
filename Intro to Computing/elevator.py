"""
Author: Joshua Powell
File: elevator.py
Description: 
"""

Limit = float(input("What is the rated wieght limit? "))
Total  = int(input("Enter the first passenger's weight: "))

while Total <= Limit:
    NextPass = int(input("Enter the next passenger's weight: "))
    Total = NextPass + Total
    print("This person can get on.")

print("Time to quit. This person will exceed the weight limit of the elevator")