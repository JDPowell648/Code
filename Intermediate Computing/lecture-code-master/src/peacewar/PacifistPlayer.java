package peacewar;

public class PacifistPlayer extends Player
{
    public PacifistPlayer( String name )
    {
        // If I don't put a call to super( ... ) here, Java will try to insert
        // a 'super();' by itself

        // Call the superconstructor with the name as an argument
        super( name );
    }

    // This @Override annotation is something to tell the compiler that I
    // intend for this method to override something from the superclass, and
    // if it doesn't, I want the compiler to complain.
    @Override
    public boolean willMakePeace( )
    {
        return true;
    }
}
