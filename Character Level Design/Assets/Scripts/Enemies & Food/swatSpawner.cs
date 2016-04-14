using UnityEngine;
using System.Collections;

public class swatSpawner : MonoBehaviour {

	public GameObject obj;
	public int maxTime, minTime;
	float spawnTime;
	float timer;

	float pos;

	float x;

	void Start () {
		spawnTime = 2;
		timer = 0;
		pos = transform.position.x;

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

		spawnTime = Random.Range(4, 8);
		//print (spawnTime);
		Instantiate (obj, new Vector3(pos, 6.0f, 4), Quaternion.identity);

	}
}
