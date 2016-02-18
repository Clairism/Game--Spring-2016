using UnityEngine;
using System.Collections;

public class getKey : MonoBehaviour {

	public bool gotKey;


	// Use this for initialization
	void Start () {

		gotKey = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider others){

		if (others.tag == "Player") {
			gotKey = true;
			Debug.Log (gotKey);

			//Destroy (gameObject);
			gameObject.SetActive (false);
		}
	}
}
