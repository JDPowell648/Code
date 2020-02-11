package quiz2;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class quiz2 extends JPanel implements ActionListener{
    private String text = "Press Count: 0";
    private JPanel textPanel = new JPanel();
    private Integer count = 0;
    private JLabel out = new JLabel(text);
    public quiz2( )
    {
        setLayout(new BorderLayout());
        add( textPanel, BorderLayout.CENTER);
        textPanel.setLayout(new BorderLayout());
        textPanel.add( out, BorderLayout.CENTER);

        JButton b1 = new JButton( "Update Display" );
        b1.addActionListener( this );
        add( b1 , BorderLayout.SOUTH);
    }

    public void actionPerformed( ActionEvent ae )
    {
            count++;
            text = "Press Count: " + count.toString();
            out.setText(text);
    }
}
