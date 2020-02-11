package bideoboker;

import java.util.ArrayList;
import java.util.Comparator;

public interface scorer {
    Comparator<Card> sortCards = new Comparator<Card>() {
        @Override
        public int compare(Card a, Card b) {
            return a.getNumValue() - b.getNumValue();
        }
    };

}
