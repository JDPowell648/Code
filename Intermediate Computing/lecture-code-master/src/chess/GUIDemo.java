package chess;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import java.awt.BorderLayout;

public class GUIDemo
{
    public static void main( String args[] )
    {
        JFrame jf = new JFrame( "Hello!" );

        jf.setSize( 600, 600 );
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

        /*
        JPanel jp = new JPanel( );
        jp.add( new JLabel( "This is a label." ) );

        jf.add( jp );
        */

        // Our previous example working with JButtons
        // jf.add( new ButtomExample1( ) );
        jf.add( new ChessGUI( ) );

        jf.setVisible( true );
    }
}
