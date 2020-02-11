package refactoredpong;

import javax.swing.*;
import java.awt.*;
import java.util.Random;

public class PongDriver
{
    public static void main( String[] args )
    {
        // You can ignore this extra stuff if you want, or you can just treat
        // it like something you cut and paste like the stuff we use when
        // making a JFrame.  Or ...
        SwingUtilities.invokeLater(new Runnable( )
        {
            public void run( )
            {
                JFrame jf = new JFrame( "Pong" );
                Random generator = new Random( );
                jf.setSize( 400, 400 );
                jf.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

                // As a note, I wouldn't normally make these each their own variable,
                // I am doing so simply to demonstrate the concept better (I hope)
                Ball b = new Ball( );
                Ball cb = new DecoratedColoredBall( b );
                Ball mcb = new DecoratedMovingBall( cb );

                //jf.add( new PongPanel( mcb )  );

                jf.add( new ClickToCreatePongPanel( mcb, new BallFactory( )
                {
                    public Ball createBall( int x, int y )
                    {
                        return new DecoratedMovingBall(new Ball());
                    }
                }));

                jf.setVisible( true );
            }
        });
    }
}
