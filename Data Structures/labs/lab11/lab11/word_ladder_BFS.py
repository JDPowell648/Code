from build_graph import buildGraph

from graph_algorithms import bfs

g = buildGraph("words.dat")

print("word ladder graph:")
for v in g:
    print(v)

print("\n============ bfs prints =======================\n")

bfs(g, g.getVertex("fool"))

print("\n================================================\n")


wordLadderList = []
v = g.getVertex("sage")
while v != None:
    wordLadderList.append(str(v.getId()))
    v = v.getPred()
wordLadderList.reverse()
print(wordLadderList)
