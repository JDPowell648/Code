"""
Author: Joshua Powell
File: hw07.py
Description:
"""

def findFirstVowel(word):
    """Finds the first vowel in a word"""
    vowelstr = "aeuio"
    newstr = ""
    char = ""
    word = word.lower()
    for loops in range(0,len(word)):
       char = word[loops]
       if char in vowelstr:
           return loops
    return -1

def translateWord(word):
    """Translates a word to pig latin"""
    char = ""
    newstr = ""
    translatedstr = ""
    index = findFirstVowel(word)
    for loops in range(0,len(word)):
        char = word[loops]
        if (index == 0):
            return word + "way"
        elif (index == -1):
            return word
        if (loops >= index):
            translatedstr = translatedstr + char
        else:
            newstr = newstr + char
    return translatedstr.lower() + newstr.lower() + "ay"

def pigLatinTranslator(sentence):
    wordList = sentence.split()
    word = ""
    translatedWord = ""
    newstr = ""
    char = ""
    for loops in range(0, len(wordList)):
        word = wordList[loops]
        translatedWord = translateWord(word)
        if loops == 0:
            translatedWord = translatedWord.capitalize()
        if "." in translatedWord:
            word = ""
            for index in range(0, len(translatedWord)):
                char = translatedWord[index]
                if char != ".":
                    word = word + char
            word = word + "."
            translatedWord = word
            newstr = newstr + translatedWord
        else:
            newstr = newstr + translatedWord + " "
    return newstr
    
