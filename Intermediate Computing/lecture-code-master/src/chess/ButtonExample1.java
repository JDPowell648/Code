package chess;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonExample1 extends JPanel implements ActionListener
{
    private JTextField userInput = new JTextField( 20 );

    public ButtonExample1( )
    {
        // This is calling 'add' from my JPanel
        add( new JLabel( "\u2654"));

        JButton b1 = new JButton( "Click Me" );
        b1.addActionListener( this );
        add( b1 );

        JButton b2 = new JButton( "Say Hi" );
        b2.addActionListener( this );
        add( b2 );

        add( userInput );
    }

    @Override
    public void actionPerformed(ActionEvent ae)
    {
        if( ae.getActionCommand( ).equals( "Click Me" ) )
        {
            System.out.println(userInput.getText());
        }
        else
        {
            System.out.println( "Hi" );
        }
    }
}
