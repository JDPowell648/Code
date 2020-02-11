package uno;

import java.util.ArrayList;
import java.util.Collection;

public class Player
{
    private Collection<UnoCard> hand = new ArrayList<>( );

    // This is for when you're given a card and *don't* have the option of
    // playing it right after (e.g. initial deal, Draw 2)
    public void addCard( UnoCard c )
    {
        hand.add( c );
    }

    // This might become an abstract method, or at least one we will override
    // in subclasses, since I want a player to choose their move in several
    // different ways
    public UnoCard takeTurn( UnoGameState state )
    {
        // Get the top card
        UnoCard top = state.getDiscardPile().get(
                state.getDiscardPile().size() - 1);

        for( UnoCard c : hand )
        {
            // Check to see if this card matches the color of top

            // Check to see if this card matches the value of top
        }

        // If we get here, we haven't returned a card;
        // Check for wild cards in the hand and play those

        return null;
    }

    public boolean takeDrawnCard( UnoCard c, UnoGameState state )
    {
        hand.add( c );
        return false;
    }
}
