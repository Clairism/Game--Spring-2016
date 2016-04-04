using UnityEngine;
using System.Collections;

public class shootThreads : MonoBehaviour {

	LineRenderer line;
	//public int lengthOfLineRenderer = 5;

	Vector3 player;
	Vector3 grab;


	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();

		//line.SetVertexCount(lengthOfLineRenderer);
		player = GameObject.Find ("Player").transform.position;
		grab = GameObject.FindGameObjectWithTag ("grab").transform.position;

	}
	// Update is called once per frame
	void Update () {

		line.SetPosition (0, new Vector3(player.x, player.y, player.z));

		if((grab.x - player.x) <= 2.5f ){
			
			line.SetPosition (1, new Vector3(grab.x, grab.y, grab.z));

			Invoke ("destroy", 3f);


		}else{
			line.SetPosition (1, new Vector3(player.x + 1f, player.y + 1f, player.z));

			Invoke ("destroy", 1f);
		}
	
	}

	void destroy(){
		Destroy (gameObject);
	}

}
