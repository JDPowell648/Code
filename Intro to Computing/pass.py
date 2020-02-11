"""
File" pass.py
Author : CS 1510 Powell
Description : Shows whether or not a student can pass the class
"""
possible = int(input("How many points were possible? "))
earned = int(input("How many points did you earn? "))
percent = (earned/possible) * 100

if(percent >= 72):
    print("Your grade is " + str(percent) + " % ")
    print("You can enroll in Data Structures")
if(percent < 72):
    print("Your grade is " + str(percent) + " % ")
    print("You should retake CS1")
