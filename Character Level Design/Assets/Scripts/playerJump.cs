using UnityEngine;
using System.Collections;

public class playerJump : MonoBehaviour {
	/*
	Animator anim;

	bool grounded, interact; //bool for checking if player is grounded so they can jump, and bool for interact, so that player can only interact when in range of thing to interact with
	public Transform jumpCheck, interactCheck; //transform variable for the end points of the linecasts

	RaycastHit2D interacted; //a variable type that stores a collider that was hit during linecast

	public float speed = 6.0f;

	float jumpTime, jumpDelay = .3f;
	bool jumped;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();


	}

	// Update is called once per frame
	void Update () {

		changeStates ();

		/*
		xSpeed = Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime;
		transform.Translate (Vector3.down * xSpeed);

		ySpeed = Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
		transform.Translate (Vector3.right * ySpeed);

		posX = GetComponent<Transform> ().position.x;
		posY = GetComponent<Transform> ().position.y;


	}

	void changeStates(){
		
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime); 
			transform.eulerAngles = new Vector2(0, 0); //this sets the rotation of the gameobject
		}

		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180); //this sets the rotation of the gameobject
		}

		if(Input.GetKeyDown (KeyCode.Space) && grounded) // If the jump button is pressed and the player is grounded then the player jumps 
		{
			GetComponent<Rigidbody2D>().AddForce(transform.up * 200f);
			jumpTime = jumpDelay;
			anim.SetTrigger("Jump");
			jumped = true;
		}

		jumpTime -= Time.deltaTime;
		if(jumpTime <= 0 && grounded && jumped)
		{
			anim.SetTrigger("Land");
			jumped = false;
		}

			
	}
//
//	void Moving(){
//
//		speed = Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime;
//
//		transform.Translate (Vector3.forward * playerSpeed);
//		//transform.Translate (Vector3.left * ySpeed);
//
//
//	}

	void finishShoot(){
		anim.SetBool ("shoot", false);
	}

*/
}
