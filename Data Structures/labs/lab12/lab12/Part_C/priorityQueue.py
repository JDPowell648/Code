
import unittest

# this implementation of binary heap takes key value pairs,
# we will assume that the keys are all comparable

class PriorityQueue:
    def __init__(self):
        self.heapArray = [(0,0)]
        self.currentSize = 0
        self.keyToIndexDict = {}

    def buildHeap(self,alist):
        self.currentSize = len(alist)
        self.heapArray = [(0,0)]
        index = 1
        for item in alist:
            self.heapArray.append(item)
            priority, key = item
            self.keyToIndexDict[key] = index
            index += 1
        i = len(alist) // 2            
        while (i > 0):
            self.percDown(i)
            i = i - 1
                        
    def percDown(self,i):
        while (i * 2) <= self.currentSize:
            mc = self.minChild(i)
            if self.heapArray[i][0] > self.heapArray[mc][0]:
                tmp = self.heapArray[i]
                self.heapArray[i] = self.heapArray[mc]
                self.heapArray[mc] = tmp
                # update index for swapped keys
                self.keyToIndexDict[self.heapArray[i][1]] = i
                self.keyToIndexDict[self.heapArray[mc][1]] = mc
            i = mc
                
    def minChild(self,i):
        if i*2 > self.currentSize:
            return -1
        else:
            if i*2 + 1 > self.currentSize:
                return i*2
            else:
                if self.heapArray[i*2][0] < self.heapArray[i*2+1][0]:
                    return i*2
                else:
                    return i*2+1

    def percUp(self,i):
        while i // 2 > 0:
            if self.heapArray[i][0] < self.heapArray[i//2][0]:
                tmp = self.heapArray[i//2]
                self.heapArray[i//2] = self.heapArray[i]
                self.heapArray[i] = tmp
                # update index for swapped keys
                self.keyToIndexDict[self.heapArray[i][1]] = i
                self.keyToIndexDict[self.heapArray[i//2][1]] = i//2
            i = i//2
 
    def add(self,k):
        self.heapArray.append(k)
        self.currentSize = self.currentSize + 1
        self.keyToIndexDict[k[1]] = self.currentSize
        self.percUp(self.currentSize)

    def delMin(self):
        retval = self.heapArray[1][1]
        self.heapArray[1] = self.heapArray[self.currentSize]
        self.currentSize = self.currentSize - 1
        self.heapArray.pop()
        if self.currentSize >= 1:
            # update index for swapped keys
            #print("self.heapArray[1][1]", self.heapArray[1][1])
            self.keyToIndexDict[self.heapArray[1][1]] = 1
            self.percDown(1)
##        print("\nIN delMin():", self)
##        print(self.keyToIndexDict, "\n")
        del self.keyToIndexDict[retval]
        return retval
        
    def isEmpty(self):
        if self.currentSize == 0:
            return True
        else:
            return False

    def decreaseKey(self,val,amt):
        myKey = 0
        if val in self.keyToIndexDict:
            myKey = self.keyToIndexDict[val]
        if myKey > 0:
            self.heapArray[myKey] = (amt,self.heapArray[myKey][1])
            self.percUp(myKey)
        
## This is the O(n) version in the original for your reference 
##        done = False
##        i = 1
##        myKey = 0
##        while not done and i <= self.currentSize:
##            if self.heapArray[i][1] == val:
##                done = True
##                myKey = i
##            else:
##                i = i + 1
##        if myKey > 0:
##            self.heapArray[myKey] = (amt,self.heapArray[myKey][1])
##            self.percUp(myKey)
            
    def __contains__(self,vtx):
        if vtx in self.keyToIndexDict:
            return True
        else:
            return False
        
## This is the O(n) version in the original for your reference 
##        for pair in self.heapArray:
##            if pair[1] == vtx:
##                return True
##        return False
    def __str__(self):
        resultStr = ""
        for i in range(1, self.currentSize+1):
            resultStr += str(self.heapArray[i][0])+":"+ str(self.heapArray[i][1]) + " "
        return resultStr


##theHeap = PriorityQueue()
##theHeap.add((2,'x'))
##print(theHeap)
##theHeap.add((3,'y'))
##print(theHeap)
##theHeap.add((5,'z'))
##print(theHeap)
##theHeap.add((6,'a'))
##print(theHeap)
##theHeap.add((8,'d'))
##print(theHeap)
##print(theHeap.keyToIndexDict)
##theHeap.add((2,'f'))
##print(theHeap)
##print(theHeap.keyToIndexDict)
##print("delMin(): ", theHeap.delMin())
##print(theHeap)
##print(theHeap.keyToIndexDict)
##print("delMin(): ", theHeap.delMin())
##print(theHeap)
##print(theHeap.keyToIndexDict)
        
class TestBinHeap(unittest.TestCase):
    def setUp(self):
        self.theHeap = PriorityQueue()
        self.theHeap.add((2,'x'))
        print(self.theHeap)
        self.theHeap.add((3,'y'))
        self.theHeap.add((5,'z'))
        self.theHeap.add((6,'a'))
        self.theHeap.add((8,'d'))


    def testInsert(self):
        assert self.theHeap.currentSize == 5

    def testDelmin(self):
        print("in textDelmin")
        assert self.theHeap.delMin() == 'x'
        assert self.theHeap.delMin() == 'y'
    
    def testDecKey(self):
        self.theHeap.decreaseKey('d',1)
        value = self.theHeap.delMin()
        print("delMin value:", value)
        assert  value == 'd'
        
if __name__ == '__main__':
    unittest.main()
