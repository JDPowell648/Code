package refactoredpong;

import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class ClickToCreatePongPanel extends PongPanel
{
    public ClickToCreatePongPanel( Ball b, BallFactory factory )
    {
        super( b );

        addMouseListener(new MouseAdapter( )
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                add( factory.createBall( e.getX( ), e.getY( ) ) );
            }
        });
    }
}
