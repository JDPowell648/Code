package pong;

import javax.swing.*;
import java.util.Random;

public class PongDriver
{
    public static void main( String[] args )
    {
        JFrame jf = new JFrame( "Pong" );
        Random generator = new Random( );
        jf.setSize( 400, 400);
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
        jf.add( new PongPanel( 50 ) );

        jf.setVisible( true );
    }
}
