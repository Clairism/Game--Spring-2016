﻿using UnityEngine;
using System.Collections;

public class winTheGame : MonoBehaviour {

	bool win = false;
	public GUIStyle textStyle;


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			win = true;
			print ("win: " + win);
		}

		print ("hit home");

		Invoke ("winScene", 2f);
	}

	void OnGUI () {

		if (win) {
			//GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 50,50), "Welcome Home, little spider.", textStyle);
		}

	}

	void winScene(){

		Application.LoadLevel (2);
	}

}
