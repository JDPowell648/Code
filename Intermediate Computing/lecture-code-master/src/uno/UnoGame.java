package uno;

import java.util.ArrayList;
import java.util.List;

public class UnoGame
{
    // This is an example of ... <dances across room> polymorphism </dance>
    private List<Player> players = new ArrayList<>( );

    private List<UnoCard> drawPile = new ArrayList<>( );
    private List<UnoCard> discardPile = new ArrayList<>( );

    private int nextPlayer;

    public UnoGame( Player... p )
    {
        // Copy over the players

        // Initialize the draw pile
        initializeDrawPile( );

        // Deal each player 7 cards from draw pile

        // Take one more card from draw pile and place in discard pile
    }

    public void playEntireGame( )
    {
        while( isStillPlaying( ) )
        {
            takeNextTurn( );
        }
    }

    public void takeNextTurn( )
    {
        // encapsulate the state as an UnoGameState object

        // Send to the next player

        // Either add their card to the discard pile *or* pass them a new
        // card and give them the option to play it
        // If given a card: verify it's valid, update state appropriately

        // increment nextPlayer
    }

    public boolean isStillPlaying( )
    {
        return true;
    }

    // Helper methods
    private boolean isLegalPlay( UnoCard c )
    {
        return true;
    }

    private void initializeDrawPile( )
    {
        drawPile.clear( );

        for( int i = 0; i < 4; i++ )
        {
            UnoCard.ColorType currentColor = UnoCard.ColorType.values()[i];

            // Add the zero for this color
            drawPile.add( new ValueCard( currentColor, 0 ) );

            // All of the following card types need to be added twice:
            for( int k = 0; k < 2; k++ )
            {
                // Add the other 9 value cards
                for( int j = 1; j < 10; j++ )
                {
                    drawPile.add( new ValueCard( currentColor, j ) );
                }

                // Add special card
                for( ActionCard.ActionType type :
                        ActionCard.ActionType.values( ) )
                {
                    drawPile.add( new ActionCard( currentColor, type ) );
                }
            }
        }

        // Add 4 WildCard and 4 WildDrawCard
        for( int i = 0; i < 4; i++ )
        {
            drawPile.add( new WildCard( ) );
            drawPile.add( new WildDrawCard( ) );
        }
    }
}
