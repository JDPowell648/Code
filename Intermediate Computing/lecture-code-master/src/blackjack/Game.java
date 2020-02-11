package blackjack;

import java.util.ArrayList;

public class Game
{
    private ArrayList<Player> players;
    private Shoe shoe;

    public Game( int numDecks )
    {
        shoe = new Shoe( 6 );
    }

    // This method takes as a parameter an object of type Player, which
    // we will refer to as 'p' inside the method.
    public void addPlayer( Player p )
    {
        players.add( p );
    }

    // This method is visible to everyone; it returns an object
    // of type ArrayList of type Player, and takes no parameters
    public ArrayList<Player> getPlayers( )
    {
        return players;
    }
}
