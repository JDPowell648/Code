package kitchen;

public class CookingAppliance
{
    private String brand = "n/a";

    public void cook( int time )
    {
        System.out.println( "Cook: " + time + " seconds");
    }

    // accessor for brand
    public String getBrand( )
    {
        return brand;
    }
}
