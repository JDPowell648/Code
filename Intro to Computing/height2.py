"""
File Name: height2
Author: Joshua Powell
Description: Determines if someone is average heighet based on gender
"""

Gender = (input("What gender should we test? "))
Height = float(input("What is the height we should test in inches? "))


if (Gender == 'F'):
    if(61.5 <= Height <= 66.5):
        print("Within average.")
    else:
        print("Not within average.")
elif(Gender == "M"):
    if (66.5 <= Height <= 72.5):
        print("Within average.")
    else:
        print("Not withing average.")
else:
    print("Enter valid gender")
