package tricktaking;

import javax.swing.*;

public class DealerDriver
{
    public static void main( String[] args )
    {
        JFrame jf = new JFrame( "Trick-Taking Game" );
        jf.setSize( 500, 500 );
        jf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE );

        //jf.add( new DealerPanel( 4, new SpadePointScorer( ) ) );
        jf.add( new DealerPanel( 4, new FaceCardPointScorer( ) ) );

        jf.setVisible( true );
    }
}
