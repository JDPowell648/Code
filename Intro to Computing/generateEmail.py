"""
Author: Joshua Powell
File: generateEmail.py
Description:
"""

FirstName = str(input("What is your first name? "))
LastName = str(input("What is your last name? "))

print("Your email is:", LastName[0:5] + FirstName[0] + "@uni.edu")
