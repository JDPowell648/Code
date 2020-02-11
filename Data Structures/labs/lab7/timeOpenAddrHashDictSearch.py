# timeOpenAddrHashDictSearch.py
"""Times the searching of the OpenAddrHashDict that uses a hash table with
   linear probing"""

from time import perf_counter
from open_addr_hash_dictionary import OpenAddrHashDict

testSize = 10000                   # Number of items to search consisting of

evenHashTable = OpenAddrHashDict(2**14, hash, False)   # Linear probing
#evenHashTable = OpenAddrHashDict(2**14, hash, False)  # Quadratic probing

for i in range(0, 2*testSize, 2):  # even numbers from 0 to 2*(testSize-1)
    evenHashTable[i] = i
print( "Done entering values in OpenAddrHashDict -- Beginning accesses")
start = perf_counter()
for target in range(2*testSize):
    value = evenHashTable[target]
# end for
end = perf_counter()
runTime = end - start
print ("Time to use a OpenAddrHashDict with linear probing of %d size to locate targets 0 to %d is %.6f sec." % \
      (2**15, 2*testSize-1, runTime))
##print ("Time to use a OpenAddrHashDict with quadratic probing of %d size to locate targets 0 to %d is %.6f sec." % \
##      (2**14, 2*testSize-1, runTime))




