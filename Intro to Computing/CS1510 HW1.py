"""
Author: Joshua Powell
File: hw08.py
Description:
"""

def sortingPlayers(inputFile, dataIndex):
    """This function finds the top 10 players in regards to a certain index
    ID=0 First = 1 Last = 2 leag = 3 gp = 4 min = 5 pts = 6
    oreb = 7 dreb = 8 reb = 9 asts = 10 stl = 11 blk = 12 turnovers = 13
    pf = 14 fga = 15 fgm = 16 fta = 17 ftm = 18 tpa = 19 tpm = 20 efficiency = 21
    """
    from operator import itemgetter
    scores = []
    loops = 0
    fin = open(inputFile, 'r')
    if dataIndex >= 4 and dataIndex <21:
        for data in fin:
            lineList = data.split(",")
            if len(data.split(",")) > 1 and loops > 0:
                outputData = (lineList[dataIndex])
                playerList = [lineList[1],lineList[2], int(outputData)]
                scores.append(playerList)
            loops += 1
    elif dataIndex == 21:
        for data in fin:
            lineList = data.split(",")
            if len(data.split(",")) > 1 and loops > 0:
                playerList = [lineList[1],lineList[2], efficiency2(int(lineList[6]), int(lineList[9]), int(lineList[10]), int(lineList[11]), int(lineList[12]), int(lineList[15]), int(lineList[16]),
                                                                  int(lineList[17]), int(lineList[18]), int(lineList[13]), int(lineList[4]))]
                scores.append(playerList)
            loops += 1
    else:
        scores = "ERROR"
        return(scores)
    scores = sorted(scores, key=itemgetter(2,0,1))
    scores.reverse()
    scores = scores[:10]
    return(scores)

def top10(inputlist):
    """This function converts the output from sortingPlayers
    into a readable output"""
    item = []
    player = ""
    if inputlist == "ERROR":
        print("Please enter a valid index.")
        return
    for loops in range(0,len(inputlist)):
        item = inputlist[loops]
        item  = item[:2]
        player = ' '.join(item)
        print(player + "-" + str(inputlist[loops][2]))

def main():
    print("Top 10 players based on total points scored.")
    top10(sortingPlayers("player_career.csv", 6))
    print()

    print("Top 10 players based on total minutes.")
    top10(sortingPlayers("player_career.csv", 5))
    print()
     
    print("Top 10 players based on total free throws.")
    top10(sortingPlayers("player_career.csv", 18))
    print()

    print("Top 10 players based on total efficiency.")
    top10(sortingPlayers("player_career.csv", 21))

def efficiency2(pts, reb, asts, stl, blk, fga, fgm, fta, ftm, turnover, gp):
    return ((pts + reb + asts + stl + blk) - ((fga - fgm) + (fta - ftm) + turnover))/(gp)
