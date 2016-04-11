using UnityEngine;
using System.Collections;

public class winTheGame : MonoBehaviour {

	bool win;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			win = true;
		}
	}
}
