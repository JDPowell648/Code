"""
Author: Joshua Powell
File: lab12.py
Description:
"""
def removePuncuation(string):
    string = string.replace(".","")
    string = string.replace("?","")
    string = string.replace("!","")
    string = string.replace(";","")
    string = string.replace("(","")
    string = string.replace(")","")
    string = string.replace("{","")
    string = string.replace("}","")
    string = string.replace(":","")
    string = string.replace("-"," ")
    string = string.replace("'","")
    return string

def compareTwoMovies(Movie1, Movie2):
    movieList = []
    movieDict = {}
    actorSet = set()
    fin = open("actors.txt", "r")
    Lines = fin.read().split("\n")
    
    for data in range(0,len(Lines)):
        movieList = Lines[data].split(",")
        actorSet = set(movieList[1:])
        movieDict[movieList[0]] = actorSet
        
    UnionStr = str(movieDict[Movie1] | movieDict[Movie2])
    UnionStr = removePuncuation(UnionStr)
    IntersectStr = str(movieDict[Movie1] & movieDict[Movie2])
    IntersectStr = removePuncuation(IntersectStr)
    SymmDiffStr = str(movieDict[Movie1] ^ movieDict[Movie2])
    SymmDiffStr = removePuncuation(SymmDiffStr)
    print("The union of", Movie1, "and", Movie2, "is:", UnionStr)
    print("The intersection of", Movie1, "and", Movie2, "is:", IntersectStr)
    print("The symmetric difference of", Movie1, "and", Movie2, "is:", SymmDiffStr)


def coActors(Actor):
    movieList = []
    masterList = []
    actorIndex = ""
    actorSet = set()
    coString = ""
    found = False
    fin = open("actors.txt", "r")
    Lines = fin.read().split("\n")
    movieList = []
    
    for data in range(0,len(Lines)):
        movieList = Lines[data].split(",")
        movieList = movieList[1:]
        if Actor in movieList:
            masterList.append(movieList)
            found = True
        for index in range(0,len(masterList)):
            movieList = masterList[index]
            for index2 in range(0,len(movieList)):
                actorIndex = movieList[index2]
                if actorIndex != Actor:
                    actorSet.add(actorIndex)

    if found == False:
        print(Actor, "is not in database")
        return
    
    coString = str(actorSet)
    coString = removePuncuation(coString)
    print(Actor, "has also starred with:", coString)
