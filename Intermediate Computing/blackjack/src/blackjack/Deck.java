package blackjack;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Deck
{
    private ArrayList<Integer> cards = new ArrayList<>();
    public Deck(){
        createDeck();
        shuffleDeck();
    }
    public void createDeck()
    {
        //Making a deck of cards with an integer 1-13 repeated four times
        //Suite is not accounted for, because it does not change the value of the card
        //1 represents Ace, 2-10 are their respective cards, 11 is Jack, 12 is Queen, 13 in King
        //A card class could be implemented later to read the value it was assigned to know which card it is
        //   and what value it can be played as
        for (int cardNum = 1; cardNum <= 13; cardNum++)
        {
            for (int i = 0; i < 4; i++)
            {
                cards.add(cardNum);
            }
        }
    }
    public String cardString(){
        //Returns the deck as a string
        return cards.toString();
    }
    public void shuffleDeck(){
        //Shuffles the deck independently from the shoe
        Collections.shuffle(cards);
    }
    public int drawCard(){
        //Draws the top card of the deck, removes it, and returns it's value
        int cardInt = cards.get(0);
        cards.remove(0);
        return cardInt;
    }
    public ArrayList<Integer> getCards()
    {
        //Returns the ArrayList Cards, which represents a deck of 54 cards.
        return cards;
    }
}
