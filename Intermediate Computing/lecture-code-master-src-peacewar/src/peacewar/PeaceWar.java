package peacewar;

public class PeaceWar
{
    private Player player1, player2;

    // I'll explicitly initialize these to 0, even though by default it will
    // already
    private int player1Score = 0;
    private int player2Score = 0;
    private int roundsPlayed = 0;

    public PeaceWar( Player p1, Player p2 )
    {
        // Can't do this:
        // Player temp = new Player( "Andy" );
        player1 = p1;
        player2 = p2;
    }

    public void playRound( )
    {
        // Play two players against each other
        boolean p1Peace = player1.willMakePeace( );
        boolean p2Peace = player2.willMakePeace( );

        // Determine payout
        if( p1Peace && p2Peace )
        {
            player1Score = player1Score + 2;
            player2Score = player2Score + 2;
        }
        else if( p1Peace && !p2Peace )
        {
            player2Score = player2Score + 3;
        }
        else if( !p1Peace && p2Peace )
        {
            player1Score = player1Score + 3;
        }
        else // both made war
        {
            player1Score = player1Score + 1;
            player2Score = player2Score + 1;
        }

        // Share the choices
        player1.otherPlayerChose( p2Peace );
        player2.otherPlayerChose( p1Peace );

        // Increment 'roundsPlayed'
        roundsPlayed++;
    }

    public void playRounds( int numRounds )
    {
        // Play numRounds rounds against the two players
        for( int i = 0; i < numRounds; i++ )
        {
            playRound( );
        }
    }

    public String getStats( )
    {
        // return a String containing the stats for the game
        return "Rounds Played: " + roundsPlayed + "; P1 Score: "
                + player1Score + "; P2 Score: " + player2Score;
    }
}
