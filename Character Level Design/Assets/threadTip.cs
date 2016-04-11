using UnityEngine;
using System.Collections;

public class threadTip : MonoBehaviour {

	public bool hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
//		print ("triggered");

		if (other.tag == "Above") {
			hit = true;
//			print (hit);
		}
	}
}
