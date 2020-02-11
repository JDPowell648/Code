package kitchen;

public class Microwave extends CookingAppliance
{
    /*
    --- moved into superclass ---
    public void cook( int time )
    {
        System.out.println( "Cooking for " + time + " seconds");
    }
    */

    // This *overrides* cook from CookingAppliance
    public void cook( int time )
    {
        System.out.println( "Nuking: " + time + " seconds" );
    }
}
