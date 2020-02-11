"""
Author: Joshua Powell
File: wordReader.py
Description: Reads words and keeps their respective line number.

"""

from chaining_dictionary import ChainingDict
from open_addr_hash_dictionary import OpenAddrHashDict
from binary_search_tree import BinarySearchTree
from avl_tree import AVLTree

def lineList(inputFile, stopFile, dictType):
    """Reads words and keeps their respective line number"""

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
        return string
    
    fin = open(inputFile, 'r')
    stopIn = open(stopFile, 'r')
    wordList = []
    lineList = fin.read().split("\n")
    stopList = stopIn.read().split("\n")
    stopList.sort()
    print(stopList)
    wordDict = dictType

    for index in range(0,len(lineList)):
        wordList = lineList[index].split(" ")
        for index2 in range(0,len(wordList)):
            wordList[index2] = removePuncuation(wordList[index2])
            if wordList[index2] not in stopList:
                if wordList[index2].lower() not in wordDict:
                    wordDict[wordList[index2].lower()] = index + 1
                else:
                    wordDict[wordList[index2].lower()] = str(wordDict[wordList[index2].lower()]) + " " + str(index + 1)

    return wordDict

def main(inputFile, outputFile, stopFile, dictType):
    fout = open(outputFile, 'w')
    wordDict = lineList(inputFile, stopFile, dictType)
    keyList = list(wordDict.keys())
    keyList.sort()
    for data in range(0,len(keyList)):
        fout.write(str(keyList[data]) + ": " + str(wordDict[keyList[data]]) + "\n")
    #fout.write(str(wordDict))

main("hw6small.txt","outputFile.txt","stop_words_small.txt", {})
