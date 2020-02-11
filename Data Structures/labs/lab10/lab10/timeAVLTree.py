# timeAVLTree.py
"""Times the AVL tree search repeatedly"""

from time import perf_counter
from avl_tree import AVLTree
import sys
import random

def shuffle(myList):
    for fromIndex in range(len(myList)):
        toIndex = random.randint(0,len(myList)-1)
        temp = myList[fromIndex]
        myList[fromIndex] = myList[toIndex]
        myList[toIndex] = temp


print("AVLTree()")
myAVLTree = AVLTree()
testSize = 10000                     # Number of items to search consisting of
myList = list(range(testSize))    
#shuffle(myList)
print("Starting to add SORTED items 0 to",testSize-1)
start = perf_counter()
for item in myList:
    myAVLTree.put(item, item)
end = perf_counter()
runTime = end - start
print( "Time to add items 0 to %d is %.4f sec.\n" % (testSize - 1, runTime))

print("Starting to search for 0 to",testSize-1)
start = perf_counter()
for target in range(testSize):
    target in myAVLTree
# end for
end = perf_counter()
runTime = end - start
print( "Time to search for targets 0 to %d is %.4f sec.\n" % (testSize - 1, runTime))
print("AVL Tree Height after inserting in sorted order:", myAVLTree.height())
print("\n==============================================================\n")

myAVLTree = AVLTree()
testSize = 10000                     # Number of items to search consisting of
myList = list(range(testSize))    
shuffle(myList)
print("Starting to add SHUFFLED items 0 to",testSize-1)
start = perf_counter()
for item in myList:
    myAVLTree.put(item, item)
end = perf_counter()
runTime = end - start
print( "Time to add items 0 to %d is %.4f sec.\n" % (testSize - 1, runTime))

print("Starting to search for 0 to",testSize-1)
start = perf_counter()
for target in range(testSize):
    target in myAVLTree
# end for
end = perf_counter()
runTime = end - start
print( "Time to search for targets 0 to %d is %.4f sec.\n" % (testSize - 1, runTime))
print("AVL Tree Height after inserting in shuffled order:", myAVLTree.height())

