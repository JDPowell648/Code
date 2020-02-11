"""
File:  averageOutcomes.py
Description:  Rolls two 10-sided dice 1,000 times to determine the average outcome
on the pair of dice.
"""
from random import randint
from advanced_die import AdvancedDie

# Global Constants
NUMBER_OF_ROLLS = 1000
DIE_SIDES = 10
Die1 = AdvancedDie()
Die2 = AdvancedDie()

def main():
    """ Main program provides an outline of program """
    displayWelcome()
    averageOutcome = calculateAverageOutcome()
    displayResults(averageOutcome)


def displayWelcome():
    """ Displays welcome message for the user """
    print("This program rolls two %d-sided dice %d times to"
          % (DIE_SIDES,NUMBER_OF_ROLLS))
    print("determine the average outcome on the pair of dice.")
    print()


def calculateAverageOutcome():
    """Rolls a pair of dice the correct number of times, tallies the outcomes, and
       returns the average outcome."""
    outcomesTotal = 0
    for count in range(NUMBER_OF_ROLLS):
        Die1.roll()
        Die2.roll()
        outcome = Die1 + Die2
        outcomesTotal += outcome


    return outcomesTotal / NUMBER_OF_ROLLS


def displayResults(averageOutcome):
    """ Displays the average outcome"""
    print("The average outcome was %3.1f." % averageOutcome)
    
main()
    
        
    
    


