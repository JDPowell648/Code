package kitchen;

public class HotPocketDriver
{
    public static void main( String[] args )
    {
        Oven o1 = new Oven( );
        Microwave m1 = new Microwave( );
        ToasterOven to1 = new ToasterOven( );

        o1.cook( 120 );
        m1.cook( 60 );
        to1.cook( 200 );

        System.out.println( to1.getBrand( ) );

        // Creates  an array of size 3 containing references to
        // CookingAppliance objects
        CookingAppliance[] myKitchen = new CookingAppliance[3];

        myKitchen[0] = o1;
        myKitchen[1] = m1;
        myKitchen[2] = to1;

        //myKitchen[2].toast( );
        to1.toast( );

        // **What** messages I can send objects referred to in myKitchen
        // is determined statically (before runtime).  Even though
        // myKitchen[2] is a ToasterOven when we run it, Java cannot
        // promise that before runtime given the types I've specified.

        // What code is executed in response to that message, however,
        // is determined dynamically (dynamic dispatch)

        // That means this will print 'Nuking', even though the only thing
        // I know statically at this point is that it's a CookingAppliance
        // that would print 'Cooking'
        myKitchen[1].cook( 500 );
    }
}
