from graph import Graph
from graph_algorithms import prim

g = Graph()

graphFile = open("cities.txt")
cityList = []
print("Map graph:")
for cityLine in graphFile:
    currentCityList = cityLine.strip().split(':')
    city = currentCityList[0]
    x = eval(currentCityList[1])
    y = eval(currentCityList[2])
    cityList.append((city, x, y))
    print("city", city, "at x =", x, "y =", y)

for c1 in cityList:
    for c2 in cityList:
        if c1[0] != c2[0]:
            distance = ((c1[1]-c2[1])**2 + (c1[2]-c2[2])**2)**0.5
            g.addEdge(c1[0], c2[0], distance)
            g.addEdge(c2[0], c1[0], distance)

print("\nResulting Graph:")
for v in g:
    print (v)

print("\nStarting Prim's algorithm at vertex 'a'")
prim(g,g.getVertex("a"))

print("\nMinimum Spanning Tree Edges:")
for v in g:
    if v.getPred() != None:
        print(v.getPred().getId(), "to", v.getId())


