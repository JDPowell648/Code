package gradebook;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class CourseTest
{
    @Test
    public void testNominalCourseAverage( )
    {
        Course c = new Course( );
        Student a = new Student( "Name" );
        a.addExam( 1, 1 );
        c.addStudent( a );

        // The first diagram on the board corresponds to this
        // point in time...

        a = new Student( "Name" );
        a.addQuiz( 1 , 1 );
        c.addStudent( a );

        a = new Student( "Name" );
        a.addAssignment( 1, 1 );
        c.addStudent( a );

        assertEquals( 33.33, c.getAverageGrade( ), 0.001 );
    }
}