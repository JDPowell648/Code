"""
Author: Joshua Powell
File: lab12.py
Description:
"""
def removePuncuation(string):
    string = string.replace(".","")
    string = string.replace(",","")
    string = string.replace("?","")
    string = string.replace("!","")
    string = string.replace(";","")
    string = string.replace("(","")
    string = string.replace(")","")
    string = string.replace("{","")
    string = string.replace("}","")
    string = string.replace(":","")
    string = string.replace("-"," ")
    return string

def createWordList(File):
    wordString = ""
    wordList = []
    masterList = []
    fin = open(File, "r")
    wordString = fin.read().replace('\n', ' ')
    wordString = wordString.lower()
    wordString = removePuncuation(wordString)
    wordList = wordString.split()
    return wordList

def countUniqueWords(File):
    wordString = ""
    wordList = []
    uniqueList = []
    wordList = createWordList(File)
    for index in range(0,len(wordList)):
        if wordList[index] not in uniqueList:
            uniqueList.append(wordList[index])
    return len(uniqueList)

def countTimes(File):
    wordDict = {}
    wordList = createWordList(File)
    for word in wordList:
        if word not in wordDict:
            wordDict[word] = 1
        else:
            wordDict[word] += 1
    return wordDict

def sorting(inputDict):
    from operator import itemgetter
    keyList = list(inputDict.keys())
    countList = list(inputDict.values())
    item = []
    wordList = []
    for data in range(0,len(keyList)):
        item = [keyList[data],countList[data]]
        wordList.append(item)
    wordList = sorted(wordList, key=itemgetter(1,0))
    wordList.reverse()
    return readable(wordList)

def readable(inputList):
    item = []
    for data in range(0,len(inputList)):
        item = inputList[data]
        print(item[0], "---->", item[1])
