package bideoboker;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.Arrays;

public class cardPanel extends JPanel {
    private JCheckBox hold = new JCheckBox( );
    private String cardValue = "";
    private JLabel valLable = new JLabel();
    private Card myCard = new Card();

    public cardPanel( Card value )
    {
        setValue(value);

        setLayout( new BorderLayout( ) );

        add( valLable, BorderLayout.NORTH );

        add(new JLabel("Discard"), BorderLayout.SOUTH);

        add( hold );
    }

    public void setValue(Card newVal){
        myCard = newVal;
        valLable.setText(newVal.getValue() + " of " + newVal.getSuit());
    }

    public boolean isHeld(){
        return hold.isSelected();
    }

    public String getValue(){
        return myCard.getValue();
    }

    public String getSuit(){
        return myCard.getSuit();
    }

    public void uncheck(){
        hold.setSelected(false);
    }

    public Card getCard(){
        return myCard;
    }
}
