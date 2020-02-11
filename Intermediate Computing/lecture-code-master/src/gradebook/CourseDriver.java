package gradebook;

import java.util.Iterator;

public class CourseDriver
{
    public static void main( String[] args )
    {
        Course c1 = new Course( );
        c1.addStudent( new Student("Andy" ) );
        c1.addStudent( new Student( "Billy" ) );

        Iterator<Student> iterator = c1.iterator( );
        while( iterator.hasNext( ) )
        {
            Student s = iterator.next( );
            System.out.println( s.getName( ) );
        }

        // It would be cool if I could just do this instead ...
        // thanks to the Iterable interface, I can!
        for( Student s : c1 )
        {
            System.out.println( s.getName( ) );
        }

        // This is valid (although silly in this case) Java:
        Iterable<Student> i1 = c1;

        // In Java, all objects are, by default, subclasses of type
        // Object
        Object o1 = c1;
    }
}
