# timeBinarySearch.py
"""Times the iterative binary search repeatedly"""

from time import perf_counter
from binarySearch import binarySearch

testSize = 10000                       # Number of items to search consisting of
evenList = list(range(0, 2*testSize, 2))     # even numbers from 0 to 2*(testSize-1)


start = perf_counter()
for target in range(2*testSize):
    binarySearch(target, evenList)
# end for
end = perf_counter()
runTime = end - start
print( "Time to run Iterative BinarySearch to locate targets 0 to %d is %.4f sec." % \
      (2*testSize - 1, runTime))




