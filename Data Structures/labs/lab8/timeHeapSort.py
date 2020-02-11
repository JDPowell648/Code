""" File:  timeHeapSort.py
    Description:  Times the heap sort algorithm on random data"""

import time
import random
from heapSort import heapSort

def main():
    n = int(input("Enter the number of items you would like to sort: "))
    myList = []
    for index in range(n):
        myList.append(random.randint(1, n))

    #print( "Unsorted List:", myList)
    start = time.perf_counter()

    heapSort(myList)
    
    endSort = time.perf_counter()

    #print( "Sorted List:  ", myList)
    print( "Total heap sort time of", n, "random items %7.6f" % (endSort - start))

    
main()
