package streams;

import java.io.*;
import java.util.Scanner;

public class StreamDemo
{
    public static void main( String[] args ) throws Exception
    {
        // Reader/Writer is for character-based IO
        Reader r = new FileReader( "a.txt" );

        // InputStream/OutputStream is for byte-based IO
        InputStream in = new FileInputStream( "a.txt" );

        in = System.in;

        /*
        OutputStream output = System.out;
        InputStream in = System.in;

        // I had to do this 'getBytes()' business because output is a *stream*
        // which deals in bytes, not a character stream (like Writer)
        output.write( "Hello!\n".getBytes( ) );

        Scanner s1 = new Scanner( System.in );
        System.out.println( s1.next( ) );
        System.out.println( s1.next( ) );

        Scanner s2 = new Scanner( new FileInputStream( "a.txt" ) );
        System.out.println( s2.next( ) );
        */

        // What if I want to save the state of my Yahtzee game for later?
        Yahtzee y = new Yahtzee( 5 );

        /*
        OutputStream fOut = new FileOutputStream( "y.yhtzsv" );

        fOut.write( y.getNumPlayers( ) );

        fOut.flush( );
        fOut.close( );

        InputStream fIn = new FileInputStream( "y.yhtzsv" );
        y = new Yahtzee( fIn.read( ) );
        System.out.println( y.getNumPlayers( ) );
        */

        y.setScoreFor( 1, 100 );
        System.out.println( y.getScoreFor( 1 ) );

        ObjectOutputStream os = new ObjectOutputStream(
                new FileOutputStream( "y.yhtzsv" ) );
        os.writeObject( y );
        os.close( );

        ObjectInputStream is = new ObjectInputStream(
                new FileInputStream( "y.yhtzsv" ) );
        y = (Yahtzee) is.readObject( );
        is.close( );

        System.out.println( y.getScoreFor( 1 ) );
    }
}
