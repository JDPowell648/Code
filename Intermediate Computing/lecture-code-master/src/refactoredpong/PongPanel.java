package refactoredpong;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class PongPanel extends JPanel
{
    public PongPanel( Ball b )
    {
        setLayout( null );
        add( b );
    }
}
