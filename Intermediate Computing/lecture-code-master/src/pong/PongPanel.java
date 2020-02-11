package pong;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyListener;
import java.awt.event.KeyEvent;

public class PongPanel extends JPanel implements ActionListener, KeyListener
{
    private final int ballSize;
    private final int paddleHeight;

    private int ballX, ballY;
    private int deltaX = 10, deltaY = 10;

    private int paddleX, paddleY;

    private Timer frameTimer;

    public PongPanel( int size )
    {
        ballSize = size;
        ballX = 0;
        ballY = 0;

        paddleHeight = 40;

        frameTimer = new Timer( 100, this );
        frameTimer.start( );

        /* A "nice to know": anonymous classes
        Timer t = new Timer( 100, new ActionListener( )
        {
            public void actionPerformed( ActionEvent ae )
            {
                ballX += deltaX;
                ballY += deltaY;
            }
        });
        */

        addKeyListener( this );
        setFocusable( true );
    }

    @Override
    public void paintComponent( Graphics g )
    {
        super.paintComponent( g );

        g.setColor( Color.BLACK );

        // The paddleX and paddleY are the position of the paddle
        // **relative to the bottom right corner of the screen**.  Apparently
        // this is how Pong is supposed to be played.
        g.fillRect( getWidth( ) - (10 + paddleX), getHeight( ) - (paddleY + paddleHeight),
                10, paddleHeight  );

        g.setColor( Color.RED );
        g.fillOval( ballX, ballY, ballSize, ballSize );
    }

    public void actionPerformed( ActionEvent ae )
    {
        if( ballX + deltaX > getWidth( ) - ballSize )
        {
            // If the "center" of the ball is somewhere on the paddle,
            // then it bounces; otherwise the game is over
            if( (ballY + ballSize / 2 > paddleY) &&
                (ballY + ballSize / 2 < (paddleY + paddleHeight)) )
            {
                deltaX = -deltaX;
            }
            else
            {
                frameTimer.stop( );
                JOptionPane.showMessageDialog( this, "You lose!" );
                deltaX = -deltaX;
                frameTimer.start( );
            }
        }
        else if( ballX + deltaX < 0 )
        {
            deltaX = -deltaX;
        }

        if( ballY + deltaY > getHeight() - ballSize )
        {
            deltaY = -deltaY;
        }
        else if( ballY + deltaY < 0 )
        {
            deltaY = -deltaY;
        }

        ballX = ballX + deltaX;
        ballY = ballY + deltaY;

        // If the ball hits the corner directly, end the game.  Something
        // silly we added
        if( (ballX == 0 || ballX == getWidth() - ballSize) &&
            (ballY == 0 || ballY == getHeight() - ballSize) )
        {
            frameTimer.stop( );
            System.out.println( "Victory!!" );
        }

        repaint( );
    }

    @Override
    public void keyPressed( KeyEvent ke )
    {

    }

    @Override
    public void keyReleased( KeyEvent ke )
    {

    }

    @Override
    public void keyTyped( KeyEvent ke )
    {
        // We'll use 'w' and 's' for the up and down movement.
        // Again, the coordinates are relative to the bottom right corner
        // of the panel.
        if( ke.getKeyChar( ) == 'w' )
        {
            paddleY += 10;
        }
        if( ke.getKeyChar( ) == 's' )
        {
            paddleY -= 10;
        }
    }
}
