"""
Author: Joshua Powell
File: disarm.py
Description: 
"""

DefuseNum = int(input("What is the defuse number? "))
num = 1
Sum = 1

while num < DefuseNum:
    print("Sum:", Sum)
    print(num)
    Sum *= num
    num *= 2

print("The answer is", Sum)
