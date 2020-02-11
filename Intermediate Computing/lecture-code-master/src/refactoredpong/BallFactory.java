package refactoredpong;

// An example of the "factory" design pattern
public interface BallFactory
{
    Ball createBall( int x, int y );
}