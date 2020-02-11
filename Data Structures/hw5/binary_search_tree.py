
from tree_node import TreeNode

class BinarySearchTree:

    def __init__(self):
        self.root = None
        self.size = 0
        
    ############################################################
    # Dictionary interface for BST    
    def __len__(self):
        return self.size

    def __iter__(self):
        if self.size > 0:
            for key in self.root:
                yield key
##        else:
##            raise StopIteration

    def __getitem__(self,key):
        return self.get(key) 

    def __setitem__(self,k,v):
        self.put(k,v)

    def __delitem__(self,key):
        self.delete(key)

    def __str__(self):
        """Returns a string as expected by a dictionary. """
        if self.size == 0:
            return "{}"
        resultStr = "{"
        count = 0
        for key in self.root:
            if count == 0:
                resultStr += str(key) + ": " + str(self.get(key))
            else:
                resultStr += ", " + str(key) + ": " + str(self.get(key))
            count += 1
                                                   
        return resultStr + "}"
    

    def __contains__(self,key):
        if self._get(key,self.root):
            return True
        else:
            return False

    ############################################################
    # Non-dictionary BST methods

    def length(self):
        return self.size

    def height(self):
        
        def heightHelper(subtreeRoot):
            """ Recursive helper method to determine the height of the BST. """
            #  ADD CODE HERE
            pass

        # Start of height code: starts heightHelper with root node of BST
        return heightHelper(self.root)

    def get(self,key):
        if self.root:
            res = self._get(key,self.root)
            if res:
                return res.payload
            else:
                return None
        else:
            return None

    def _get(self,key,currentNode):
        if not currentNode:
            return None
        elif currentNode.key == key:
            return currentNode
        elif key < currentNode.key:
            return self._get(key,currentNode.leftChild)
        else:
            return self._get(key,currentNode.rightChild)


    def put(self,key,val):
        if self.root:
            self._put(key,val,self.root)
        else:
            self.root = TreeNode(key,val)
        self.size = self.size + 1

    def _put(self,key,val,currentNode):
        if key < currentNode.key:
            if currentNode.hasLeftChild():
                self._put(key,val,currentNode.leftChild)
            else:
                currentNode.leftChild = TreeNode(key,val,
                                          parent=currentNode)
        elif key > currentNode.key:
            if currentNode.hasRightChild():
                self._put(key,val,currentNode.rightChild)
            else:
                currentNode.rightChild = TreeNode(key,val,
                                          parent=currentNode)
        else:
            currentNode.payload = val
            self.size -= 1

    def delete(self,key):
      if self.size > 1:
          nodeToRemove = self._get(key,self.root)
          if nodeToRemove:
              self.remove(nodeToRemove)
              self.size = self.size-1
          else:
              raise KeyError('Error, key not in tree')
      elif self.size == 1 and self.root.key == key:
          self.root = None
          self.size = self.size - 1
      else:
          raise KeyError('Error, key not in tree')

    def remove(self,currentNode):
      if currentNode.isLeaf(): #leaf
        if currentNode == currentNode.parent.leftChild:
            currentNode.parent.leftChild = None
        else:
            currentNode.parent.rightChild = None
      elif currentNode.hasBothChildren(): #interior
        succ = currentNode.findSuccessor()
        succ.spliceOut()
        currentNode.key = succ.key
        currentNode.payload = succ.payload

      else: # this node has one child
        if currentNode.hasLeftChild():
          if currentNode.isLeftChild():
              currentNode.leftChild.parent = currentNode.parent
              currentNode.parent.leftChild = currentNode.leftChild
          elif currentNode.isRightChild():
              currentNode.leftChild.parent = currentNode.parent
              currentNode.parent.rightChild = currentNode.leftChild
          else:
              currentNode.replaceNodeData(currentNode.leftChild.key,
                                 currentNode.leftChild.payload,
                                 currentNode.leftChild.leftChild,
                                 currentNode.leftChild.rightChild)

        else:
          if currentNode.isLeftChild():
              currentNode.rightChild.parent = currentNode.parent
              currentNode.parent.leftChild = currentNode.rightChild
          elif currentNode.isRightChild():
              currentNode.rightChild.parent = currentNode.parent
              currentNode.parent.rightChild = currentNode.rightChild
          else:
              currentNode.replaceNodeData(currentNode.rightChild.key,
                                 currentNode.rightChild.payload,
                                 currentNode.rightChild.leftChild,
                                 currentNode.rightChild.rightChild)



def main():
    t = BinarySearchTree()
    t.put(5,5)
    t.put(3,3)
    t.put(8,8)
    t.put(10, 10)
    t.put(7,7)
    print(t)
    print("Height:",t.height())
    print("Iteration:")
    for k in t:
        print(k)

    print("iterate over empty tree")
#    input("Hit <Enter> to continue")
    s = BinarySearchTree()
    for k in s:
        print(k)
    print("Done")
#    input("Hit <Enter> to quit")
    return t

if __name__ == "__main__": t = main()

