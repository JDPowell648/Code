package bideoboker;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class gamePanel extends JPanel implements ActionListener {
    private ArrayList<cardPanel> cardPanels = new ArrayList<>( );
    private JPanel centerPanel = new JPanel();
    private Deck playingDeck = new Deck();
    private boolean shouldScore = false;
    private JButton drawButton = new JButton( "Draw" );
    private JPanel scorePanel = new JPanel();
    private JLabel scoreLabel = new JLabel("Score: 0");
    private int score = 0;
    private JacksOrBetter scorer = new TensOrBetter();

    public gamePanel()
    {
        setLayout(new BorderLayout());
        drawButton.addActionListener( this );
        add(drawButton, BorderLayout.SOUTH);

        add(scorePanel, BorderLayout.NORTH);
        scorePanel.add(scoreLabel);

        for (int i = 0; i < 5; i++)
        {
            cardPanels.add( new cardPanel( playingDeck.drawCard() ));

        }

        for( int i = cardPanels.size() - 1; i >= 0; i-- )
        {
            centerPanel.add( cardPanels.get( i ) );
        }

        add(centerPanel, BorderLayout.CENTER);
    }
    public void actionPerformed( ActionEvent ae )
    {
        System.out.println("Pressed");
        for( int i = 0; i < 5; i++ ) {
            if (cardPanels.get(i).isHeld() && !shouldScore){
                cardPanels.get(i).setValue(playingDeck.drawCard());
                cardPanels.get(i).uncheck();
                score -= 1;
                scoreLabel.setText("Score: " + score);
            }
        }
        if (shouldScore){
            ArrayList<Card> cardArray = new ArrayList<>();
            for(int i = 0; i < 5; i++){
                cardArray.add(cardPanels.get(i).getCard());
            }
            score += scorer.scoreHand(cardArray);
            scoreLabel.setText("Score: " + score);
            resetGame();
            shouldScore = !shouldScore;
        }else{
            drawButton.setText("Score");
            shouldScore = !shouldScore;
        }

    }

    public ArrayList<cardPanel> getCardList(){
        return cardPanels;
    }

    private void resetGame(){
        drawButton.setText("Draw");
        playingDeck = new Deck();

        for( int i = cardPanels.size() - 1; i >= 0; i-- )
        {
            cardPanels.get( i ).setValue(playingDeck.drawCard());
            cardPanels.get(i).uncheck();
        }
    }

}

