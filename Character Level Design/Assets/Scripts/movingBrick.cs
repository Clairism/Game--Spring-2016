using UnityEngine;
using System.Collections;

public class movingBrick : MonoBehaviour {

//	Transform startPoint, endPoint;
//	public float percentage = .2f;
	public float speed;
	public float distance;
//	private int direction = -1;
	float posX;

	void Start () {

//		startPoint = GameObject.Find("start").transform;
//		endPoint = GameObject.Find("end").transform;
		//direction = 1;

		posX = transform.position.x;
//		posY = transform.position.y;

	}

	// Update is called once per frame
	void Update () {

		//transform.position = Vector2.Lerp(startPoint.position, endPoint.position, percentage);

		transform.position = new Vector3(posX + Mathf.PingPong(Time.time*speed, distance), transform.position.y, transform.position.z);
		/*
		speed = Mathf.Max(speed, .000001f); //don't divide by zero

		percentage += Time.deltaTime/speed * direction;

		if ((percentage>1) || (percentage < 0)) {
			direction = -direction;
			percentage = Mathf.Clamp(percentage, 0, 1);
		}	
		*/
	}
		
}
