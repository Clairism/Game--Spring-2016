using UnityEngine;
using System.Collections;

public class killerSpawner : MonoBehaviour {

	public GameObject obj;
	float spawnTime;
	float timer;

	float y;

	void Start () {
		spawnTime = 8;
		timer = 0;
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

		spawnTime = Random.Range(5, 8);

		y = Random.Range (-3, 3);

		Instantiate (obj, new Vector3(10, y, 4), Quaternion.identity);
	}
}
