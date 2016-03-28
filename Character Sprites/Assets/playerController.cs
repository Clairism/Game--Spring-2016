using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space)) {
			//jump = true;
			animator.SetBool ("jump", true);
		}else {
			animator.SetBool ("jump", false);

		}


		if (Input.GetKey("1")) {
			animator.SetBool ("walk", true);
		}else {
			animator.SetBool ("walk", false);

		}

		if (Input.GetKey("2")) {
			animator.SetBool ("talk", true);
		}else {
			animator.SetBool ("talk", false);

		}

		if (Input.GetKey("3")) {
			animator.SetBool ("transform1", true);
		}else {
			animator.SetBool ("transform1", false);

		}

		if (Input.GetKey("4")) {
			animator.SetBool ("roll", true);
		}else {
			animator.SetBool ("roll", false);

		}

		if (Input.GetKey("5")) {
			animator.SetBool ("transform2", true);
		}else {
			animator.SetBool ("transform2", false);

		}

		if (Input.GetKey("6")) {
			animator.SetBool ("changeFace", true);
		}else {
			animator.SetBool ("changeFace", false);

		}

		if (Input.GetKey("7")) {
			animator.SetBool ("elongate", true);
		}else {
			animator.SetBool ("elongate", false);

		}
			
	}
}
