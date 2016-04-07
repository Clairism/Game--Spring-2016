using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	Animator animator;
	Rigidbody2D rb;

	float playerSpeed;
	float posX, posY;
	bool flipY;


	public GameObject thread;
	Vector3 currentPosition;
	Vector3 endPosition;
	Vector3 end;
//	float pct = 0;
	public float shootTime;
	bool shooted;

	float jumpTime, jumpDelay, jumpForce;
	bool jumped;
	bool isGround;

	public GUIStyle counterStyle;
	int lifeCounter;
	float size;

	public GUIStyle textStyle;
	bool gameOver;

	public Transform groundCheck;

	string energyChange;

	bool energyChanged = false;

	void Start () {

		animator = GetComponent<Animator>();

		playerSpeed = 5;
		posX = -4.5f;

		jumpDelay = 1f;
		jumpForce = 120f;

		rb = GetComponent<Rigidbody2D> ();

		lifeCounter = 50;

		isGround = false;

		gameOver = false;

	}


	void Update () {

		if (!gameOver) {
			changeStates ();
		} else {
			Destroy (GameObject.Find("Spawners"));
		}

		posX = GetComponent<Transform> ().position.x;
		posY = GetComponent<Transform> ().position.y;

		//lerp to grab

		currentPosition = transform.position;

		isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
	
//		print(isGround);
	}

	void changeStates(){
		
		//run
		if (Input.GetAxis ("Horizontal") != 0) {
				
			animator.SetBool ("run", true);

			//go left
			if (Input.GetAxisRaw ("Horizontal") < 0) {
				if (!isGround) {
					GetComponent<SpriteRenderer> ().flipY = true;
				}
				transform.position -= new Vector3 (playerSpeed * Time.deltaTime, 0, 0);

				//go right
			} else if (Input.GetAxisRaw ("Horizontal") > 0) {
				if (!isGround) {
					
					GetComponent<SpriteRenderer> ().flipY = false;
				}
				transform.position += new Vector3 (playerSpeed * Time.deltaTime, 0, 0);
			}
		} else {
			animator.SetBool ("run", false);
		}


		//jump
		if (Input.GetKeyDown (KeyCode.Space) && isGround && !jumped) { //no double-jump

			transform.eulerAngles = new Vector3 (45, 0, 0);

			rb.AddForce(transform.up * 120f);

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
		if (Input.GetKey (KeyCode.Z)) {

			transform.eulerAngles = new Vector3(0, 0, 140);
			animator.SetBool ("shoot", true);

			shootTime += Time.deltaTime;
			shooted = true;

		}else if (shooted) {
			
			transform.eulerAngles = new Vector3(0, 0, 90);
			animator.SetBool ("shoot", false);
			endPosition = GameObject.FindGameObjectWithTag("grab").transform.position;

			//lerping if it's close enough
			if ((endPosition.x - currentPosition.x) <= 3f && (endPosition.x - currentPosition.x) >= 0f) {
				
				transform.position = Vector3.Lerp (currentPosition, endPosition, 10);

				end = new Vector3 (endPosition.x + 2.5f, 0, 4);
				transform.position = Vector3.Lerp (endPosition, end, 10);
			}

			shootThread ();
			shootTime = 0;
			shooted = false;

		}


		//die
		if(lifeCounter == 0){
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

		GUI.Label(new Rect(Screen.width-100,10,300,30), "Energy: " + lifeCounter, counterStyle);

		if (gameOver) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 30, 30), "Game Over!", textStyle);
		}

		if (energyChanged) {
			GUI.Label (new Rect (150, Screen.height / 2, 10, 10), "Energy" + energyChange, textStyle);

			Invoke ("changeEnergyState", .5f);
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		//energy points
		if (other.tag == "fly") {
			lifeCounter += 3;
		
			energyChange = "+3";
		}

		if (other.tag == "dragonfly") {
			lifeCounter += 2;

			energyChange = "+2";

		
		}

		if (other.tag == "killer") {
			lifeCounter -= 5;

			energyChange = "-5";

	
		}

		if (other.tag == "swat") {
			lifeCounter -= 8;
			energyChange = "-8";

	
		}

		if (other.tag == "water") {
			lifeCounter = 0;
			//print ("hit water");
		}

		if (other.tag != "Ground") {
			

			energyChanged = true;
		}
	}

	void changeEnergyState(){
		energyChanged = false;

	}
		
}
