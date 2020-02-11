package chess;

import javax.swing.JFrame;

public class ChessGUIDriver
{
    public static void main( String args[] )
    {
        JFrame jf = new JFrame( "Hello!" );

        jf.setSize( 600, 600 );
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

        jf.add( new ChessGUI( ) );

        jf.setVisible( true );
    }
}
