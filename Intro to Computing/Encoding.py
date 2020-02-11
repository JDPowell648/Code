"""
Author: Joshua Powell
file: encode.py
Description: ceaser encodes
"""

LoopStr = "qdce"

while True:
    LoopInput = input("e for encode, d for decode, c for crack, q for quit: ")
    Valid = False

    alphabet = "abcdefghijklmnopqrstuvwxyz"
    LoopCount = 0
    Rots = 0

    if LoopInput in LoopStr:
        Valid = True

    while Valid == False:
        print("I don't recognize that option. Try again.")
        LoopInput = input("e for encode, d for decode, c for crack, q for quit: ")

        if LoopInput in LoopStr:
            Valid = True

    if LoopInput == "q":
        break

    if LoopInput == "e":
        String = input("String to encode: ")
        RotValue = int(input("Rotation value: "))

        while 1 > RotValue or RotValue > 25:
            print("That isn't a legal rotation value")
            RotValue = int(input("Rotation value: "))
    
        print("Encoded string is: ", end="")

        for Loops in range(0,len(String)):
            char = String[LoopCount]
            LoopCount = LoopCount + 1
            encode = alphabet.find(char)
            outputint = alphabet.find(char) + RotValue
        
            if encode == -1:
                print(char, end="")
        
            if (alphabet.find(char) + RotValue) >= len(alphabet):
                outputint = outputint - len(alphabet)
                outputchar = alphabet[outputint]
            else:
                outputchar = alphabet[alphabet.find(char) + RotValue]
            
            if encode >=0:
                print(outputchar, end="")
        print()
        print()

    if LoopInput == "d":
        String = input("String to decode: ")
        RotValue = int(input("Rotation value: "))

        while 1 > RotValue or RotValue > 25:
            print("That isn't a legal rotation value")
            RotValue = int(input("Rotation value: "))
        
        print("Decoded string is: ", end="")

        for Loops in range(0,len(String)):
            char = String[LoopCount]
            LoopCount = LoopCount + 1
            encode = alphabet.find(char)
            outputint = alphabet.find(char) - RotValue
        
            if encode == -1:
                print(char, end="")
        
            if (alphabet.find(char) - RotValue) >= len(alphabet):
                outputint = outputint + len(alphabet)
                outputchar = alphabet[outputint]
            else:
                outputchar = alphabet[alphabet.find(char) - RotValue]
            
            if encode >=0:
                print(outputchar, end="")
        print()
        print()

    if LoopInput == "c":
        String = input("String to decode: ")
        String = String.lower()
        Word = input("Give me a word in that string: ")
        DecodedStr = ""
        RotValue = 1

        Found = String.find(Word)

        while Found == -1:
            RotValue = RotValue + 1
            for RotValue in range(0,26):
                LoopCount = 0
                DecodedStr = ""
                for Loops in range(0,len(String)):
                    char = String[LoopCount]
                    LoopCount = LoopCount + 1
                    encode = alphabet.find(char)
                    outputint = alphabet.find(char) - RotValue
        
                    if encode == -1:
                        DecodedStr = DecodedStr + char
        
                    if (alphabet.find(char) - RotValue) >= len(alphabet):
                        outputint = outputint + len(alphabet)
                        outputchar = alphabet[outputint]
                    else:
                        outputchar = alphabet[alphabet.find(char) - RotValue]
            
                    if encode >=0:
                        DecodedStr = DecodedStr + outputchar

                Found = DecodedStr.find(Word)

                if Found != -1:
                    break

        print()
        print("Decoded String is:", DecodedStr)
        print("Produced with a Rotation value of", str(RotValue))
        print()



print("Thanks for playing!")
