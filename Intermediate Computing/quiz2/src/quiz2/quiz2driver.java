package quiz2;

import javax.swing.*;
import java.awt.*;

public class quiz2driver {
    public static void main( String args[] )
    {
        JFrame jf = new JFrame( "Hello!" );

        jf.setSize( 300, 300 );
        jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

        jf.add( new quiz2( ), BorderLayout.CENTER );

        jf.setVisible( true );
    }
}
