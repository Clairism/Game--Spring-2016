using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	bool get;


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		get = GameObject.Find ("Key").GetComponent<getKey> ().gotKey;
	
	}

	void OnTriggerEnter(Collider others){

		Debug.Log (get);

		if (get == true && others.tag == "Player") {
			Application.LoadLevel (1);
			Debug.Log ("yeah");
		} 
	}
}
