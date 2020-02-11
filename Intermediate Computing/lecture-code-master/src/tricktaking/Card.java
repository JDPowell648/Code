package tricktaking;

public class Card
{
    private final int suit;
    private final int rank;

    // Note I have two constructors.  This is an example of an
    // "overloaded" constructor: two methods with the same name but
    // different "signatures" (parameter lists)

    public Card( int val )
    {
        suit = val / 13;
        rank = val % 13;
    }

    public Card( int st, int rnk )
    {
        suit = st;
        rank = rnk;
    }

    public int getSuit( )
    {
        return suit;
    }

    public int getRank( )
    {
        return rank;
    }

    public String toString( )
    {
        int codePoint = 127137 + suit * 16 + rank;

        if( rank > 10 )
        {
            codePoint++;
        }

        return new String( Character.toChars( codePoint ) );
    }
}
