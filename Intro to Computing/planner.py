'''
Author: Joshua Powell
File: planner.py
Description: A by-the-hour planner for daily and weekly use
'''

from random import randint

def makeList(inputList):
        for index in range(0,24):
            inputList.append([index, "unscheduled", False])
        return inputList

class planner():
    def __init__(self):
        self.weekDict = {"monday":makeList([]),"tuesday":makeList([]),"wednesday":makeList([]),"thursday":makeList([]),"friday":makeList([]),"saturday":makeList([]),"sunday":makeList([])}

    def schedule(self):
        event = str(input("What are you scheduling? (enter anything) "))
        day = str(input("What day would you like to schedule this event? ")).lower()
        
        while day not in ["monday","tuesday","wednesday","thursday","friday","saturday","sunday"]:
            day = str(input("Please enter a valid day: ")).lower()
            
        self.check(day)
        time = int(input("What time is this event? (24 hour clock, input an integer 0-23) "))

        while time not in range(0,24):
            time = int(input("Please enter a valid time (24 hour clock, input an integer 0-23) "))
        
        length = int(input("How many hours long is this event? "))

        while time + length > 24:
            print("This event is longer than your day! Please try again. ")
            length = int(input("How many hours is this event? "))
            
        if self.weekDict[day][time][2] == False:
            if day in self.weekDict:
                self.weekDict[day][time][1] = event
                self.weekDict[day][time][2] = True
                if length > 1:
                    for index in range(0,length):
                        if self.weekDict[day][time + index][2] == False:
                                self.weekDict[day][time + index][1] = event
                                self.weekDict[day][time + index][2] = True
            print("The event has been successfully scheduled\n")
        else:
            print("Time time is already scheduled with:", self.weekDict[day][time][1])


    def unschedule(self):
        day = str(input("What day are you unscheduling on? ")).lower()
        while day not in ["monday","tuesday","wednesday","thursday","friday","saturday","sunday"]:
            day = str(input("Please enter a valid day: ")).lower()
        self.check(day)
        hour = int(input("What hour would you like to unschedule? (24 hour clock, input an integer 0-23) "))
        while hour not in range(0,24):
            hour = int(input("Please enter a valid time (24 hour clock, input an integer 0-23) "))
        self.weekDict[day][hour][1] = "unscheduled"
        self.weekDict[day][hour][2] = False
        print("The event has been successfully unscheduled\n")

    def check(self,day):
        print(str(day), "looks like:")
        for index in range(0,24):
            hour = [str(index) + ":00", self.weekDict[day][index][1]]
            print(hour)

    def weekCheck(self):
        print("Your week looks like:")
        for index in range(0,24):
            hour = [str(self.weekDict["saturday"][index][1]),str(self.weekDict["monday"][index][1]),
                    str(self.weekDict["tuesday"][index][1]), str(self.weekDict["wednesday"][index][1]),
                    str(self.weekDict["thursday"][index][1]), str(self.weekDict["friday"][index][1]),str(self.weekDict["sunday"][index][1])]
            print(hour)
            
    def tip(self):
        tipList = ["Write down long term goals to keep direction in life!","Write down short term goals to keep direction in working hours!","Remember to relax! 8 hours of sleep every day is ideal.",
                   "Delegate easier tasks to other people to avoid time wasting!","Do harder work during the most productive times of the day!","Time management is the best way to reduce stress.",
                   "Time management raises the quality of life.","People tend to wrongly assume how long a task will take, and usually don't recall management failures.","Procrastination is a form of stress management, but\nTime Management lowers stress to a higher degree.",
                   "Time management originated in the industrial revolution.","Keep a to-do list!","Make sure to watch your schedule!","Don't waste time!","Time management lowers stress to a higher degree than leisure activities."]
        int = randint(0,len(tipList) - 1)
        print("\nTip: " + tipList[int] + "\n")
                   
    def __str__(self):
        return str(self.weekDict)
        
plan = planner()
print("This program is a by-the-hour planner for the week!\n\nEnter a command in the console below to get started.\n\nUnique instructions will be given when a command is executed to\nguide you through the process.\n")
while True:
    userInput = str(input("Commands: \ns = schedule an event!\nu = unschedule an event!\nd = check a day's schedule\nw = check the week's schedule\nt = Get a time management tip!\nx = quit \n\nWhat would you like to do? "))
    if userInput == "s":
        plan.schedule()
    elif userInput == "u":
        plan.unschedule()
    elif userInput == "d":
        day = str(input("What day are you checking? ")).lower()
        while day not in ["monday","tuesday","wednesday","thursday","friday","saturday","sunday"]:
            day = str(input("Please enter a valid day: ")).lower()
        plan.check(day)
    elif userInput == "w":
        print("Each column is a day of the week, Sunday-Saturday")
        plan.weekCheck()
    elif userInput == "t":
        plan.tip()
    elif userInput == "x":
        break
    else:
        print("That is not a valid command!\n")
