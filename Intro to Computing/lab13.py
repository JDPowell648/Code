"""
File: lab13.py
Author: Joshua Powell
Purpose: Sorting Customer Data
"""
def outputFormat(inputList):
    item = []
    for data in range(0,len(inputList)):
        item = inputList[data]
        print(item[0], "->", item[1])

def dictConverter(inputDict):
    from operator import itemgetter
    item = ""
    stateList = []
    keyList = []
    countList = []
    outputList = []
    
    keyList = list(inputDict.keys())
    countList = list(inputDict.values())
    
    for data in range(0,len(keyList)):
        item = [keyList[data],countList[data]]
        outputList.append(item)

    outputList = sorted(outputList, key=itemgetter(0,1))
    return outputList
        
def getStateDistribution():
    loops = 0
    stateDict = {}
    
    fin = open("FakeCustomerData.txt", 'r')
    for data in fin:
        if loops > 0:
            if data.split(",")[7] not in stateDict:
                stateDict[data.split(",")[7]] = 1
            else:
                stateDict[data.split(",")[7]] += 1
        loops += 1
    outputFormat(dictConverter(stateDict))

def getColumnDistribution(filename,columnNum):
    loops = 0
    stateDict = {}
    fin = open(filename, 'r')
    for data in fin:
        if columnNum > len(data.split(",")):
            print("There is no column number", str(columnNum))
            return
        if loops > 0:
            if data.split(",")[columnNum] not in stateDict:
                stateDict[data.split(",")[columnNum]] = 1
            else:
                stateDict[data.split(",")[columnNum]] += 1
        loops += 1
    outputFormat(dictConverter(stateDict))

def getBirthYearDistribution():
    loops = 0
    stateDict = {}
    
    fin = open("FakeCustomerData.txt", 'r')
    for data in fin:
        if loops > 0:
            if data.split(",")[12].split("/")[2] not in stateDict:
                stateDict[data.split(",")[12].split("/")[2]] = 1
            else:
                stateDict[data.split(",")[12].split("/")[2]] += 1
        loops += 1
    outputFormat(dictConverter(stateDict))
