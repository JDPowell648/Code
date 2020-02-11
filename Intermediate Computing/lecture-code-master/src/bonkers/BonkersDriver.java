package bonkers;

import javax.swing.*;

public class BonkersDriver
{
    public static void main( String[] args )
    {
        JFrame jf = new JFrame( "Bonkers" );
        jf.setSize( 600, 600 );
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

        jf.add( new BonkersPanel( 55555555 ) );
        jf.setVisible( true );
    }
}
