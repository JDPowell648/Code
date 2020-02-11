# timePriorityQueues.py

from reverse_sorted_list_priority_queue import ReverseSortedListPriorityQueue
from sorted_list_priority_queue import SortedListPriorityQueue
from list_priority_queue import ListPriorityQueue
from priority_queue import PriorityQueue
import time
import random

numberOfItems = 20000

myPriorityQueue = ListPriorityQueue()
print( "TIMING UNSORTED PYTHON LIST PRIORITY QUEUE")
start = time.perf_counter()

for i in range(numberOfItems):
    item = random.randint(1,numberOfItems)
    myPriorityQueue.enqueue(item)
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to enqueue", numberOfItems, "items: total =", totalTime, "seconds.")

start = time.perf_counter()
for i in range(numberOfItems):
    value = myPriorityQueue.dequeue()
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to dequeue", numberOfItems, "items: total =", totalTime, "seconds.")

print( "="*35)

myPriorityQueue = SortedListPriorityQueue()
print( "TIMING SORTED PYTHON LIST PRIORITY QUEUE")
start = time.perf_counter()

for i in range(numberOfItems):
    item = random.randint(1,numberOfItems)
    myPriorityQueue.enqueue(item)
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to enqueue", numberOfItems, "items: total =", totalTime, "seconds.")

start = time.perf_counter()
for i in range(numberOfItems):
    value = myPriorityQueue.dequeue()
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to dequeue", numberOfItems, "items: total =", totalTime, "seconds.")

print( "="*35)

myPriorityQueue = ReverseSortedListPriorityQueue()
print( "TIMING REVERSE SORTED PYTHON LIST PRIORITY QUEUE")
start = time.perf_counter()

for i in range(numberOfItems):
    item = random.randint(1,numberOfItems)
    myPriorityQueue.enqueue(item)
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to enqueue", numberOfItems, "items: total =", totalTime, "seconds.")

start = time.perf_counter()
for i in range(numberOfItems):
    value = myPriorityQueue.dequeue()
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to dequeue", numberOfItems, "items: total =", totalTime, "seconds.")

print( "="*35)

myPriorityQueue = PriorityQueue()
print( "TIMING HEAP PRIORITY QUEUE")
start = time.perf_counter()
for i in range(numberOfItems):
    item = random.randint(1,numberOfItems)
    myPriorityQueue.enqueue(item)
#end for
end = time.perf_counter()

totalTime = end - start
print( "Time to enqueue", numberOfItems, "items: total =", totalTime, "seconds.")

start = time.perf_counter()
for i in range(numberOfItems):
    value = myPriorityQueue.dequeue()
#end for
end = time.perf_counter()
totalTime = end - start
print( "Time to dequeue", numberOfItems, "items: total =", totalTime, "seconds.")

print( "="*35)
