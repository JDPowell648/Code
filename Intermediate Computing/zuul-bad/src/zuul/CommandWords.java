package zuul;

/**
 * This class is part of the "World of Zuul" application. 
 * "World of Zuul" is a very simple, text based adventure game.  
 * 
 * This class holds an enumeration of all command words known to the game.
 * It is used to recognise commands as they are typed in.
 *
 * @author  Michael Kolling and David J. Barnes
 * @version 1.0 (February 2002)
 */

public class CommandWords
{
    // a constant array that holds all valid command words
    private static final String[] validCommands = {
        "go", "quit", "help", "look"
    };

    /**
     * Constructor - initialise the command words.
     */
    public CommandWords()
    {
        // nothing to do at the moment...
    }

    /**
     * Check whether a given String is a valid command word. 
     * Return true if it is, false if it isn't.
     */
    public boolean isCommand(String aString)
    {
        for (String validCommand : validCommands) {
            if (validCommand.equals(aString))
                return true;
        }
        // if we get here, the string was not found in the commands
        return false;
    }

    public String showAll(){
        String outStr = "";
        for(var item : validCommands){
            outStr += item + ' ';
        }
        return outStr;
    }

}
