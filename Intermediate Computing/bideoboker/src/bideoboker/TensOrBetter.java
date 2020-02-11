package bideoboker;

import java.util.ArrayList;

class TensOrBetter extends JacksOrBetter implements scorer
{
    @Override
    boolean JackOrBetter(ArrayList<Card> hand) {
        if(hand.get(0).getNumValue() == hand.get(1).getNumValue() && hand.get(0).getNumValue() >=10){
            return true;
        }else if(hand.get(1).getNumValue() == hand.get(2).getNumValue() && hand.get(1).getNumValue() >=10) {
            return true;
        }else if(hand.get(2).getNumValue() == hand.get(3).getNumValue() && hand.get(2).getNumValue() >=10){
            return true;
        }else return hand.get(3).getNumValue() == hand.get(4).getNumValue() && hand.get(3).getNumValue() >= 10;
    }
    @Override
    int scoreHand(ArrayList<Card> hand){
        hand.sort(sortCards);
        if (RoyalFlush(hand)){
            return 250;
        }else if(StraightFlush(hand)){
            return 50;
        }else if(FourOfAKind(hand)){
            return 25;
        }else if(FullHouse(hand)){
            return 9;
        }else if(Flush(hand)){
            return 6;
        }else if(Straight(hand)){
            return 4;
        }else if(ThreeOfAKind(hand)){
            return 3;
        }else if(TwoPair(hand)) {
            return 2;
        }else if(JackOrBetter(hand)){
            return 1;
        }else{
            return 0;
        }
    }
}
