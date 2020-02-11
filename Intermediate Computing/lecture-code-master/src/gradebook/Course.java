package gradebook;

import java.util.ArrayList;
import java.util.Iterator;

// "implements" aka I promise the Java compiler that I have
// the methods that are required/defined in the interface "Iterable"
public class Course implements Iterable<Student>
{
    // A collection of Student objects
    private ArrayList<Student> roster = new ArrayList<>( );

    public void addStudent( Student s )
    {
        roster.add( s );

        // This is stupid, yes, but I'm trying to make a point.
        // The variable 'i' is created when I get to this line,
        // and once my method is done executing, it is thrown
        // away.
        int i = 0;
        i = 100;
    }

    // Edit a student; Look up the score of a student; ...

    public double getAverageGrade( )
    {
        double total = 0.0;

        // A 'for-each' loop in Java: the loop body will execute
        // once for every element in 'roster', with 's' taking
        // the value of each element as the loop executes
        for( Student s : roster )
        {
            total = total + s.getFinalScore( );
        }

        return total / roster.size( );
    }

    // A design pattern is a generic solution to a frequently-encountered
    // problem: e.g. an Iterator

    // Imagine I want a method to return all the students of the
    // class one at a time.  This would be bad because ...
    public Student getStudent( int i )
    {
        return roster.get( i );
    }
    // ... it 'breaks' encapsulation -- the users need to know details
    // of my implementation to use my class.

    // Problem: I want to access all elements of a collection without
    //          having to know (or reveal) the underlying implementation
    // Solution: Iterator
    public Iterator<Student> iterator( )
    {
        return roster.iterator( );
    }
}