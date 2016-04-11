using UnityEngine;
using System.Collections;

public class killerSpawner : MonoBehaviour {

	public GameObject obj;
	float spawnTime;
	float timer;

	float y;
	float posX, posY;

	void Start () {
		spawnTime = 8;
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

		spawnTime = Random.Range(5, 12);

		y = Random.Range (-3, 3);

		Instantiate (obj, new Vector3(posX, posY + y, 4), Quaternion.identity);
	}
}
