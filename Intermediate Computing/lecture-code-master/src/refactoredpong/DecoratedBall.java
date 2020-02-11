package refactoredpong;

import javax.swing.*;
import java.awt.*;

public abstract class DecoratedBall extends Ball
{
    private Ball ball;

    public DecoratedBall( Ball b )
    {
        ball = b;
    }

    @Override
    public void paintComponent( Graphics g )
    {
        super.paintComponent( g );
        ball.paintComponent( g );

        if( getRootPane() != null )
        {
            getRootPane().repaint();
        }

    }

    public void setX( int newX )
    {
        ball.setX( newX );
    }

    public int getX( )
    {
        return ball.getX( );
    }

    public void setY( int newY )
    {
        ball.setY( newY );
    }

    public int getY( )
    {
        return ball.getY( );
    }

    public void setBallDiameter( int d )
    {
        ball.setBallDiameter( d );
    }

    public int getBallDiameter( )
    {
        return ball.getBallDiameter();
    }
}
