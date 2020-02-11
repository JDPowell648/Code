package refactoredpong;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class DecoratedMovingBall extends DecoratedBall
{
    public DecoratedMovingBall( Ball b )
    {
        super( b );

        Timer t = new Timer(100, new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                DecoratedMovingBall.super.setX( DecoratedMovingBall.super.getX( ) + 10 );
                DecoratedMovingBall.super.setY( DecoratedMovingBall.super.getY( ) + 10 );
                DecoratedMovingBall.super.repaint();
            }
        });

        t.start( );
    }
}
