package tricktaking;

import java.util.ArrayList;

public class SpadePointScorer implements HandScorer
{
    @Override
    public int scoreHand( ArrayList<Card> cards )
    {
        int spadeCount = 0;

        for( Card c : cards )
        {
            if( c.getSuit( ) == 0 )
            {
                spadeCount++;
            }
        }

        return spadeCount;
    }
}
