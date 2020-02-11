package blackjack;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;
//Joshua Powell
//CS2530

//I am testing my shoe by drawing cards one at a time, and comparing it to the previous draw
//If the previous draw is equal to my current draw, then increment a count by 1
//The chance of pulling repeat cards in this deck is (1/13)(1/13)
//If my count divided by the number of loops is greater than the above listed chance,
//Then there is a chance that my shoe is not pulling randomly

//Next, I am testing to see if my shuffle() method words.
//I am looking at the shoe when it is created, and the shoe when it was reshuffled
//If both shoes are exactly the same, it would not be shuffled.

//Lastly, I am taking a more in depth look at the shuffled shoes.
//If a large amount of the indexes in the before and after arrays are the same,
//The shoe may not have been shuffled well.

public class ShoeTest {
    private Shoe testShoe;
    private int previousInt = -1;
    private int sameNumAmount = 0;
    private int sameCount = 0;
    @BeforeEach
    public void setUp (){
        testShoe = new Shoe(6);
        testShoe.shuffleShoe();
    }

    @Test
    public void testRandomness(){
        for (int i2 = 0; i2 < 100; i2++){
            for ( int i = 0; i < 6 * 52; i++) {
                int cardInt = testShoe.drawCard();
                //System.out.println("Current card: " + cardInt);
                //System.out.println("Previous card: "+ previousInt + "\n");
                if (cardInt == previousInt) {
                    sameNumAmount++;
                    //System.out.println("Repeat Draws: " + sameNumAmount + "\n");
                }
                previousInt = cardInt;
            }
            testShoe = new Shoe(6);
        }
        double realRepeated = sameNumAmount/312000d;
        double probability = (1d/13d)*(1d/13d);
        System.out.println("This test is testing the randomness in regards to drawing a card from the top of the shoe\n" +
                "In most cases, the card should not be equal to the card pulled before. The chance of drawing the same card is (1/13)^2\n");
        assertTrue( realRepeated <= probability, "The amount of duplicate draws was higher than average, check if your shoe is truly random\n"+"Number of repeat draws: " + sameNumAmount + "\nNumber of draws in total: 312000" + "\nExpected probabilty: " + probability + "\nActual: " + realRepeated);
        System.out.println("Number of repeat draws: " + sameNumAmount + "\nNumber of draws in total: 312000" + "\nExpected probabilty: " + probability + "\nActual: " + realRepeated);
    }

    @Test
    public void testShuffleSimple(){
        ArrayList<Integer> beforeShuffle = new ArrayList<>();
        beforeShuffle.addAll(testShoe.shoe);
        System.out.println("This test is making sure that a shoe before and after being shuffled is not identical\n");
        System.out.println("Shoe previous to being reshuffled:\n" + beforeShuffle);
        testShoe.shuffleShoe();
        System.out.println("Shoe after being shuffled:\n" + testShoe.shoe);
        assertTrue(beforeShuffle != testShoe.shoe,"The shoe before and after being shuffled is the same.");
    }

    @Test
    public void testShuffleComplex(){
        ArrayList<Integer> beforeShuffle = new ArrayList<>();
        beforeShuffle.addAll(testShoe.shoe);
        System.out.println("This test checks how much of a shoe before and after being shuffled is the identical.\n");
        System.out.println("Shoe previous to being reshuffled:\n" + beforeShuffle);
        testShoe.shuffleShoe();
        System.out.println("Shoe after being shuffled:\n" + testShoe.shoe);
        for (int i = 0; i < 312; i++){
            if (beforeShuffle.get(i) == testShoe.shoe.get(i)){
                sameCount++;
            }
        }
        double samePercent = sameCount/312d;
        double notGoodPercent = (1d/5d);
        System.out.println("\nNumber of same Indexes: " + sameCount + "\nOut of: 312" + "\nPercent Identical: " + samePercent*100d);
        assertTrue(samePercent < notGoodPercent, "Over 20 percent of the shuffled shoe had identical values at the same index");
    }
}
