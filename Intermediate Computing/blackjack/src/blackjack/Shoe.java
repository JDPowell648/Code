package blackjack;

import java.util.ArrayList;
import java.util.Collections;

public class Shoe
{
    public ArrayList<Integer> shoe = new ArrayList<>();
    private int numDecks;
    public Shoe( int numDecksInput ) {
        //Creates the shoe
        numDecks = numDecksInput;
        fillShoe();
    }
    private void fillShoe(){
        //fills the shoe with numDecks amount of decks, each deck containing 54 cards. This deck is not shuffled yet.
        for (int i = 0; i < numDecks; i++) {
            Deck d = new Deck();
            shoe.addAll(d.getCards());
        }
    }
    public int drawCard() {
        //Draws the card at the top of the show, removes it, and returns it's value
        int cardInt = shoe.get(0);
        shoe.remove(0);
        return cardInt;
    }
    public void shuffleShoe(){
        //Shuffles the entire shoe
        Collections.shuffle(shoe);
    }
    public int getSize(){
        return shoe.size();
    }
}