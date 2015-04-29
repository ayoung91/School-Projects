import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.imageio.*;
import java.io.*;
import java.util.ArrayList;
import java.awt.image.*;

/**
 * Team 08
 * Seth Larcomb, Steven Lewis, Max Cartright, Adam Young
 */

public class blackjack2 extends JApplet {
    JButton dealButton = new JButton("DEAL");       //Deal button        Starts game
    JButton player1HitButton = new JButton("H");    //Hit button		 player 1
    JButton player1StayButton = new JButton("S");   //Stay button		 player 1
    JButton player1DoubleButton = new JButton("D"); //Double down button player 1
    JButton player2HitButton = new JButton("H");    //Hit button		 player 2
    JButton player2StayButton = new JButton("S");   //Stay button 		 player 2
    JButton player2DoubleButton = new JButton("D"); //Dobule down button player 2

    JTextField dealers = new JTextField(6);       //Displays dealer total
    JTextField player1s = new JTextField(6);      //Player 1's total hand value display
    JTextField player2s = new JTextField(6);      //Player2's total hand value display
    ButtonHandler listener = new ButtonHandler(); //Listens for code after click

    boolean gameover = false;					  //New Game
    boolean player1Done = false;				  //When player 1 doesnt press stay
    boolean player2Done = false;				  //When player 2 doesnt press stay
    boolean dealerDone = false;                   //When dealer doesnt stay
    boolean dealt = false;
	boolean p1Double = false;
    boolean p2Double = false;

    String[] dealercards  = new String[10];
    String[] player1cards = new String[10];
    String[] player2cards = new String[10];
    String p1Status = "";
    String p2Status = "";		//Used to display results of hand whether player won or lost

	Integer dealertotal  = 0;
	Integer player1total = 0;
	Integer player2total = 0;

	/*new code*/
	Integer p1Bet = 100;
    Integer p2Bet = 100;


	Deck deck1 = new Deck(false);

	BlackjackHand dealerhand = new BlackjackHand();
	BlackjackHand player1hand = new BlackjackHand();
	BlackjackHand player2hand = new BlackjackHand();

   private blackjackTable displayPanel;  		   // The panel where the message is displayed.
   private class blackjackTable extends JPanel {   // Defines the display panel.
      public void paintComponent(Graphics g) {

         setBackground(Color.GREEN);
         super.paintComponent(g);
      }
   }

   private class ButtonHandler implements ActionListener {  // The event listener.

      public void actionPerformed(ActionEvent e) {

	//if source is dealer button, call dealPressed function
		if (e.getSource() == dealButton){
			dealPressed();
	}
	//if source is player1 hit, add card to player 1's hand
        if(e.getSource() == player1HitButton) {
            player1hand.addCard(deck1.dealCard());
            player1DoubleButton.setEnabled(false);
        }
    //if source is player2 hit, add card to player 1's hand
    	if(e.getSource() == player2HitButton) {
            player2hand.addCard(deck1.dealCard());
            player2DoubleButton.setEnabled(false);
        }
    //if source is player 2 double
    	if(e.getSource() == player2DoubleButton){
			player2hand.addCard(deck1.dealCard());
			player2Done = true;
			p2Double = true;
		}
	//if source is player 1 double
		if(e.getSource() == player1DoubleButton){
			player1hand.addCard(deck1.dealCard());
			player1Done = true;
			p1Double = true;
		}
									//***NEW****//
									if(player1hand.getBlackjackValue() >= 21){	//disallows more hits after 21 or bust
										player1Done = true;
										}
									if(player2hand.getBlackjackValue() >= 21){
										player2Done = true;
										}

		if(e.getSource() == player1StayButton){
			player1Done = true;
		}
		if(e.getSource() == player2StayButton){
			player2Done = true;
		}
	//if both players are done, show total for dealer hand instead of one card
		if(player1Done && player2Done){
			dealertotal = dealerhand.getBlackjackValue();
			dealerPlay();
		}
		else{
	   		dealertotal = dealerhand.getCard(0).getPointValue();
		}
        redraw();

         displayPanel.repaint(); // Paint display panel with new message.
      }
   }

//Simple function to delay game half a second
private void delayGame(){
	try {
	    Thread.sleep(500);
	} catch(InterruptedException ex) {
	    Thread.currentThread().interrupt();
	}
}

//**********New**********
//Function to be called after dealerPlay is finished, recalculates the money assuming a 10 chip bet, and does properly for busts and double downs

private void setNewMoney(){
	boolean dealerBusts = false, player1Busts = false, player2Busts = false;
	int dub1 = 1, dub2 = 1;

	if (p1Double)    //double down 20 chips
		dub1 = 2;
	if (p2Double)    //double down 20 chips
		dub2 = 2;
	if (dealerhand.getBlackjackValue() > 21)
		dealerBusts = true;
	if (player1hand.getBlackjackValue() > 21){  //If any of the 3 players goes over 21, they bust
		player1Busts = true;
		p1Status = "BUST!";
	}
	if (player2hand.getBlackjackValue() > 21){
		player2Busts = true;
		p2Status = "BUST!";
	}
	if (!player1Busts) {  //if player 1 doesn't bust continue checks, else he loses
		if (!dealerBusts){ //if player 1 didn't bust and dealer didn't continue, else he wins
			if(player1hand.getBlackjackValue() > dealerhand.getBlackjackValue()){
				p1Bet += 10 * dub1;  //needs to win other players bet
				p1Status = "WIN!";
				}
			else{ //if dealer hand is greater than player 1 at this point, player 1 loses
				p1Bet -=10 * dub1;
				p1Status = "LOST!";
			}
		}
		else{ //player didn't bust, dealer did, player 1 wins
			p1Bet += 10 * dub1;    //needs to win other players bet
			p1Status = "WIN!";
		}
	}
	else { //player 1 busted so automatic loss
		p1Bet -= 10 * dub1;
		p1Status = "BUST!";
	}

	if (!player2Busts) {  //if player 2 doesn't bust continue checks, else he loses
		if (!dealerBusts){ //if player 2 didn't bust and dealer didn't continue, else he wins
			if(player2hand.getBlackjackValue() > dealerhand.getBlackjackValue()){
				p2Bet += 10 * dub2;
				p2Status = "WIN!";
			}
			else{ //if dealer hand is greater than player 2 at this point, player 2 loses
				p2Bet -= 10 * dub2;
				p2Status = "LOST!";
			}
		}
		else{ //player didn't bust, dealer did, player 2 wins
			p2Bet += 10 * dub2; // += 10 more per player
			p2Status = "WIN!";
		}
	}
	else { //player 2 busted so automatic loss
		p2Bet -= 10 * dub2;    //  += 10 more per player
		p2Status = "BUST!";
	}

	p1Double = false;
	p2Double = false;

}

/***************************************/
//show and play dealers hand
private void dealerPlay(){
	while(dealerhand.getBlackjackValue() < 17) {
		dealerhand.addCard(deck1.dealCard());
		redraw();

	}
	dealerDone = true;
	setNewMoney();
	redraw();
	delayGame();

}
//Function for when deal button is pressed
private void dealPressed() {
		dealButton.setEnabled(false);
		dealt = true;
		player1Done = false;
		player2Done = false;
		dealerDone = false;


		//enable player buttons
		player1HitButton.setEnabled(true);
		player1DoubleButton.setEnabled(true);
		player1StayButton.setEnabled(true);
		player2HitButton.setEnabled(true);
		player2DoubleButton.setEnabled(true);
		player2StayButton.setEnabled(true);


		//When deal is pushed new hand so clear hands
		dealerhand.clear();
	    player1hand.clear();
	    player2hand.clear();
	    p1Status = "";
	    p2Status = "";   //Clear Results from last hand


	    //When deal, this resets the hit card images
	    for(int i = 0; i < 10; i++){//start of for loop
	         dealercards[i] = "images/blank.jpg";
	        player1cards[i] = "images/blank.jpg";
	        player2cards[i] = "images/blank.jpg";
	    						   }//end for loop

		//Add cards to start hand
		 dealerhand.addCard(deck1.dealCard()); //dealerhand take card from the top of deck
		 dealerhand.addCard(deck1.dealCard()); //takes second card

		player1hand.addCard(deck1.dealCard()); //deals card to player 1
		player1hand.addCard(deck1.dealCard()); //deals second card

		player2hand.addCard(deck1.dealCard()); //deals card to player 2
		player2hand.addCard(deck1.dealCard()); //deals second card


	    //Comment top out and bottom one in to see both dealer cards(debugging)
		dealercards[1] = "images/backside.jpg";


		// dealercards[1] = getCardPic(dealerhand.getCard(1));
	    dealercards[0] = getCardPic(dealerhand.getCard(0));


	    player2cards[0] = getCardPic(player2hand.getCard(0));
	    player2cards[1] = getCardPic(player2hand.getCard(1));

		// dealertotal = dealerhand.getBlackjackValue();
}
   /*Play game loop, ends when deck is below 20 cards
    *
    */


  public void playGame() {
       while (gameover == false) {//start of while


           if (deck1.cardsLeft() < 20){//start
               gameover = true;
           							  }//end
      							 }//end of while
   }






    /**
    * The applet's init() method creates the button and display panel and
    * adds them to the applet, and it sets up a listener to respond to
    * clicks on the button.
    */
public void init() { //start init loop


    dealercards[0]  = "images/backside.jpg";   //Displays the backside image for dealer card 1
    dealercards[1]  = "images/backside.jpg";   //Displays the backside image for dealer card 2
    player1cards[0] = "images/backside.jpg";   //Displays the backside image for player1 card 1
    player1cards[1] = "images/backside.jpg";   //Displays the backside image for player1 card 2
    player2cards[0] = "images/backside.jpg";   //Displays the backside image for player2 card 1
    player2cards[1] = "images/backside.jpg";   //Displays the backside image for player2 card 2

    for(int i = 2; i < 10; i++){				//Start of for loop
         dealercards[i]  = "images/blank.jpg";
         player1cards[i] = "images/blank.jpg";
         player2cards[i] = "images/blank.jpg";
    						   }				//end of for loop


    setSize(1024, 768);	//Sets size of applet

    displayPanel = new blackjackTable();
    displayPanel.setLayout(new BorderLayout());
    dealButton.addActionListener(listener);					   //Deal button listender

    player1HitButton.addActionListener(listener);              //Player1 Hit button listener
    player1DoubleButton.addActionListener(listener);		   //Player1 Double down button listener
    player1StayButton.addActionListener(listener);			   //Player1 Stay button listener
    player2HitButton.addActionListener(listener);			   //Player2 Hit button listener
    player2DoubleButton.addActionListener(listener);           //Player2 Double down button listener
    player2StayButton.addActionListener(listener);			   //Player2 Stay button listener

    player1HitButton.setPreferredSize(new Dimension(50,15));   //Creates player 1 Hit button.         (x,y) <- dimensions of button
    player1StayButton.setPreferredSize(new Dimension(50,15));  //Creates player 1 Stay button.        (x,y) <- dimensions of button
    player1DoubleButton.setPreferredSize(new Dimension(50,15));//Creates player 1 Double Down button. (x,y) <- dimensions of button
    player2HitButton.setPreferredSize(new Dimension(50,15));   //Creates player 2 Hit button.         (x,y) <- dimensions of button
    player2StayButton.setPreferredSize(new Dimension(50,15));  //Creates player 2 Stay button.        (x,y) <- dimensions of button
    player2DoubleButton.setPreferredSize(new Dimension(50,15));//Creates player 2 Double Down button. (x,y) <- dimensions of button

    redraw();												   //redraws them next frame
    deck1.shuffle();										   //shuffles decks
   				  } //end of init loop



   /* This method redraws all the images, only way I could get it functioning
    * when I tried g.drawimage or adding code to paint component, it just kept
    * repeating the images and extending them down to infinity
    */
public void redraw(){
//set player cards for display
        for (int i = 0; i < player1hand.getCardCount(); i++) {		//part a of card revealing
            player1cards[i] = getCardPic(player1hand.getCard(i));
        }
        for (int i = 0; i < player2hand.getCardCount(); i++) { 		//part b of card revealing
            player2cards[i] = getCardPic(player2hand.getCard(i));
        }
        for (int i = 2; i < dealerhand.getCardCount(); i++) {       //reveals cards shown for all players
			dealercards[i] = getCardPic(dealerhand.getCard(i));

		}

		if(dealerDone) {										//If dealer done
			dealButton.setEnabled(true);						//enable the deal button to start new round

		}

		if (player1Done == true && player2Done == true){		//If both player 1 and 2 press stay
			dealercards[1] = getCardPic(dealerhand.getCard(1)); //Dealer gets card. Flips second card faceup. (NOTE BUG HERE OR BELOW!!!)
		}
		if(dealt == false){			//Keeps Hit and Stay buttons unclickable until Deal
			player1Done = true;		//is pressed, for both player 1 and 2.
			player2Done = true;     //
						  }         //


		if(player2Done == true)  {				  //Disable all players buttons
			player2HitButton.setEnabled(false);   //for both players when both
			player2DoubleButton.setEnabled(false);//finish their turn to wait
			player2StayButton.setEnabled(false);  //for the dealer.
								 }


        if (player1Done == true) {				  //Disable all players buttons
			player1HitButton.setEnabled(false);	  //for both players when both
			player1DoubleButton.setEnabled(false);//finish their turn to wait
			player1StayButton.setEnabled(false);  //for the dealer.
								 }





        player1total = player1hand.getBlackjackValue(); //sets player1total to value of points in hand
        player2total = player2hand.getBlackjackValue(); //sets player2total to value of points in hand

       blackjackTable dealer = new blackjackTable();
        blackjackTable dealerhits = new blackjackTable();

        //ImageIcon dealerimage0 = new ImageIcon(dealercards[0]);
		dealers.setEditable(false);
        dealers.setText(dealertotal.toString());

       //Dealer layout horizontal box to add components in line accross
        //Dealerhits layout is vertical box to stack different components
        dealer.setLayout(new BoxLayout(dealer, BoxLayout.LINE_AXIS));
        dealerhits.setLayout(new BoxLayout(dealerhits, BoxLayout.PAGE_AXIS));


        //Dealers top panel, button, first cards, and total
        ImageIcon dealerimage1 = new ImageIcon(dealercards[0]);
        	JLabel label = new JLabel("", dealerimage1, JLabel.CENTER);
        ImageIcon dealerimage2 = new ImageIcon(dealercards[1]);
        	JLabel label2 = new JLabel("", dealerimage2, JLabel.CENTER);

        dealer.add(Box.createRigidArea(new Dimension(20,0)));
        dealer.add(dealButton);
        dealer.add(Box.createRigidArea(new Dimension(350,0)));
        dealer.add(Box.createRigidArea(new Dimension(40,0)));
        dealer.add(label);
        dealer.add(Box.createRigidArea(new Dimension(10,0)));
        dealer.add(label2);
        dealer.add(Box.createRigidArea(new Dimension(90,0)));
        dealer.add(dealers);
        dealer.add(Box.createRigidArea(new Dimension(340,0)));


        //center panels dealerhitscards, shows the extra cards for dealer
        blackjackTable dealerhitscards = new blackjackTable();
        dealerhitscards.setLayout(new BoxLayout(dealerhitscards, BoxLayout.LINE_AXIS));


        //Displaying either cards or blank place holder images
        ImageIcon dealerimage3 = new ImageIcon(dealercards[2]);
       		JLabel label3 = new JLabel("", dealerimage3, JLabel.CENTER);

        ImageIcon dealerimage4 = new ImageIcon(dealercards[3]);
        	JLabel label4 = new JLabel("", dealerimage4, JLabel.CENTER);

        ImageIcon dealerimage5 = new ImageIcon(dealercards[4]);
        	JLabel label5 = new JLabel("", dealerimage5, JLabel.CENTER);

        ImageIcon dealerimage6 = new ImageIcon(dealercards[5]);
        	JLabel label6 = new JLabel("", dealerimage6, JLabel.CENTER);

        ImageIcon dealerimage7 = new ImageIcon(dealercards[6]);
        	JLabel label7 = new JLabel("", dealerimage7, JLabel.CENTER);

        ImageIcon dealerimage8 = new ImageIcon(dealercards[7]);
        	JLabel label8 = new JLabel("", dealerimage8, JLabel.CENTER);

       ImageIcon dealerimage9 = new ImageIcon(dealercards[8]);
        	JLabel label9 = new JLabel("", dealerimage9, JLabel.CENTER);

       ImageIcon dealerimage10 = new ImageIcon(dealercards[9]);
        	JLabel label10 = new JLabel("", dealerimage10, JLabel.CENTER);


        //Adding the icons to dealerhitscards
        //dealerhitscards.add(Box.createRigidArea(new Dimension(30,0)));    //<- Does nothing?
        dealerhitscards.add(label3);										//First card slot for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));		//Dimensions (x,y) for space between slots.
        dealerhitscards.add(label4);										//Second card slot for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));		//10 space moving x direction before next slot
        dealerhitscards.add(label5);										//slot 3 for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));	    //10 space moving x direction before next slot
        dealerhitscards.add(label6);										//slot 4 for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));		//10 space moving x direction before next slot
        dealerhitscards.add(label7);										//slot 5 for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));		//10 space moving x direction before next slot
        dealerhitscards.add(label8);										//slot 6 for dealer
        dealerhitscards.add(Box.createRigidArea(new Dimension(10,0)));		//10 space moving x direction before next slot
        dealerhitscards.add(label9);										//slot 7 for dealer


        //bets panel displays the two bet boxes
        blackjackTable bets = new blackjackTable();

        JTextField player1bet = new JTextField(6);							//Sets how wide box is based on characters that can fit in it. Currently
        JTextField player2bet = new JTextField(6);							//hold 6 so max number of cash is 999999.
		JTextField p1WL		  = new JTextField(6);							//Makes new box for hand results
		JTextField p2WL		  = new JTextField(6);

		p1WL.setText(p1Status);												//sets what text goes into the box
		p2WL.setText(p2Status);
		player1bet.setText("$" + p1Bet);
		player2bet.setText("$" + p2Bet);

       	bets.add(p1WL);														//adds the boxes to the board
       	bets.add(player1bet);
        bets.add(Box.createRigidArea(new Dimension (290,0)));               //Sets betting box
        bets.add(p2WL);
        bets.add(player2bet);												//Bet box for player 2



        //player hits cards displays players' extra cards
        blackjackTable playerhitcards = new blackjackTable();
        playerhitcards.setLayout(new BoxLayout(playerhitcards, BoxLayout.LINE_AXIS));

        ImageIcon player1image3 = new ImageIcon(player1cards[2]);
        	JLabel player1hit3 = new JLabel("", player1image3, JLabel.CENTER);

        ImageIcon player1image4 = new ImageIcon(player1cards[3]);
        	JLabel player1hit4 = new JLabel("", player1image4, JLabel.CENTER);

        ImageIcon player1image5 = new ImageIcon(player1cards[4]);
        	JLabel player1hit5 = new JLabel("", player1image5, JLabel.CENTER);

        ImageIcon player1image6 = new ImageIcon(player1cards[5]);
        	JLabel player1hit6 = new JLabel("", player1image6, JLabel.CENTER);

        ImageIcon player1image7 = new ImageIcon(player1cards[6]);
        	JLabel player1hit7 = new JLabel("", player1image7, JLabel.CENTER);

        //playerhitcards.add(Box.createRigidArea(new Dimension(100,0)));    //Not necessary?
        playerhitcards.add(player1hit3);
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));
        playerhitcards.add(player1hit4);
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));
        playerhitcards.add(player1hit5);
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));
        playerhitcards.add(player1hit6);
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));
        playerhitcards.add(player1hit7);
        playerhitcards.add(Box.createRigidArea(new Dimension(215,0)));    //Adjust the distense of penels

        //Same for player 2
        ImageIcon player2image3 = new ImageIcon(player2cards[2]);
        	JLabel player2hit3 = new JLabel("", player2image3, JLabel.CENTER);

        ImageIcon player2image4 = new ImageIcon(player2cards[3]);
        	JLabel player2hit4 = new JLabel("", player2image4, JLabel.CENTER);

        ImageIcon player2image5 = new ImageIcon(player2cards[4]);
        	JLabel player2hit5 = new JLabel("", player2image5, JLabel.CENTER);

        ImageIcon player2image6 = new ImageIcon(player2cards[5]);
        	JLabel player2hit6 = new JLabel("", player2image6, JLabel.CENTER);

        ImageIcon player2image7 = new ImageIcon(player2cards[6]);
        	JLabel player2hit7 = new JLabel("", player2image7, JLabel.CENTER);

        playerhitcards.add(Box.createRigidArea(new Dimension(5,0)));     //Perfect alignment
        playerhitcards.add(player2hit3);								 //placement of second player 1st slot
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));	 //space between 1st slot and 2nd
        playerhitcards.add(player2hit4);							     //placement of second player 2nd slot
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));    //space between 2nd and 3rd ect
        playerhitcards.add(player2hit5);								 //placement of second player 3rd slot
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));    //space between 3rd and 4th
        playerhitcards.add(player2hit6);								 //placement of second player 4th slot
        playerhitcards.add(Box.createRigidArea(new Dimension(10,0)));	 //space between 4th and 5th
        playerhitcards.add(player2hit7);								 //placement of 5th slot

        //Building slots for cards
        dealerhits.add(dealerhitscards);							//Draws dealer card slots
        dealerhits.add(Box.createRigidArea(new Dimension(0,325)));  //Limits areas of Bet box and card slot (x does nothing in this context)
        dealerhits.add(bets);										//Draws players card slots
        dealerhits.add(Box.createRigidArea(new Dimension(10,60)));  //Moves the same thing as the first one?
        dealerhits.add(playerhitcards);								//Draws plater card slots


        //Panes needed for bottom player area
        blackjackTable playerCards = new blackjackTable(); //variable playersCards of type blackjackTable = object blackjackTable();
        blackjackTable playerArea  = new blackjackTable(); //variable playersArea of type blackjackTable = object blackjackTable();

       //Pane to stack the three buttons on each other
        blackjackTable player1buttons = new blackjackTable();
        player1buttons.setLayout(new BoxLayout(player1buttons, BoxLayout.PAGE_AXIS));
        player1buttons.add(player1HitButton);
        player1buttons.add(player1StayButton);
        player1buttons.add(player1DoubleButton);

        //button pane for player 2
        blackjackTable player2buttons = new blackjackTable();
        player2buttons.setLayout(new BoxLayout(player2buttons, BoxLayout.PAGE_AXIS));
        player2buttons.add(player2HitButton);
        player2buttons.add(player2StayButton);
        player2buttons.add(player2DoubleButton);

		player1s.setEditable(false);
		player2s.setEditable(false);
		player1s.setText(player1total.toString());
		player2s.setText(player2total.toString());

		//adding cards and buttons and whatnot for player 1
		playerCards.setLayout(new BoxLayout(playerCards, BoxLayout.LINE_AXIS));
		playerCards.add(Box.createRigidArea(new Dimension(10,140)));
		ImageIcon player1image1 = new ImageIcon(player1cards[0]);
		JLabel player1label = new JLabel("", player1image1, JLabel.CENTER);
		ImageIcon player1image2 = new ImageIcon(player1cards[1]);
		JLabel player1label2 = new JLabel("", player1image2, JLabel.CENTER);
		playerCards.add(Box.createRigidArea(new Dimension(270,0)));
		playerCards.add(player1buttons);
		playerCards.add(Box.createRigidArea(new Dimension(30,0)));
		playerCards.add(player1label);
		playerCards.add(Box.createRigidArea(new Dimension(10,0)));
		playerCards.add(player1label2);
		playerCards.add(Box.createRigidArea(new Dimension(40,0)));
		playerCards.add(player1s);
		playerCards.add(Box.createRigidArea(new Dimension(50,0)));

		//adding cards and stuff for player2
     	ImageIcon player2image1 = new ImageIcon(player2cards[0]);
		JLabel player2label = new JLabel("", player2image1, JLabel.CENTER);
		ImageIcon player2image2 = new ImageIcon(player2cards[1]);
		JLabel player2label2 = new JLabel("", player2image2, JLabel.CENTER);
		playerCards.add(Box.createRigidArea(new Dimension(150,0)));
		playerCards.add(player2buttons);
		playerCards.add(Box.createRigidArea(new Dimension(30,0)));
		playerCards.add(player2label);
		playerCards.add(Box.createRigidArea(new Dimension(10,0)));
		playerCards.add(player2label2);
		playerCards.add(Box.createRigidArea(new Dimension(40,0)));
		playerCards.add(player2s);
		playerCards.add(Box.createRigidArea(new Dimension(270,0)));


        playerArea.add(playerCards);
    	displayPanel.add(dealer, BorderLayout.NORTH);
		displayPanel.add(dealerhits, BorderLayout.CENTER);
        displayPanel.add(playerArea, BorderLayout.SOUTH);
      	setContentPane(displayPanel);

	}


   String getCardPic(Card C){

	 //builds the path for the proper image to display
	  String pth = "images/";              //Sets string pth to images/
	  String suit;						   //Initializes suit
	  int value;						   //Initializes value
	  suit = C.getSuitAsString();		   //gets suit string

	  if (suit == "Spades"){			   //If Spade
		  pth += "s";					   //Append s to pth  = images/ (new string images/s)
	  }
	  if (suit == "Hearts"){			   //If Hearts
		  pth += "h"; 					   //Append h to pth  = images/ (new string images/h)
	  }
	  if (suit == "Clubs"){                //If Clubs
	  	  pth += "c";					   //Append c to pth  = images/ (new string images/c)
	  }
	  if (suit == "Diamonds"){			   //If Diamonds
	  	  pth += "d";					   //Append d to pth  = images/ (new string images/d)
	  }
	  pth += "-";						   //Append - to pth  = images/(string) (new string images/(string)-)
	  value = C.getValue();
	  switch ( value ) {
		 case 1:   pth += "1"; break;     //If case 1  Append 1  to pth  = images/(string)- (new string images/(string)-1 )
		 case 2:   pth += "2"; break;	  //If case 2  Append 2  to pth  = images/(string)- (new string images/(string)-2 )
		 case 3:   pth += "3"; break;     //If case 3  Append 3  to pth  = images/(string)- (new string images/(string)-3 )
		 case 4:   pth += "4"; break;     //If case 4  Append 4  to pth  = images/(string)- (new string images/(string)-4 )
		 case 5:   pth += "5"; break;     //If case 5  Append 5  to pth  = images/(string)- (new string images/(string)-5 )
		 case 6:   pth += "6"; break;     //If case 6  Append 6  to pth  = images/(string)- (new string images/(string)-6 )
		 case 7:   pth += "7"; break;     //If case 7  Append 7  to pth  = images/(string)- (new string images/(string)-7 )
		 case 8:   pth += "8"; break;     //If case 8  Append 8  to pth  = images/(string)- (new string images/(string)-8 )
		 case 9:   pth += "9"; break;     //If case 9  Append 9  to pth  = images/(string)- (new string images/(string)-9 )
		 case 10:  pth += "10"; break;    //If case 10 Append 10 to pth  = images/(string)- (new string images/(string)-10)
		 case 11:  pth += "11"; break;    //If case 11 Append 11 to pth  = images/(string)- (new string images/(string)-11)
		 case 12:  pth += "12"; break;    //If case 12 Append 12 to pth  = images/(string)- (new string images/(string)-12)
         default:  pth += "13"; break;    //If case 13 Append 13 to pth  = images/(string)- (new string images/(string)-13)
	 }
	 pth += ".jpg";                       //append images/(string)-(string).jpg
	 return pth;						  //return completed string string

   }
}