using UnityEngine;
using System.Collections;

public class swatSpawner : MonoBehaviour {

	public GameObject obj;
	float spawnTime;
	float timer;

	float x;

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

		spawnTime = Random.Range(8, 15);
		//print (spawnTime);
		Instantiate (obj);	
	}
}
