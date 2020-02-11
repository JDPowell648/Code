from graph import Graph
from vertex import Vertex
from priorityQueue import PriorityQueue
import sys


def dijkstra(aGraph,start):  
  pq = PriorityQueue()
  start.setDistance(0)
  pq.buildHeap([(v.getDistance(),v) for v in aGraph])        
  while not pq.isEmpty():
    currentVert = pq.delMin()
    for nextVert in currentVert.getConnections():
      newDist = currentVert.getDistance() \
                + currentVert.getWeight(nextVert)
      if newDist < nextVert.getDistance():
        nextVert.setDistance( newDist )
        nextVert.setPred(currentVert)
        pq.decreaseKey(nextVert,newDist)  

def prim(G,start):
    pq = PriorityQueue()
    for v in G:
        v.setDistance(sys.maxsize)
        v.setPred(None)
    start.setDistance(0)
    pq.buildHeap([(v.getDistance(),v) for v in G])
    print("\nOrder edges added in Prim's algorithm:")
    while not pq.isEmpty():
        currentVert = pq.delMin()
        # extra print to trace order
        if currentVert.getPred() != None:
          print("Prim: edge",currentVert.getPred().getId(), "to", currentVert.getId())

        for nextVert in currentVert.getConnections():
          newCost = currentVert.getWeight(nextVert)
          # Printed textbook has incorrect "+ currentVert.getDistance()" term
          if nextVert in pq and newCost<nextVert.getDistance():
              nextVert.setPred(currentVert)
              nextVert.setDistance(newCost)
              pq.decreaseKey(nextVert,newCost)
        
    print("\n")
