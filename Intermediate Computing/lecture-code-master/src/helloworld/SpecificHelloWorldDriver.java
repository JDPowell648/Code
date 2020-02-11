package helloworld;

public class SpecificHelloWorldDriver
{
    public static void main( String[] args )
    {
        SpecificHelloWorld andysFriend = new SpecificHelloWorld( "Andy" );
        SpecificHelloWorld bobsFriend = new SpecificHelloWorld( "Bob");

        andysFriend.sayHello( );
        //bobsFriend.sayHello( );

        System.out.println( "Andy was told hello "
                + andysFriend.getHelloCount() + " times." );

        System.out.println( "Bob was told hello "
                + bobsFriend.getHelloCount() + " times." );
    }
}
