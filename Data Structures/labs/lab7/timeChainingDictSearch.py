# timeChainingDictSearch.py
"""Times the searching of the ChainingDict that uses hashing
   with chaining, i.e., UnorderedList objects at each hash table slot."""

from time import perf_counter
from chaining_dictionary import ChainingDict

testSize = 10000                   # Number of items to search consisting of
evensDict = ChainingDict(2**14)
for i in range(0, 2*testSize, 2):  # even numbers from 0 to 2*(testSize-1)
    evensDict[i] = i
print( "Done entering values in ChainingDict -- Beginning accesses")
start = perf_counter()
for target in range(2*testSize):
    value = evensDict[target]
# end for
end = perf_counter()
runTime = end - start
print( "Time to use a ChainingDict of %d size to locate targets 0 to %d is %.6f sec." % \
      (2**14, 2*testSize - 1, runTime))




