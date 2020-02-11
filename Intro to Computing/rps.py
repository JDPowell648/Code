"""
Author: Joshua Powell
File: rps.py
Description: Rock, paper, scissors!
"""

import random

print("Each round you must select from one of the following weapons")
print("     Enter r for rock")
print("     Enter p for paper")
print("     Enter s for scissors")
print("     Enter q for quit")

Ties = 0
Wins = 0
Losses = 0
Rounds = 0

ValidStr = "rpsq"

while True:

    PlayerWeapon = input("Please enter your weapon of choice: ")
    PlayerWeapon = PlayerWeapon.lower()

    Valid = False

    if PlayerWeapon in ValidStr and len(PlayerWeapon) == 1:
        Valid = True

    while Valid == False:
        print("ERROR. That's not a valid choice.")
        PlayerWeapon = input("Please enter your weapon of choice: ")

        PlayerWeapon = PlayerWeapon.lower()

        if PlayerWeapon in ValidStr and len(PlayerWeapon) == 1:
            Valid = True

    Choices = ["r","p","s"]
    ComWeapon = random.choice(Choices)

    if PlayerWeapon == ComWeapon:
        print("TIE. Both Picked", ComWeapon)
        Ties = Ties + 1
    elif PlayerWeapon == 'r' and ComWeapon == 's':
        print("HUMAN WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Wins = Wins + 1
    elif PlayerWeapon == 'p' and ComWeapon == 'r':
        print("HUMAN WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Wins = Wins + 1
    elif PlayerWeapon == 's' and ComWeapon == 'p':
        print("HUMAN WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Wins = Wins + 1
    elif ComWeapon == 'r' and PlayerWeapon == 's':
        print("COMPUTER WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Losses = Losses + 1
    elif ComWeapon == 'p' and PlayerWeapon == 'r':
        print("COMPUTER WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Losses = Losses + 1
    elif ComWeapon == 's' and PlayerWeapon == 'p':
        print("COMPUTER WINS! Human pick:", PlayerWeapon, "Computer pick:", ComWeapon)
        Losses = Losses + 1
    elif PlayerWeapon == "q":
        break
    Rounds = Rounds + 1

print("Thanks for playing.")
print("We played a total of", Rounds, "rounds.")
print("Total ties =", Ties)
print("Total wins for human =", Wins)
print("Total wins for computer =", Losses)
