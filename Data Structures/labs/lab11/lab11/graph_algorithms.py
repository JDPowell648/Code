from graph import Graph
from vertex import Vertex
from linked_queue import LinkedQueue

def bfs(g,start):
  start.setDistance(0)
  start.setPred(None)
  vertQueue = LinkedQueue()
  print("enqueue:", start.getId())
  vertQueue.enqueue(start)
  while (vertQueue.size() > 0):
    currentVert = vertQueue.dequeue()
    print("   dequeue:", currentVert.getId())
    for nbr in currentVert.getConnections():
      if (nbr.getColor() == 'white'):
        nbr.setColor('gray')
        nbr.setDistance(currentVert.getDistance() + 1)
        nbr.setPred(currentVert)
        vertQueue.enqueue(nbr)
        print("enqueue:", nbr.getId())
    currentVert.setColor('black')

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

