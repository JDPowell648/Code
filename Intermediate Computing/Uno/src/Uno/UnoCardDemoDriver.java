package Uno;

public class UnoCardDemoDriver
{
    public static void main( String[] args )
    {
        // The type of the *reference* determines what methods I can call.
        UnoCard c1;

        // The type of the *instance/object* determines what code is actually
        // executed. (dynamic dispatch)
        c1 = new WildCard();

        // To prevent ClassCastExceptions, we can check to make sure c1
        // is an instance of what we are going to cast it as before we
        // do the cast
        if( c1 instanceof WildCard )
        {
            ((WildCard) c1).callColor(UnoCard.ColorType.BLUE);
        }
        else if( c1 instanceof ValueCard )
        {
            // ...
        }
    }
}
