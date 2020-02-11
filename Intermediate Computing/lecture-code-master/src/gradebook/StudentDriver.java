package gradebook;

public class StudentDriver
{
    public static void main( String[] args )
    {
        Student a = new Student( "Billy" );
        a.addAssignment( 1, 10 );
        a.addAssignment( 1, 10 );
        a.addQuiz( 1, 10 );
        a.addQuiz( 1, 10 );
        a.addExam( 1, 10 );
        a.addExam( 1, 10 );

        System.out.println( a.getFinalScore( ) );

        double sum = 0.0;
        for( int i = 0; i < 10; i++ )
        {
            System.out.println( sum );
            sum += 0.10;
        }
    }
}
