package uno;

public class ActionCard extends UnoCard
{
    public enum ActionType {SKIP, REVERSE, DRAW};

    private ActionType type;

    public ActionCard(ColorType c, ActionType t)
    {
        super(c);
        type = t;
    }

    public ActionType getType( )
    {
        return type;
    }
}
