# timeBinarySearchTree.py
"""Times the iterative binary search repeatedly"""

from time import perf_counter
from binary_search_tree import BinarySearchTree
import sys
import random

def shuffle(myList):
    for fromIndex in range(len(myList)):
        toIndex = random.randint(0,len(myList)-1)
        temp = myList[fromIndex]
        myList[fromIndex] = myList[toIndex]
        myList[toIndex] = temp

print("Default recursion limit:",sys.getrecursionlimit())
sys.setrecursionlimit(10000)
print("New recursion limit:",sys.getrecursionlimit())

bst = BinarySearchTree()
testSize = 3000                     # Number of items to search consisting of
evenList = list(range(0, 2*testSize, 2))     # even numbers from 0 to 2*testSize-1
shuffle(evenList)
print( "Starting to entering values in BinarySearchTree")
for item in evenList:
    bst.put(item, item)
print( "Done entering values in BinarySearchTree -- Beginning accesses")
print("Starting to search for 0 to",2*testSize-1)
start = perf_counter()
for target in range(2*testSize):
    target in bst
# end for
end = perf_counter()
runTime = end - start
print( "Time to run BinarySearchTree to locate targets 0 to %d is %.4f sec." % \
      (2*testSize - 1, runTime))


print("Height:", bst.height())


