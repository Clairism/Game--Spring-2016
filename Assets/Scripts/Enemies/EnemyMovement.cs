using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//Enemy Variables
	public string shipClass = "advance";
	public Vector2 speed = Vector2.zero;
	public float health = 1;
	bool firing = false;
	public float fireCooldownTime = 1;
	float lastFireTime = 0;
	public bool wrapScreen = true;
	public float damageToPlayerShip = 1;

	SpriteRenderer SpriteRenderR;
	float hitTime = .15f;

	//External Variables
	GameObject player;
	public GameObject bulletToFire;
	public GameObject explosion;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine ("loadValues");
		lastFireTime = fireCooldownTime;
		SpriteRenderR = GetComponent<SpriteRenderer> ();
	}

	void Update () {

		checkFire ();
		moveShip ();

	}

	void checkFire(){
		if (!firing) {
			firing = true;
			lastFireTime = Time.time;
			Instantiate (bulletToFire, transform.position, transform.rotation);
		} else if (Time.time - lastFireTime > fireCooldownTime) {
			firing = false;
		}
	}
	void moveShip() {
		transform.position = new Vector3( transform.position.x + speed.x * Time.deltaTime, transform.position.y + speed.y * Time.deltaTime, transform.position.z );

		Vector3 ViewportPosition = Camera.main.WorldToViewportPoint (transform.position);
		if (wrapScreen) {
			Vector3 newPos = transform.position;
			Vector3 wrapPositionZero = Camera.main.ViewportToWorldPoint (new Vector3(.01f, 0, 0));
			Vector3 wrapPositionOne = Camera.main.ViewportToWorldPoint (new Vector3(.99f, 0, 0));

			if (ViewportPosition.x > 1) {
				newPos = new Vector3 (wrapPositionZero.x, transform.position.y, transform.position.z);
			} else if (ViewportPosition.x < 0) {
				newPos = new Vector3 (wrapPositionOne.x, transform.position.y, transform.position.z);
			}
			transform.position = newPos;
			if (ViewportPosition.y > 1) {
				newPos = new Vector3 (transform.position.x, wrapPositionZero.y, transform.position.z);
			} else if (ViewportPosition.y < 0) {
				newPos = new Vector3 (transform.position.x, wrapPositionOne.y, transform.position.z);
			}
			transform.position = newPos;
		} else {
			if ((ViewportPosition.x > 1) || (ViewportPosition.x < 0)) {
				speed = new Vector2 (speed.x * -1, speed.y);
			}
			if ((ViewportPosition.y > 1) || (ViewportPosition.y < 0)) {
				speed = new Vector2 (speed.x, speed.y* -1);
			}
		}
	}
	void hit( float damage ) {
		SpriteRenderR.color = Color.red;
		StartCoroutine ("turnBackNormal");

		health -= damage;
//		Debug.Log ("Enemy HIT! Health Left: " + health);
		if (health < 0) {
			explode ();
		}
	}
	IEnumerator turnBackNormal () {
		yield return new WaitForSeconds (hitTime);
		SpriteRenderR.color = Color.white;
	}

	void explode() {
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.SendMessage ("hit", damageToPlayerShip);
		}
	}
}
