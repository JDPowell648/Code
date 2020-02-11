package Uno;

public class WildCard extends UnoCard
{
    private ColorType calledColor;

    public WildCard( )
    {
        super( ColorType.BLACK );
    }

    // When you play a WildCard, you will specify what color you want it to
    // represent (aka what color the next person must follow).
    public void callColor( ColorType newColor )
    {
        calledColor = newColor;
    }

    public ColorType getCalledColor( )
    {
        return calledColor;
    }
}
