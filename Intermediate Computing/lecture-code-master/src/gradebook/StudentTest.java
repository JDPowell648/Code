package gradebook;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class StudentTest
{
    private Student a;

    @BeforeEach
    public void setUp( )
    {
        // any operations done here will be executed before each test case
        a = new Student( "Billy" );
    }

    @Test
    public void testAStudent( )
    {
        a.addAssignment( 10, 10 );
        a.addQuiz( 10, 10 );
        a.addExam( 10, 10 );

        // The order is: (expected value, actual value)
        assertEquals( 100.0, a.getFinalScore( ), 0.0001 );
    }

    @Test
    public void testBStudent( )
    {
        a.addQuiz( 85, 100 );
        a.addAssignment( 85, 100 );
        a.addExam( 85, 100 );

        assertEquals( 85.0, a.getFinalScore( ), 0.0001 );
    }

    @Test
    public void testBusyStudent( )
    {
        a.addQuiz( 10, 10 );
        a.addExam( 10, 10 );

        assertEquals( 60.0, a.getFinalScore( ), 0.001 );
    }

}