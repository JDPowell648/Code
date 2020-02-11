package helloworld;

import java.io.PrintStream;

public class HelloWorldDriver
{
    public static void main( String[] args )
    {
        /* I wouldn't normally do this, but I could, and perhaps
           it helps clarify the fact that out is an object.

           PrintStream output = System.out;
           output.println("Hello, world!");
         */

        // Here's how we *would* do it:
        System.out.println( "Hello, world!" );



        // How many HelloWorld objects exist at *this* particular
        // point in time?  None!

        // What we need to do is first __instantiate__ the
        // HelloWorld object (that is, create an instance)
        HelloWorld speaker;

        // This will not work, because I have not associated speaker
        // with an actual object.
        //speaker.sayHello( "Andrew" );

        // How many HelloWorld objects exist at *this* point
        // in time?  None (yes, still)!
        speaker = new HelloWorld( );

        // *Now* there is one HelloWorld object!
        // Normally, you would put this on one line:
        // HelloWorld speaker = new HelloWorld( );

        // I am sending a 'sayHello' message to the object which
        // I know as 'speaker'.
        speaker.sayHello( "Andy" );
    }
}