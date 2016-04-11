using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	Animator animator;
	Rigidbody2D rb;

	float playerSpeed;
//	float posX, posY;
	bool flipY;


	public GameObject thread;
	Vector2 currentPosition;
	Vector2 endPosition;
	Vector2 end;

//	float direction;
	float pct = 0.2f;
	float speed = 0.2f;


	public float shootTime;
	bool shooted;
	bool grabNow;

	float jumpTime, jumpDelay, jumpForce;
	bool jumped;
	bool isGround;

	public GUIStyle counterStyle;
	int lifeCounter;
	float size;

	public GUIStyle textStyle;
	public bool gameOver;

	public Transform groundCheck;

	string energyChange;

	bool energyChanged = false;

	void Start () {

		animator = GetComponent<Animator>();

		playerSpeed = 5;
//		posX = -4.5f;

		jumpTime = 0;
		jumpDelay = 1f;
		jumpForce = 120f;

		rb = GetComponent<Rigidbody2D> ();

		lifeCounter = 50;

		isGround = false;

		gameOver = false;

	}


	void Update () {

		changeStates ();

		if(gameOver){
			Destroy (GameObject.Find("Spawners"));
			print (gameOver);
		}

//		posX = GetComponent<Transform> ().position.x;
//		posY = GetComponent<Transform> ().position.y;

		isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
	
//		print(isGround);

		if (jumpTime >= 0) {
			
			GetComponent<SpriteRenderer> ().flipY = false;

		}

		//lerp to grab
		currentPosition = transform.position;
		if (GameObject.Find ("tip") != null) {
			endPosition = GameObject.Find ("tip").transform.position;
		} else {
			endPosition = transform.position;
		}

		speed = Mathf.Max(speed, .000001f);
		pct += Time.deltaTime/speed;

		if ((pct > 1) || (pct < 0)) {
			//direction = -direction;
			pct = Mathf.Clamp(pct, 0, 1);
		}

	}
		

	void changeStates(){
		if (!gameOver) {
			//run
			if (Input.GetAxis ("Horizontal") != 0) {
				
				animator.SetBool ("run", true);

				//go left
				if (Input.GetAxisRaw ("Horizontal") < 0) {
				
					GetComponent<SpriteRenderer> ().flipY = true;

					transform.position -= new Vector3 (playerSpeed * Time.deltaTime, 0, 0);

					//go right
				} else if (Input.GetAxisRaw ("Horizontal") > 0) {

					GetComponent<SpriteRenderer> ().flipY = false;

					transform.position += new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
				}

				animator.SetBool ("shoot", false);

			} else {
				animator.SetBool ("run", false);

			}


			//jump
			if (Input.GetKeyDown (KeyCode.Space) && isGround && !jumped) { //no double-jump

				transform.eulerAngles = new Vector3 (45, 0, 0);

				rb.AddForce (transform.up * 120f);

				jumpTime = jumpDelay;

				animator.SetBool ("land", false);
				animator.SetBool ("jump", true);
				jumped = true;
			}

			jumpTime -= Time.deltaTime;

			if (jumpTime <= 0 && isGround && jumped) {
				transform.eulerAngles = new Vector3 (0, 0, 90);

				animator.SetBool ("jump", false);
				animator.SetBool ("land", true);
				jumped = false;
			}

			//shoot
			if (Input.GetKeyDown (KeyCode.Z) && !shooted) {//no double shoot
			
				GetComponent<SpriteRenderer> ().flipY = false;

				transform.eulerAngles = new Vector3 (0, 0, 140);
				animator.SetBool ("shoot", true);

				shooted = true;
				shootThread ();

				//if shooted & has tip
			} else if (shooted && GameObject.Find ("tip") != null && GameObject.Find ("tip").GetComponent<threadTip> ().hit) {

				transform.position = Vector2.Lerp (currentPosition, endPosition, pct);
				shooted = false;

			}

			if (GameObject.Find ("tip") == null && shooted) {
				animator.SetBool ("shoot", false);
				transform.eulerAngles = new Vector3 (0, 0, 90);

				shooted = false;
			}



	//if game over
		} else {
			animator.SetBool ("run", false);
			animator.SetBool ("shoot", false);
			animator.SetBool ("jump", false);


		}

		//die
		if(lifeCounter <= 0 || gameOver){
			animator.SetBool ("die", true);

			gameOver = true;

		}

	}

	void finishShoot(){
		animator.SetBool ("shoot", false);
	}

	void shootThread(){
		Instantiate (thread);
	}

	void OnGUI () {

		GUI.Label(new Rect(Screen.width - 200,10,150,100), "Energy: " + lifeCounter, counterStyle);

		if (gameOver) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 30, 30), "Game Over!", textStyle);
		}

		if (energyChanged) {
			GUI.Label (new Rect (200, Screen.height / 2 - 100f, 10, 10), "Energy" + energyChange, textStyle);

			Invoke ("changeEnergyState", .8f);
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		//energy points
		if (other.tag == "fly" && !gameOver) {
			lifeCounter += 3;
		
			energyChange = "+3";
		}

		if (other.tag == "dragonfly" && !gameOver) {
			lifeCounter += 2;

			energyChange = "+2";

		}

		if (other.tag == "killer" && !gameOver) {
			lifeCounter -= 5;

			energyChange = "-5";

	
		}

		if (other.tag == "swat" && !gameOver) {
			lifeCounter -= 8;

			energyChange = "-8";

		}

		if (other.tag == "water" && !gameOver) {
			lifeCounter = 0;
			//print ("hit water");

		}

		if (other.tag != "Ground" && other.tag != "Above" && other.tag != "thread" && other.tag != "water") {
			
			energyChanged = true;
		}

//		print (other);
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "movingGround") {
			transform.parent = other.transform;

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "movingGround") {
			transform.parent = null;

		}
	}
		

	void changeEnergyState(){
		
		energyChanged = false;

	}

		
}
