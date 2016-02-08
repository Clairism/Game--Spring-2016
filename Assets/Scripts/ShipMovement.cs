using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public Vector2 speed = new Vector2(5,0);
	public float fireCooldownTime = 1;
	public bool wrapScreen = false;
	public float health = 1;
	public float damageToEnemyShip =1;

	float lastFireTime = 0;
	bool firing = false;

	public Transform shipShot;
	public Transform explosion;

	SpriteRenderer SpriteRenderR;
	Text shipHealthDisplay;
	float hitTime = .15f;
	
	void Start () {
		StartCoroutine ("loadValues");
		SpriteRenderR = GetComponent<SpriteRenderer> ();
		shipHealthDisplay = GameObject.Find ("ShipHealthDisplay").GetComponent<Text> ();
	}

	IEnumerator loadValues() {
		while (GameManager.isLoaded == false) {
		//	Debug.Log ("not loaded; Ship Movement 16");
			yield return null;
		}
		speed = new Vector2 (GameManager.shipSpeed.x, GameManager.shipSpeed.y);
		wrapScreen = GameManager.shipWrap;
		health = GameManager.shipHealth;
		fireCooldownTime = GameManager.shipFireCooldown;
		damageToEnemyShip = GameManager.shipRammingDamage;
	}

	void Update () {
		checkInput();
		screenWrap();
		updateUI ();
	}

	void checkInput(){

		Vector3 movement = transform.position;

		//Check Movement
		if( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ){
			movement.x -= speed.x * Time.deltaTime;
		}else if( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ){
			movement.x += speed.x * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			movement.y += speed.y * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			movement.y -= speed.y * Time.deltaTime;
		}

		transform.position = movement;

		//Check for fire
		if( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey( KeyCode.X ) ) {
			fire();
		}

		if (Input.GetKey (KeyCode.R)) {
			explode ();
		}
	}

	void screenWrap(){
		Vector3 ViewportPosition = Camera.main.WorldToViewportPoint (transform.position);
		Vector3 wrapPositionZero = Camera.main.ViewportToWorldPoint (Vector3.zero);
		Vector3 wrapPositionOne = Camera.main.ViewportToWorldPoint (Vector3.one);
		Vector3 newPos = transform.position;
		if (wrapScreen) {

			if (ViewportPosition.x > 1) {
				newPos = new Vector3 (wrapPositionZero.x + .1f, transform.position.y, transform.position.z);
			} else if (ViewportPosition.x < 0) {
				newPos = new Vector3 (wrapPositionOne.x + -.1f, transform.position.y, transform.position.z);
			}
			transform.position = newPos;
			if (ViewportPosition.y > 1) {
				newPos = new Vector3 (transform.position.x, wrapPositionZero.y, transform.position.z);
			} else if (ViewportPosition.y < 0) {
				newPos = new Vector3 (transform.position.x, wrapPositionOne.y, transform.position.z);
			}
			transform.position = newPos;
		}else{
			if (ViewportPosition.x > 1) {
				newPos = new Vector3 (wrapPositionOne.x - .1f, transform.position.y, transform.position.z);
			} else if (ViewportPosition.x < 0) {
				newPos = new Vector3 (wrapPositionZero.x + -.1f, transform.position.y, transform.position.z);
			}
			transform.position = newPos;
			if (ViewportPosition.y > 1) {
				newPos = new Vector3 (transform.position.x, wrapPositionOne.y, transform.position.z);
			} else if (ViewportPosition.y < 0) {
				newPos = new Vector3 (transform.position.x, wrapPositionZero.y, transform.position.z);
			}
			transform.position = newPos;
		}
	}

	void updateUI() {
		shipHealthDisplay.text = Math.Round(health, 2).ToString();
	}

	void fire(){
		if (!firing) {
			firing = true;
			lastFireTime = Time.time;
			Instantiate (shipShot, transform.position, transform.rotation);
		} else {
			if (Time.time - lastFireTime > fireCooldownTime) {
				firing = false;
			}
		}
	}
	void hit( float damage ) {
		SpriteRenderR.color = Color.red;
		StartCoroutine ("turnBackNormal");

		health -= damage;
		//Debug.Log ("SHIP HIT! Health Left: " + health);
		if (health <= 0) {
			explode ();
			//Debug.Log("THIS IS WHERE YOU DIEEEEEEE");
		}
	}
	IEnumerator turnBackNormal () {
		yield return new WaitForSeconds (hitTime);
		SpriteRenderR.color = Color.white;
	}

	void explode() {
		health = 0;
		updateUI ();
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		GameManager.restartRequired = true;
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Enemy") {
			coll.gameObject.SendMessage ("hit", damageToEnemyShip);
		}
	}
}
