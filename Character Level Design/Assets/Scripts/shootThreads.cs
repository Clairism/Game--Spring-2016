using UnityEngine;
using System.Collections;

public class shootThreads : MonoBehaviour {

	LineRenderer line;
	//public int lengthOfLineRenderer = 5;

	Vector2 player;
	GameObject tip;

	float pct = 0;
	bool hit;

	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();
		//line.SetVertexCount(lengthOfLineRenderer);

		player = GameObject.Find ("Player").transform.position;
		tip = GameObject.Find ("tip");

		//line.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
		hit = tip.GetComponent<threadTip> ().hit;

		line.SetPosition (0, new Vector2 (player.x, player.y));
		line.SetPosition (1, new Vector2 (player.x + pct, player.y + pct));

		tip.transform.position = new Vector2 (player.x + pct, player.y + pct);

		if (!hit) {
			
			pct += 0.05f;
			Invoke ("destroy", 2.5f);

		} else{
			Invoke ("destroy", 0.6f);
		}

	}
	void destroy(){
		Destroy (gameObject);
	}

}
