using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	float posX, posY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			
		posX = GameObject.Find ("Player").transform.position.x;

			transform.position = new Vector3 (posX - 1f, 0, 1.6f);
	}
}
