using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ___________________________________________________
 * 
 *                     GameDesign11 
 * ___________________________________________________
 *  An intro to 2D Game Design using the Unity Engine
 * 
 * Author: DerekCresswell
 * https://github.com/DerekCresswell/GameDesign11
 * 
 */

/* 
 *
 * --- What You Need To Do ---
 * 
 * Change the class name from "DiceGameTemplate" to match the name of this file.
 * 
 * Add a valid condition to the while loop.
 * 
 * Add a second die roll to each turn and adjust values to work with them.
 * 
 * Copy and adjust the if else statements from player one's turn to player's two.
 * 
 * Print out some story. Use the actual health and damage values to make the story dynamic.
 * 
 * Attach this script to a game object and run your story a couple times to make sure all your code is working.
 * 
 */

public class DiceGameTemplate : MonoBehaviour {

    // Store health of both players as a number
    int playerOneHealth = 50;
    int playerTwoHealth = 50;

    // Store the turn number as an integer
    int turnCounter = 0;

    // Put all of your code in here, except /\ those variables of course
    void Start() {
        
        // Print out the start of the game, tell us what's going to happen
        //Debug.Log("Once upon a time...");

        // Change this \/ Saying while(true) is an infite loop and will crash your game
        while(true) {

            // Create a random "die roll" by using the Random class
            // Remember the first number is inclusive and the second is exclusive
    	    int dieOne = Random.Range(1, 7);

            // Make a second die roll

            // If the turn count is even it is player ones turn, else it's player twos turn
    	    if(turnCounter % 2 == 0) {
	   		
	   	        // Check to see which number was rolled on the die
                // Then apply damage based on that number
    		    if(dieOne == 6) {

            	    playerTwoHealth -= 30;
                    // Add in some story throughout
                    // Debug.Log("Player one takes 30 damage and now has " + playerOneHealth + " health left." );

                } else if(dieOne == 5) {

            	    playerTwoHealth -= 15;

                } else if(dieOne >= 3) {

	                playerTwoHealth -= 10;

                } else {

	                playerTwoHealth -= 5;

                }

    	    } else { // End of POne turn

    		    // Player Two's Turn
                // It is your job to copy and make the if else statements work down here with player 2!

    	    } // End of PTwo turn

            // Increment the turn count to switch turns
    	    turnCounter++;

        } // End of Turn while loop

        // Print out the winner!

    } // End of Start function

} // End of DiceGame class