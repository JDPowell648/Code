package peacewar;

import java.util.ArrayList;

public abstract class Player
{
    private ArrayList<Boolean> opponentChoices = new ArrayList<>( );
    private String name;

    // Since I've created a constructor, I've now lost the default constructor.
    public Player( String name )
    {
        this.name = name;
    }

    // Java requires each 'method signature' to be unique.  A method signature
    // consists of:
    // (i) the name of the method
    // (ii) the 'parameter list' (type and order of parameters)
    //
    // If I have two methods with the same name but different parameter lists,
    // this is called 'method overloading'

    /* If I wanted to not have to implement a constructor in the subclass,
       I could create this constructor which takes no parameters
    public Player( )
    {
        name = "No Name Defined";
    }
    */

    // We'll assume 'true' means to make peace, 'false' means to make war
    //
    // 'abstract' means a Player must define how they do this (makePeace),
    // but I'm not going to implement it here
    //
    // This is a nice example of the 'strategy' design pattern
    public abstract boolean willMakePeace( );
    /*
    {
    Note this really isn't appropriate, since this isn't just a "player",
    this is a PacifistPlayer.
        return true;
    }
    */

    public void otherPlayerChose( boolean choice )
    {
        opponentChoices.add( choice );
    }

    public String getName( )
    {
        return name;
    }
}
