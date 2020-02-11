package gradebook;

import java.util.HashMap;

public class GradeLookupDriver
{
    public static void main( String[] args )
    {
        HashMap<String, Student> grades = new HashMap<>( );

        String name = "Andy";

        grades.put( name, new Student( "Andy" ) );
        grades.put( "Billy", new Student( "Billy" ) );

        Student s1 = grades.get( "Andy" );
        Student s2 = grades.get( "Thomas" );

        System.out.println( s1 );
        System.out.println( s2 );
    }


}
