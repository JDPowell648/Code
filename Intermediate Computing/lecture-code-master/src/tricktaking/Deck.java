package tricktaking;

import java.util.ArrayList;
import java.util.Collections;

public class Deck
{
    // A constant defining the number of cards in our deck
    // The keyword 'static' denotes a "class variable" -- it exists
    // regardless of how many instances of this object I create, and all
    // instances share it.
    private static final int NUM_CARDS_IN_DECK = 52;

    // INSTANCE VARIABLES:
    // Create an ArrayList of type Card which is initially empty.
    private ArrayList<Card> cards = new ArrayList<>( );

    // If I don't define a constructor, I get one for free:
    // the default constructor, which takes no parameters

    // I'm going to define a constructor with no parameters
    public Deck( )
    {
        for( int i = 0; i < NUM_CARDS_IN_DECK; i++ )
        {
            cards.add( new Card( i ) );
        }

        Collections.shuffle( cards );
    }

    public Card drawCard( )
    {
        // Remove the Card from cards and return it
        return cards.remove( 0 );
    }

    public boolean isEmpty( )
    {
        return cards.isEmpty( );
    }
}