package chess;

import javax.swing.JPanel;
import java.awt.Color;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class OuterChessSquare extends JPanel implements MouseListener
{
    private boolean isSelected = false;

    public OuterChessSquare ( boolean isLight ) {
        if( !isLight ) {
            // Set background to dark
            setBackground(Color.DARK_GRAY );
        }

        addMouseListener( this );
    }

    @Override
    public void mouseClicked(MouseEvent e)
    {
        if( isSelected )
        {
            setBackground( getBackground( ).brighter( ) );
        }
        else
        {
            setBackground( getBackground( ).darker( ) );
        }

        isSelected = !isSelected;
    }

    @Override
    public void mousePressed(MouseEvent e)
    {

    }

    @Override
    public void mouseReleased(MouseEvent e)
    {

    }

    @Override
    public void mouseEntered(MouseEvent e)
    {

    }

    @Override
    public void mouseExited(MouseEvent e)
    {

    }
}
