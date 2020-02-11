package bonkers;

import javax.swing.*;
import java.awt.*;
import java.util.Random;

public class DigitPanel extends JPanel
{
    private JRadioButton higher = new JRadioButton( );
    private JRadioButton lower = new JRadioButton( );
    private boolean higherIsCorrect;

    public DigitPanel( int numToGuess )
    {
        Random generator = new Random( );
        int numToDisplay = generator.nextInt( 8 ) + 1;

        while( numToDisplay == numToGuess )
        {
            numToDisplay = generator.nextInt( 8 ) + 1;
        }

        higherIsCorrect = (numToDisplay < numToGuess);

        setLayout( new BorderLayout( ) );

        add( new JLabel( "" + numToDisplay ) );

        ButtonGroup bg = new ButtonGroup( );
        bg.add( higher );
        bg.add( lower );

        add( higher, BorderLayout.NORTH );
        add( lower, BorderLayout.SOUTH );
    }

    public boolean isCorrect( )
    {
        return (higherIsCorrect && higher.isSelected( )) ||
                (!higherIsCorrect && lower.isSelected( ) );
    }
}
