package tricktaking;

import java.util.ArrayList;

public class FaceCardPointScorer implements HandScorer
{
    @Override
    public int scoreHand( ArrayList<Card> cards )
    {
        int faceCardCount = 0;

        for( Card c : cards )
        {
            if( c.getRank( ) >= 10 )
            {
                faceCardCount++;
            }
        }

        return faceCardCount;
    }
}
