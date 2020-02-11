"""
File Name: weather
Author: Joshua Powell
Description: Calculates percentage of cloudiness according to a chart
"""


Percentage = float(input("What percentage of the sky has clouds? "))

if Percentage <= 30:
    print("Clear")
if Percentage > 30 and Percentage <=70:
    print("Partly cloudy")
if Percentage > 70 and Percentage <=99:
    print("Cloudy")
if Percentage > 99:
    print("Overcast")
