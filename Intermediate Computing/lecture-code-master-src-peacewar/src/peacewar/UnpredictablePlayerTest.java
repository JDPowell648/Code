package peacewar;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class UnpredictablePlayerTest
{
    private Player p1;

    @BeforeEach
    public void setUp( )
    {
        p1 = new UnpredictablePlayer( "Andy" );
    }

    @Test
    public void testUnpredictableChoices( )
    {
        int[] totals = new int[2];

        for( int i = 0; i < 1_000_000; i++ )
        {
            boolean choice = p1.willMakePeace( );
            if( choice )
            {
                totals[0]++;
            }
            else
            {
                totals[1]++;
            }
        }

        assertTrue( Math.abs( totals[0] - 500_000 ) < 250,
                "May not be random, run again to be sure" );
    }
}