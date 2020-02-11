package bideoboker;

import java.util.ArrayList;

class JacksOrBetter implements scorer
{
    int scoreHand(ArrayList<Card> hand){
        hand.sort(sortCards);
        if (RoyalFlush(hand)){
            return 800;
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

    boolean RoyalFlush(ArrayList<Card> hand){
        return StraightFlush(hand) && hand.get(4).getNumValue() == 13;
    }

    boolean StraightFlush(ArrayList<Card> hand){
        return Flush(hand) && Straight(hand);
    }

    boolean FourOfAKind(ArrayList<Card> hand){
        if (hand.get(0).getNumValue() == (hand.get(1).getNumValue()) && hand.get(0).getNumValue() == (hand.get(2).getNumValue()) &&
                hand.get(0).getNumValue() == (hand.get(3).getNumValue())) {
            return true;
        }
        else return hand.get(1).getNumValue() == (hand.get(2).getNumValue()) && hand.get(2).getNumValue() == (hand.get(3).getNumValue()) &&
                hand.get(3).getNumValue() == (hand.get(4).getNumValue());
    }

    boolean FullHouse(ArrayList<Card> hand){
        if((hand.get(0).getNumValue() == hand.get(1).getNumValue()) &&
                (hand.get(2).getNumValue() == hand.get(3).getNumValue() && hand.get(2).getNumValue() == hand.get(4).getNumValue())){
            return true;
        }else return (hand.get(0).getNumValue() == hand.get(1).getNumValue() && hand.get(1).getNumValue() == hand.get(2).getNumValue()) &&
                (hand.get(3).getNumValue() == hand.get(4).getNumValue());
    }

    boolean Flush(ArrayList<Card> hand){
        return hand.get(0).getSuit() == (hand.get(1).getSuit()) && hand.get(0).getSuit() == (hand.get(2).getSuit()) &&
                hand.get(0).getSuit() == (hand.get(3).getSuit()) && hand.get(0).getSuit() == (hand.get(4).getSuit());
    }

    boolean Straight(ArrayList<Card> hand) {
        return hand.get(0).getNumValue() + 1 == (hand.get(1).getNumValue()) && hand.get(0).getNumValue() + 2 == (hand.get(2).getNumValue()) &&
                hand.get(0).getNumValue() + 3 == (hand.get(3).getNumValue()) && hand.get(0).getNumValue() + 4 == (hand.get(4).getNumValue());
    }

    boolean ThreeOfAKind(ArrayList<Card> hand){
        if(hand.get(0).getNumValue() == hand.get(1).getNumValue() && hand.get(0).getNumValue() == hand.get(2).getNumValue()){
            return true;
        }else if(hand.get(1).getNumValue() == hand.get(2).getNumValue() && hand.get(2).getNumValue() == hand.get(3).getNumValue()){
            return true;
        }else return hand.get(2).getNumValue() == hand.get(3).getNumValue() && hand.get(3).getNumValue() == hand.get(4).getNumValue();
    }

    boolean TwoPair(ArrayList<Card> hand){
        if (hand.get(0).getNumValue() == hand.get(1).getNumValue() && hand.get(2).getNumValue() == hand.get(3).getNumValue()){
            return true;
        }else return hand.get(1).getNumValue() == hand.get(2).getNumValue() && hand.get(3).getNumValue() == hand.get(4).getNumValue();
    }

    boolean JackOrBetter(ArrayList<Card> hand){
        if(hand.get(0).getNumValue() == hand.get(1).getNumValue() && hand.get(0).getNumValue() >=11){
            return true;
        }else if(hand.get(1).getNumValue() == hand.get(2).getNumValue() && hand.get(1).getNumValue() >=11) {
            return true;
        }else if(hand.get(2).getNumValue() == hand.get(3).getNumValue() && hand.get(2).getNumValue() >=11){
            return true;
        }else return hand.get(3).getNumValue() == hand.get(4).getNumValue() && hand.get(3).getNumValue() >= 11;
    }
}
