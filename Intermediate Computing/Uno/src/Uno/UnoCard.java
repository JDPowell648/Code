package Uno;

public abstract class UnoCard
{
    // A type, at a high level, is (i) a set of legal values, and
    // (ii) operations we can perform on those values.

    // There are different types of UnoCards.  There are 'value cards' (with
    // numbers and colors), there are 'wild cards', 'reverse cards', and
    // 'skip cards', and 'draw cards'.

    // Ideally, we won't specify the type as an int, as this has 2^32 possible
    // values.
    // private int cardType = 0; // 0 is value, 1 is wild, 2 is reverse, ...

    // We can make the type be an enumerated type, but as was pointed out, the
    // behaviors change as well as the values, which makes the card type more
    // of a candidate for subclassing instead of just storing the type as state
    // public enum ActionType { VALUE, WILD, REVERSE, SKIP, DRAW };

    // With enumerated types, I can ensure that ColorType can only take one of
    // five possible values.
    public enum ColorType { RED, YELLOW, GREEN, BLUE, BLACK };

    private ColorType cardColor;
    //private ActionType cardType = ActionType.VALUE;

    public UnoCard( ColorType c )
    {
        cardColor = c;
    }

    public ColorType getColor( )
    {
        return cardColor;
    }
}
