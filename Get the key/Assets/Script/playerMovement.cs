using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	float playerSpeed;
	float xSpeed;
	float zSpeed;

	public Rigidbody rb;

	bool gotKey;


	// Use this for initialization
	void Start () {

		playerSpeed = 8;
		rb = gameObject.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//		xSpeed = Input.GetAxis ("Horizontal") * playerSpeed;
//		zSpeed = Input.GetAxis ("Vertical") * playerSpeed;


//		rb.position += new Vector3 (xSpeed, 0, 0);
//		rb.position += new Vector3 (0, 0, zSpeed);

		if (Input.GetAxis ("Horizontal") == 1) {
			rb.velocity = new Vector3 (xSpeed, 0, 0);
		}
		//rb.velocity = new Vector3 (0, 0, zSpeed);


		xSpeed = Input.GetAxis ("Horizontal");
		zSpeed = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (xSpeed, 0.0f, zSpeed);
		rb.velocity = movement * playerSpeed;

}

	void OnTriggerEnter (Collider others){

		if (others.tag == "Key") {
			gotKey = true;
			Destroy (GameObject.FindGameObjectWithTag ("Key"));
		}

		if (others.tag == "Door" && gotKey) {

			Application.LoadLevel (1);
			//Debug.Log ("yeah");

		}

	}

}
