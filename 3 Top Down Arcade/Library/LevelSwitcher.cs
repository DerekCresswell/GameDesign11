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
 * This script will allow you to switch between
 * scenes.
 * Can be used to switch when collided with or when
 * calling the OnLoadButton function.
 *
 */

/* 
 *
 * --- What You Need To Do ---
 *  
 * Define the sceneName variable to match the name of
 * the scene you want to load.
 *
 * Add a 2D collider to the object this is on if you
 * want to use the OnCollisionEnter2D function.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {

	// The name of the scene to switch to
	// Must match EXACTLY
	public string sceneName;

	// Switches level when colliding with the player
	void OnCollisionEnter2D(Collision2D collision) {

		// You can change this tag to anything
		if(collision.gameObject.tag == "Player") {
			SceneManager.LoadScene(sceneName);
		}

	}

	public void LoadOnButton() {
		SceneManager.LoadScene(sceneName);
	}

}