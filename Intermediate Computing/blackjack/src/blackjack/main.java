package blackjack;

public class main {
    public static void main( String[] args ) {
        Deck myDeck = new Deck();
        System.out.println(myDeck.cardString());

        myDeck.shuffleDeck();
        System.out.println(myDeck.cardString());

        System.out.println(myDeck.drawCard());
        System.out.println(myDeck.cardString());

        Shoe myShoe = new Shoe(6);
        System.out.println(myShoe.shoe);

        System.out.println(myShoe.drawCard());
        System.out.println(myShoe.shoe);

        myShoe.shuffleShoe();
        System.out.println(myShoe.shoe);

        System.out.println(myShoe.drawCard());
    }
}

