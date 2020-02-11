package peacewar;

import java.util.Random;

public class UnpredictablePlayer extends Player
{
    private Random generator = new Random( );

    public UnpredictablePlayer( String name )
    {
        super( name );
    }

    @Override
    public boolean willMakePeace( )
    {
        return generator.nextBoolean( );
    }



    public static void main( String[] args )
    {
        Random r = new Random( );
        for( int i = 0; i < 10; i++ )
        {
            System.out.println( r.nextInt( ) );
        }
    }
}
