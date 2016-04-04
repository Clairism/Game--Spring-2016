using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	Animator animator;
	Rigidbody2D rb;

	public GameObject thread;
	public float shootTime;

	float playerSpeed;
	float posX, posY;

	float jumpTime, jumpDelay = .3f;
	bool jumped;

	public GUIStyle counterStyle;
	int lifeCounter;
	float size;

	// Use this for initialization
	public virtual void Start () {

		animator = GetComponent<Animator>();

		playerSpeed = 5;
		posX = -4.5f;
		rb = GetComponent<Rigidbody2D> ();

		lifeCounter = 50;
		//size = 1;

	}

	// Update is called once per frame
	public virtual void Update () {

		changeStates ();

		posX = GetComponent<Transform> ().position.x;
		posY = GetComponent<Transform> ().position.y;

		if (posY < 0) {
			rb.gravityScale = 0;
			transform.position = new Vector3 (posX, 0, 4);

		} else if (posY > 0){

			rb.gravityScale = 0.5f;

		}

		//changing size
		/*
		if (lifeCounter * 0.1f >= size) {
			GetComponent<Transform> ().localScale += new Vector3 (0.1f, 0.1f, 0.1f);
			size = lifeCounter * 0.1f;
		} else {
			GetComponent<Transform> ().localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			size = lifeCounter * 0.1f;
		}
		*/

	}

	void changeStates(){

		//run
		if(Input.GetAxis("Horizontal") != 0){
			animator.SetBool ("run", true);

			//go left
			if (Input.GetAxisRaw ("Horizontal") < 0) {
				GetComponent<SpriteRenderer> ().flipY = true;
				transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0, 0);

			 //go right
			}else if (Input.GetAxisRaw ("Horizontal") > 0) {
				GetComponent<SpriteRenderer> ().flipY = false;
				transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);
			}
		}else {
			animator.SetBool ("run", false);
		}

		//jump
		if (Input.GetKey(KeyCode.Space) && posY <= 1) {
			transform.eulerAngles = new Vector3(45, 0, 0);

			transform.Rotate(Vector3.up * 10f);

			rb.AddForce(transform.up * 10f);

			jumpTime = jumpDelay;

			animator.SetBool("land", false);
			animator.SetBool ("jump", true);
//			animator.SetTrigger("jump0");

			jumped = true;
		}

		jumpTime -= Time.deltaTime;

		if(jumpTime <= 0 && posY == 0 && jumped){

			transform.eulerAngles = new Vector3(0, 0, 90);
			animator.SetBool("jump", false);
			animator.SetBool("land", true);
//			animator.SetTrigger("land0");

			jumped = false;
		}


		//shoot
		if (Input.GetKey (KeyCode.Z)) {
			transform.eulerAngles = new Vector3(0, 0, 140);
			animator.SetBool ("shoot", true);

			shootTime += Time.deltaTime;
			shootThread ();

		}else {
			transform.eulerAngles = new Vector3(0, 0, 90);
			animator.SetBool ("shoot", false);

			shootTime = 0;

		}


		//die
		if(lifeCounter == 0){
			animator.SetBool ("die", true);
		}

	}

	void finishShoot(){
		animator.SetBool ("shoot", false);
	}

	void shootThread(){
		Instantiate (thread);
	}

	void OnGUI () {

		GUI.Label(new Rect(Screen.width-200,10,300,30), "Life: " + lifeCounter, counterStyle);
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "fly") {
			lifeCounter += 3;
		}

		if (other.tag == "dragonfly") {
			lifeCounter += 2;
		}

		if (other.tag == "killer") {
			lifeCounter -= 5;
		}

		if (other.tag == "swat") {
			lifeCounter -= 8;
		}

		if (other.tag == "water") {
			lifeCounter = 0;
			print ("hit water");
		}
	}
		
}
