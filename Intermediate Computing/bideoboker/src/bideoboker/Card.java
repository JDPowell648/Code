package bideoboker;

public class Card {
    private String suit;
    private Integer value;
    private String actualValue;

    public void setSuit(String newSuit){
        suit = newSuit;
    }

    public void setValue(Integer newValue){
        value = newValue;
        if(value == 1){
            actualValue = "Ace";
        }
        else if(value == 11){
            actualValue = "Jack";
        }
        else if(value == 12){
            actualValue = "Queen";
        }
        else if(value == 13){
            actualValue = "King";
        }
        else{
            actualValue = value.toString();
        }
    }

    public String getValue(){
        return actualValue;
    }

    public String getSuit(){
        return suit;
    }

    public Integer getNumValue(){
        return value;
    }
}
