using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	Animator animator;

	public float shootTime;
	public float posX, posY;

	float xSpeed;
	float ySpeed;
	float playerSpeed;

	Rigidbody2D rb;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

		playerSpeed = 5;

		rb = GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	public virtual void Update () {

		Moving ();
		changeStates ();

//		ySpeed = Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
//		transform.Translate (Vector3.right * ySpeed);

		posX = GetComponent<Transform> ().position.x;
		posY = GetComponent<Transform> ().position.y;

	}

	void changeStates(){

		if (Input.GetKey(KeyCode.Space)) {
//			transform.eulerAngles= new Vector3(45, 0, 0);
			//transform.Translate (Vector3.up * 0.2f);
			//rb.AddForce(Vector2.down * 0.2f);
			animator.SetBool ("jump", true);
		}else {
//			transform.eulerAngles= new Vector3(-45, 0, 90);
			//transform.position = new Vector3(0, 0, 0);

			animator.SetBool ("jump", false);

		}

		if (Input.GetKey (KeyCode.Z)) {
			animator.SetBool ("shoot", true);
			//animator.SetTrigger("shoot2");

			shootTime += Time.deltaTime;
			//			Invoke ("finishShoot", shootTime);
		}else {
			animator.SetBool ("shoot", false);
			shootTime = 0f;
		}

		if(Input.GetKey(KeyCode.P)){
			animator.SetBool ("die", true);

		}

	}
	
	void Moving(){
	
		xSpeed = Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime;
		transform.Translate (Vector3.down * xSpeed);
	
	}

	void finishShoot(){
		animator.SetBool ("shoot", false);
	}
}
