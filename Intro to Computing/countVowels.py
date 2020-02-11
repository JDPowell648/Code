"""
Author: Joshua Powell
File: countVowels.py
Description:
"""

Text = str(input("Enter a string: "))
output = ""
Length = len(Text)
numA = 0
numE = 0
numI = 0
numO = 0
numU = 0

for index in range(Length):
    char = Text[index]
    if char == "a" or char == "A":
        numA = numA + 1
    elif char == "e" or char == "E":
        numE = numE + 1
    elif char == "i" or char == "I":
        numI = numI + 1
    elif char == "o" or char == "O":
        numO = numO + 1
    elif char == "u" or char == "U":
        numU = numU + 1

print("There were", numA, "'a's")
print("There were", numE, "'e's")
print("There were", numI, "'i's")
print("There were", numO, "'o's")
print("There were", numU, "'u's")
