package helloworld;

public class SpecificHelloWorld
{
    // Our instance variables will go here.
    // The declaration pattern will be:
    //  <visibility> <type> <name>
    // --- <visibility> WILL ALWAYS BE PRIVATE
    private String userName;
    private int helloCount;

    // We'll make a constructor that will take in the name to
    // always say hello to
    public SpecificHelloWorld( String name )
    {
        userName = name;
    }

    public void sayHello( )
    {
        System.out.println( "Good day, " + userName );
        helloCount = helloCount + 1;
        //helloCount++;
        //helloCount += 1;
    }

    public int getHelloCount( )
    {
        return helloCount;
    }
}
