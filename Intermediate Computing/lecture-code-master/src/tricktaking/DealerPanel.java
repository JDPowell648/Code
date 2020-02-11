package tricktaking;

import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.JButton;
import java.awt.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

public class DealerPanel extends JPanel implements ActionListener
{
    private Deck cardDeck = new Deck( );
    private ArrayList<RedealCardPanel> players = new ArrayList<>( );
    private HandScorer scorer;
    private JLabel scoreLabel = new JLabel( "Score: 0" );
    private int totalScore = 0;

    public DealerPanel(int numHands, HandScorer sc )
    {
        setLayout( new BorderLayout( ) );

        JPanel cards = new JPanel( );
        for( int i = 0; i < numHands; i++ )
        {
            RedealCardPanel cp = new RedealCardPanel( );
            players.add( cp );
            cards.add( cp );
        }

        add( cards );

        JButton score = new JButton( "Score" );
        score.addActionListener( this );
        add( score, BorderLayout.SOUTH );

        add( scoreLabel, BorderLayout.NORTH );

        scorer = sc;
    }

    @Override
    public void actionPerformed(ActionEvent e)
    {
        ArrayList<Card> cards = new ArrayList<>( );
        for( RedealCardPanel rcp : players )
        {
            cards.add( rcp.getCard( ) );
        }

        totalScore = totalScore + scorer.scoreHand( cards );

        scoreLabel.setText( "Score: " + totalScore );
    }

    private class RedealCardPanel extends JPanel
    {
        private Card card = cardDeck.drawCard( );
        private JLabel cardLabel = new JLabel(card.toString( ) );

        public RedealCardPanel( )
        {
            cardLabel.setFont( new Font( "TimesRoman", Font.PLAIN, 100 ) );
            add( cardLabel );
            addMouseListener( new CardPanelListener( ) );
        }

        public Card getCard( )
        {
            return card;
        }

        private class CardPanelListener extends MouseAdapter
        {
            @Override
            public void mouseClicked( MouseEvent e )
            {
                card = cardDeck.drawCard( );
                cardLabel.setText( card.toString( ) );
            }
        }
    }
}
