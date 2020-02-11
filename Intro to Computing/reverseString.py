"""
Author: Joshua Powell
File: reverseString.py
Description:
"""

Text = str(input("Enter a string: "))
output = ""
Length = len(Text)
Loops = 0

print("original -", Text)
for index in range(Length):
    while Loops < Length:
        Loops = Loops + 1
        char = Text[Length - Loops]
        output = output + char

print("reversed -", output)
