package refactoredpong;

import javax.swing.*;
import java.awt.*;

public class Ball extends JComponent
{
    private int ballX, ballY;

    private int ballDiameter;
    private Color ballColor;

    public Ball( )
    {
        this( 30, Color.BLACK );
    }

    public Ball( int size )
    {
        this( size, Color.BLACK );
    }

    public Ball( int size, Color color )
    {
        this( size, color, 0, 0 );
    }

    public Ball( int size, Color color, int x, int y )
    {
        ballDiameter = size;
        ballColor = color;

        setBounds( 0, 0, ballDiameter, ballDiameter );

        ballX = x;
        ballY = y;

        setLocation( ballX, ballY );
    }

    @Override
    public void paintComponent( Graphics g )
    {
        super.paintComponent( g );

        setLocation( ballX, ballY );

        g.fillOval( 0, 0, ballDiameter, ballDiameter );
    }

    public void setX( int newX )
    {
        ballX = newX;
    }

    public int getX( )
    {
        return ballX;
    }

    public void setY( int newY )
    {
        ballY = newY;
    }

    public int getY( )
    {
        return ballY;
    }

    public void setBallDiameter( int d )
    {
        ballDiameter = d;
    }

    public int getBallDiameter( )
    {
        return ballDiameter;
    }
}
