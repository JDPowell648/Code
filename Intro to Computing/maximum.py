"""
File" Maximum.py
Author : CS 1510 Powell
Description : Shows which of two scores earned a higher grade
"""

examOne = input("What was your score on the first exam? ")
examTwo = input("What was your score on the second exam? ")

scoreOne = int(examOne)
scoreTwo = int(examTwo)

if scoreOne>scoreTwo:
    print("Your score of "+ examOne + " on the first exam was higher")
if scoreOne<scoreTwo:
    print("Your score of "+ examTwo + " on the second exam was higher")
if scoreOne == scoreTwo:
    print("exam scores were exactly the same")
