from graph import Graph
from graph_algorithms import dijkstra

def buildDigraph(graphFile):
    g = Graph()    
    gfile = open(graphFile,'r')
    # add edges from the graph file
    # NOTE: vertices are added automatically if they don't exist
    for line in gfile:
        edgeInfo = line.strip().split()
        g.addEdge(edgeInfo[0],edgeInfo[1], int(edgeInfo[2]))
    return g

print('\nDigraph:')
g = buildDigraph("dijkstraGraph.txt")
for v in g:
    print(v)

dijkstra(g,g.getVertex("v0"))

print('\nShortest Distance from v0:')
for v in g:
    print(v.getId(), 'distance from v0:',v.getDistance(), 'predecessor:',v.getPred())


