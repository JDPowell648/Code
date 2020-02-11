""" File:  timeQuickSort.py
    Description:  Times the Quick sort algorithm on random data"""

import time
import random
from quicksort import quicksort


def main():
    n = int(input("Enter the number of items you would like to sort: "))
    myList = []
    for index in range(n):
        myList.append(random.randint(1, n))

#    print("Unsorted List:",myList)
    start = time.perf_counter()

    quicksort(myList)

    endSort = time.perf_counter()

#    print( "Sorted List:  ",myList)
    print ("Total quick sort time of", n, "random items",endSort - start)

    
main()
