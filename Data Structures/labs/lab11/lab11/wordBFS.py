from build_graph import buildGraph

from graph_algorithms import bfs

g = buildGraph("words.dat")

print("word ladder graph:")
for v in g:
    print(v)

bfs(g, g.getVertex("fool"))

print("\n================================================\n")

v = g.getVertex("sage")
while v != None:
    print(v.getId())
    v = v.getPred()
