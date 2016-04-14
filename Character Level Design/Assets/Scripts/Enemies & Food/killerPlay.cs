using UnityEngine;
using System.Collections;

public class killerPlay : MonoBehaviour {
	float speed;

	Animator animator;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			animator.SetTrigger ("spray");
		}
	}
}
