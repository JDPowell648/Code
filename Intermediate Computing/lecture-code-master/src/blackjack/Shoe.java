package blackjack;

import java.util.ArrayList;

public class Shoe
{
    // Create a private "ArrayList of type Card"
    private ArrayList<Card> shoe = new ArrayList<>( );

    // Shoe has no 'default constructor' since I created one
    // myself

    public Shoe( int numDecks )
    {
        // a Java for loop
        // First, we'll create a variable called 'i' and set it to 0
        // Next, I'll check to see if 'i' is less than numDecks.
        //    If so, I'll execute the loop body.
        //    If not, I'll jump to the first statement after the loop
        // Next, I'll add one to 'i', then repeat my
        //       continuation condition check and run
        for( int i = 0; i < numDecks; i++ )
        {
            addDeck( );
        }
    }

    // This is called a "helper method" -- something I've created just to
    // assist this class alone in implementing behavior.
    private void addDeck( )
    {
        Deck d = new Deck( );

        // As long as the Deck is not empty, add a card to the shoe
    }
}
