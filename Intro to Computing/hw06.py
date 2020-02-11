"""
Author: Joshua Powell
File: hw06.py
Description: Creates a spreadsheet of data
"""

file_in = input('What is the input file? ')
file_out = input('What is the output file? ')

fin = open(file_in, 'r')
fout = open(file_out, 'w')

header = fin.readline().rstrip('\n') + ",Density" + "\n"
fout.write(header)

for data in fin:
    State,Population,Area = data.split(",")

    StateName = State
    Pop = int(Population)
    LocalArea = float(Area)
    if(LocalArea % 1 == 0):
        LocalArea = int(round(LocalArea))
    Density = Pop/LocalArea

    fout.write(State+","+str(Pop)+","+str(LocalArea)+","+str(Density)+"\n")

fin.close()
fout.close()
