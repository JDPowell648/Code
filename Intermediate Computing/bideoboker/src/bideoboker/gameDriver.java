package bideoboker;

import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;

public class gameDriver {
    public static void main( String[] args )
    {

        JFrame jf = new JFrame( "bideo boker" );
        jf.setSize( 600, 150 );
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

        gamePanel game = new gamePanel();

        jf.add( game, BorderLayout.SOUTH );
        jf.setVisible( true );
    }

}
