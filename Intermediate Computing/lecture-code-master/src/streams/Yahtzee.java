package streams;

import java.io.Serializable;
import java.util.ArrayList;

public class Yahtzee implements Serializable
{
    private int numPlayers;
    private ArrayList<Integer> scores = new ArrayList<>( );

    public Yahtzee( int players )
    {
        numPlayers = players;
        for( int i = 0; i < players; i++ )
        {
            scores.add( 0 );
        }
    }

    public int getNumPlayers( )
    {
        return numPlayers;
    }

    public int getScoreFor( int player )
    {
        return scores.get( player );
    }

    public void setScoreFor( int player, int score )
    {
        scores.remove( player );
        scores.add( player, score );
    }
}
