using UnityEngine;
using System.Collections;

public class killerMoving : MonoBehaviour {

	float speed;

	Animator animator;


	// Use this for initialization
	void Start () {

		speed = Random.Range (0.03f, 0.08f);
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			animator.SetTrigger ("spray");
		}
	}
}
