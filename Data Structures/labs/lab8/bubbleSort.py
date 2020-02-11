'''
    Description:  Sorts myList in ascending order using a bubble sort.
    File:  bubbleSort.py
'''

def bubbleSort(myList):
    """Rearranges the items in myList so they are in ascending order"""
    for lastUnsortedIndex in range(len(myList)-1,0,-1):
        # scan the Before sorting part at the beginning of myList
        for testIndex in range(lastUnsortedIndex):
            # if we find two adjacent items out of order, switch them
            if myList[testIndex] > myList[testIndex+1]:
                temp = myList[testIndex]
                myList[testIndex] = myList[testIndex+1]
                myList[testIndex+1] = temp

            
import random

def shuffle(myList):
    for fromIndex in range(len(myList)):
        toIndex = random.randint(0,len(myList)-1)
        temp = myList[fromIndex]
        myList[fromIndex] = myList[toIndex]
        myList[toIndex] = temp
    

import time
            
print("bubbleSort Timings")            
aList = list(range(10000,0,-1))
print( "\nBefore sorting list: ",end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
start = time.perf_counter()
bubbleSort(aList)
end = time.perf_counter()
print( "sorted list:", end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
print( "Time to sort",end - start,"seconds")

print( "\nBefore sorting list: ", end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
start = time.perf_counter()
bubbleSort(aList)
end = time.perf_counter()
print( "sorted list:", end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
print( "Time to sort",end - start,"seconds")

aList = list(range(10000,0,-1))
shuffle(aList)
print( "\nBefore sorting (random) list: ",end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
start = time.perf_counter()
bubbleSort(aList)
end = time.perf_counter()
print( "sorted list:",end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
print( "Time to sort",end - start,"seconds")

aList = list(range(10000,0,-1))
shuffle(aList)
print( "\nBefore sorting (random) list: ",end='')
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
start = time.perf_counter()
bubbleSort(aList)
end = time.perf_counter()
print( "sorted list:",end="")
print( aList[0],aList[1],aList[2], '...',aList[-3], aList[-2],aList[-1])
print( "Time to sort",end - start,"seconds")

input("Hit <Enter>-key to end")
