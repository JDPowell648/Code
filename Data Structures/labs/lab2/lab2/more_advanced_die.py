"""
File:  more_advanced_die.py
Description: Implements an AdvancedDie class that allows for any number of sides
Inherits from the parent class Die in module simple_die
"""

from advanced_die import AdvancedDie
from random import randint

class MoreAdvancedDie(AdvancedDie):
    def setRoll(self,num):
        if not isinstance(sides,int):
            raise TypeError("Die sides must be an integer!")
        if sides < 1:
            raise ValueError("Die sides must be a positive integer!")
        self._currentRoll = num
