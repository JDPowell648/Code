package bonkers;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class BonkersPanel extends JPanel implements ActionListener
{
    private ArrayList<DigitPanel> digitPanels = new ArrayList<>( );

    public BonkersPanel( int priceToGuess )
    {
        while( priceToGuess > 0 )
        {
            digitPanels.add( new DigitPanel( priceToGuess % 10 ) );
            priceToGuess = priceToGuess / 10;
        }

        for( int i = digitPanels.size() - 1; i >= 0; i-- )
        {
            add( digitPanels.get( i ) );
        }

        JButton checkGuess = new JButton( "Check Guess" );
        checkGuess.addActionListener( this );
        add( checkGuess );
    }

    public void actionPerformed( ActionEvent ae )
    {
        boolean isCorrect = true;

        for( DigitPanel d : digitPanels )
        {
            isCorrect = isCorrect && d.isCorrect( );
        }

        if( isCorrect )
        {
            System.out.println( "You win!" );
        }
    }
}
