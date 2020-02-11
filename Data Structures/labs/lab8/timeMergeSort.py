""" File:  timeMergeSort.py
    Completed by:  Mark Fienup<PUT YOUR NAME HERE>
    Description:  Times the merge sort algorithm on random data"""

import time
import random
from mergesort import mergeSort

def main():
    n = int(input("Enter the number of items you would like to sort: "))
    myList = []
    for index in range(n):
        myList.append(random.randint(1, n))

    #print( "Unsorted List:",myList)
    start = time.perf_counter()

    mergeSort(myList)

    endSort = time.perf_counter()

    #print ("Sorted List:  ",myList)
    print ("Total merge sort time of", n, "random items",endSort - start)

    
main()
