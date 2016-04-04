using UnityEngine;
using System.Collections;

public class waterSpawner : MonoBehaviour {

	public GameObject obj;
	float spawnTime;
	float timer;

	float y;

	void Start () {
		spawnTime = 10;
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

		spawnTime = Random.Range(10, 25);
		Instantiate (obj);
	}
}
