"""
File Name: height
Author: Joshua Powell
Description: Determines if someone is average heighet based on gender
"""

Gender = (input("What gender should we test? "))
Height = float(input("What is the height we should test in inches? "))


if(Gender == "M") or (Gender == "F"):
    if (Height > 0):
        if (Gender == 'F') and (61.5 <= Height <= 66.5):
            print("Within average.")
        else:
            if (Gender == 'M') and (66.5 <= Height <= 72.5):
                print("Within average.")
            else:
                print("Not within average.")
    else:
        print("Please enter a valid hieght.")
else:
    print("Please enter a valid gender.")
