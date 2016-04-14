using UnityEngine;
using System.Collections;

public class foodSpawner : MonoBehaviour {
	
	public GameObject obj1, obj2;
	float num;

	float spawnTime;
	float timer;

	float y;
	float posX, posY;

	void Start () {
		num = 1;

		spawnTime = 0.5f;
		timer = 0;

		posX = transform.position.x;
		posY = transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >= spawnTime){
			Invoke ("spawn", 0.1f);
			timer = 0;
		}
	}

	void spawn(){
		num = Random.Range (0f,1f);
		spawnTime = Random.Range(2f, 5f);

		y = Random.Range (-2, 2);

		if (num >= 0.3f) {
			Instantiate (obj1, new Vector3(posX, posY + y, 4), Quaternion.identity);
		} else {
			Instantiate (obj2, new Vector3(posX, posY + y, 4), Quaternion.identity);
		}
		
	
	}
}
