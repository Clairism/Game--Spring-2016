using UnityEngine;
using System.Collections;

public class shootThreads : MonoBehaviour {

	LineRenderer line;
	//public int lengthOfLineRenderer = 5;
	GameObject player;
	Vector2 playerPos;
	GameObject tip;

	float pct = 0;
	bool hit;

	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();
		//line.SetVertexCount(lengthOfLineRenderer);

		player = GameObject.Find ("Player");
		playerPos = player.transform.position;
		tip = GameObject.Find ("tip");

		//line.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
		hit = tip.GetComponent<threadTip> ().hit;

		line.SetPosition (0, new Vector2 (playerPos.x, playerPos.y));
		line.SetPosition (1, new Vector2 (playerPos.x + pct, playerPos.y + Mathf.Abs(pct)));

		tip.transform.position = new Vector2 (playerPos.x + pct, playerPos.y + pct);

		if (!hit) {
			//if (!player.GetComponent<SpriteRenderer> ().flipY) {
				pct += 0.05f;
//			} else {
//				pct -= 0.05f;
//			}
			Invoke ("destroy", 1.8f);

		} else{
			Invoke ("destroy", 0.6f);
		}

	}
	void destroy(){
		Destroy (gameObject);
	}

}
