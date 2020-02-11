package bideoboker;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Deck
{
    private ArrayList<Card> cards = new ArrayList<>();
    private ArrayList<String> suits = new ArrayList<>();
    public Deck(){
        suits.add("Spades");
        suits.add("Clubs");
        suits.add("Diamonds");
        suits.add("Hearts");
        createDeck();
        shuffleDeck();
    }
    public void createDeck()
    {
        for (int cardNum = 1; cardNum <= 13; cardNum++)
        {
            for (int i = 0; i < 4; i++)
            {
                String suit = suits.get(i);
                Card newCard = new Card();
                newCard.setSuit(suit);
                newCard.setValue(cardNum);
                cards.add(newCard);
            }
        }
    }
    public void cardString(){
        //Returns the deck as a string
        for (int i = 0; i < 52; i++){
            System.out.println(cards.get(i).getValue());
        }
    }
    public void shuffleDeck(){
        //Shuffles the deck independently from the shoe
        Collections.shuffle(cards);
    }
    public Card drawCard(){
        //Draws the top card of the deck, removes it, and returns it's value
        Card topCard = cards.get(0);
        cards.remove(0);
        return topCard;
    }
    public ArrayList<Card> getCards()
    {
        //Returns the ArrayList Cards, which represents a deck of 51 cards.
        return cards;
    }
}
