# timeDictionaries.py
"""Times various dictionaries on random integer data"""

from time import perf_counter
from binary_search_tree import BinarySearchTree
from chaining_dictionary import ChainingDict
from closed_addr_using_bst_dictionary import ClosedAddrUsingBSTDict

import sys
import random

print("Default recursion limit:",sys.getrecursionlimit())
sys.setrecursionlimit(10000)
print("New recursion limit:",sys.getrecursionlimit())



def main():
    """ Times insertion and searching for random integers in varies dictionaries"""

    testSize = int(input("Enter the number of integers to store: "))
    evenList = list(range(0, 2*testSize, 2))     # even numbers from 0 to 2*testSize-1
    shuffle(evenList)  # randomize the list of evens

    # Create and time Python dictionary
    dictionary = {}
    timeDictionaryInsertsAndSearches(dictionary, "Python", evenList, testSize)

    # Create and time BST dictionary
    bstDictionary = BinarySearchTree()
    timeDictionaryInsertsAndSearches(bstDictionary, "bst", evenList, testSize)

    # Create and time ChainingDict dictionary
    chainingDictionary = ChainingDict(testSize)
    timeDictionaryInsertsAndSearches(chainingDictionary, "ChainingDict", evenList, testSize)
   
    # Create and time ClosedAddrUsingBSTDict dictionary
    ClosedAddrUsingBSTDictionary = ClosedAddrUsingBSTDict(testSize)
    timeDictionaryInsertsAndSearches(ClosedAddrUsingBSTDictionary, "ClosedAddrUsingBSTDict", evenList, testSize)

    print("main -- Done")
   
def shuffle(myList):
    for fromIndex in range(len(myList)):
        toIndex = random.randint(0,len(myList)-1)
        temp = myList[fromIndex]
        myList[fromIndex] = myList[toIndex]
        myList[toIndex] = temp

def timeDictionaryInsertsAndSearches(dictionary, dictString, evenList, testSize):
    print("\n\n===========================================================")
    print( "Starting to insert values into " + dictString)
    start = perf_counter()
    for item in evenList:
        dictionary[item] = item
    end = perf_counter()
    runTime = end - start
    print( "Time to insert even integer targets 0 to %d is %.4f sec." % \
          (2*testSize - 1, runTime))

    print("\nStarting successful searches for evens 0 to",2*testSize-2)
    start = perf_counter()
    for target in range(0, 2*testSize, 2):
        target in dictionary
    # end for
    end = perf_counter()
    runTime = end - start
    print( "Time to successfully search for even targets 0 to %d is %.4f sec." % \
          (2*testSize - 2, runTime))

    print("\nStarting unsuccessful searches for odds 1 to",2*testSize-1)
    start = perf_counter()
    for target in range(1, 2*testSize, 2):
        target in dictionary
    # end for
    end = perf_counter()
    runTime = end - start
    print( "Time to unsuccessfully search for odd targets 1 to %d is %.4f sec." % \
          (2*testSize - 1, runTime))

main()
