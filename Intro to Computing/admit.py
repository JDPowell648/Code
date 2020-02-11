"""
File" admit.py
Author : CS 1510 Powell
Description : Shows whether or not a student can pass the class
"""
ACT = int(input("What was your ACT Score? "))
GPA = float(input("What was your high school GPA? "))

if(ACT >= 23) and (GPA >= 1.75):
    print("Congratulations, you can attend Whatsammate U")
if(ACT < 23) or (GPA < 1.75):
    print("Sorry, You dont live up to our standards.")
