""" Heap Sort """
from binheap import BinHeap
# methods: BinHeap(), insert(item), delMin(), isEmpty(), size()

def heapSort(myList):
    # Create an empty heap
    minHeap = BinHeap()

    # Add all list items to minHeap
    minHeap.buildHeap(myList)
    
    # delMin heap items back to list in sorted order
    size = len(myList)
    for index in range(0,size):
        myList[index] = (minHeap.delMin())
