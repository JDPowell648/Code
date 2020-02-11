package chess;

import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.JButton;
import javax.swing.JTextField;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;

public class ChessGUI extends JPanel
{
    private ArrayList<ArrayList<ChessSquare>> board = new ArrayList<>( );

    public ChessGUI( )
    {
        // If we don't change the layout manager, it will use
        // the default of FlowLayout, which will just start putting
        // stuff in a line, wrapping when the screen is full
        setLayout( new GridLayout( 8, 8 ) );

        for( int row = 0; row < 8; row++ )
        {
            board.add( new ArrayList<>( ) );

            for( int col = 0; col < 8; col++ )
            {
                ChessSquare sq = new ChessSquare( (row + col) % 2 == 0,
                        row, col );
                board.get( row ).add( sq );
                add( sq );
            }
        }
    }

    // This is an example of an inner class.  It will have access
    // to all state in the outer class, and can also not be created
    // without creating a ChessGUI first (which is what we want
    // when we have this strong association called composition)
    private class ChessSquare extends JPanel implements MouseListener
    {
        private boolean isSelected = false;
        private int row, col;

        public ChessSquare ( boolean isLight, int r, int c ) {
            if( !isLight ) {
                // Set background to dark
                setBackground(Color.DARK_GRAY );
            }

            row = r;
            col = c;
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
}
