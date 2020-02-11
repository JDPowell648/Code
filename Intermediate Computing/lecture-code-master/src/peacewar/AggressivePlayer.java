package peacewar;

public class AggressivePlayer extends Player
{
    public AggressivePlayer( String name )
    {
        super( name );
    }

    @Override
    public boolean willMakePeace( )
    {
        return false;
    }
}
