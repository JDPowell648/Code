package refactoredpong;

import java.awt.*;

public class DecoratedColoredBall extends DecoratedBall
{
    public DecoratedColoredBall( Ball b )
    {
        super( b );
    }

    public void paintComponent( Graphics g )
    {
        g.setColor( Color.BLUE );
        super.paintComponent(g);
    }
}
