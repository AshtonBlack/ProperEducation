package first;

import java.awt.*;
import java.awt.image.BufferedImage;

import javax.swing.*;

public class TheFrame extends JFrame{
	
	private JButton button1;
	private JButton button2;
	private JPanel buttonPanel;
	
	public TheFrame() {		
        
		super("StrangeEvo.v.0.01");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        buttonPanel = new JPanel(new FlowLayout());
        buttonPanel.setBorder(BorderFactory.createLineBorder(Color.black));
        buttonPanel.setPreferredSize(new Dimension(200, 700));
        
        button1 = new JButton("Let's play!");
        buttonPanel.add(button1); 
        button2 = new JButton("Quit");
        buttonPanel.add(button2);        
        
        JPanel screen = new JPanel();        
        screen.add(buttonPanel);
        
        Field playground = new Field();   
        playground.setBackground(Color.black);
        playground.setPreferredSize(new Dimension(700, 700));
        playground.setBorder(BorderFactory.createLineBorder(Color.black));
        
        screen.add(playground, BorderLayout.WEST);
        add(screen, BorderLayout.SOUTH);
   }
}
