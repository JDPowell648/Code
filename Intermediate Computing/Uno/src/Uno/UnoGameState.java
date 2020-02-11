package Uno;

import java.util.List;

public class UnoGameState
{
    // The state of the discard pile in the game (we need the top and the
    // size/history)
    private List<UnoCard> discardPile;

    private List<Integer> playerCardCounts;

    public UnoGameState( List<UnoCard> pile, List<Integer> count )
    {
        discardPile = pile;
        playerCardCounts = count;
    }

    public List<UnoCard> getDiscardPile()
    {
        return discardPile;
    }

    public List<Integer> getPlayerCardCounts( )
    {
        return playerCardCounts;
    }
}
