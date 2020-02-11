package uno;

public class ValueCard extends UnoCard
{
    private final int value;

    public ValueCard( ColorType c, int val )
    {
        super( c );
        value = val;
    }

    public int getValue( )
    {
        return value;
    }
}
