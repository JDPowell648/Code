from dfs_graph import DFSGraph

g = DFSGraph()

graphFile = open("pancakes.txt")
print("Pancake graph:")
for edgeLine in graphFile:
    print(edgeLine, end="")
    edgeList = edgeLine.strip().split(':')
    g.addEdge(edgeList[0], edgeList[1], int(edgeList[2]))
    
g.dfs()
print("\nAfter DFS:")
for v in g:
    print ( v.getId(),": discovery", v.getDiscovery(), "  finish", v.getFinish())


topographSortedList = []
for v in g:
    topographSortedList.append([v.getFinish(),v.getId()])

topographSortedList.sort()
topographSortedList.reverse()

for index in range (0,len(topographSortedList)):
    print("Step", str(index) + ": " + str(topographSortedList[index][1]))
