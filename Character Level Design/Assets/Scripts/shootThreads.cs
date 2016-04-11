using UnityEngine;
using System.Collections;

public class shootThreads : MonoBehaviour {

	LineRenderer line;
	//public int lengthOfLineRenderer = 5;

	Vector2 player;
	Vector2 grab;

	float pct;
	GameObject tip;

	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();
		tip = GameObject.Find ("tip");
		//line.SetVertexCount(lengthOfLineRenderer);
		player = GameObject.Find ("Player").transform.position;

		//line.enabled = false;
	}
	// Update is called once per frame
	void Update () {


		line.SetPosition (0, new Vector2 (player.x, player.y));

		pct += 0.03f;

		line.SetPosition (1, new Vector2 (player.x + pct, player.y + pct));

		tip.transform.position = new Vector2 (pct, pct);

		if (tip.GetComponent<threadTip> ().hit) {
			Invoke("destroy", 0.2f);
		}
	}
	void destroy(){
		Destroy (gameObject);
	}

}
