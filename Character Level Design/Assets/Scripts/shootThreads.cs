using UnityEngine;
using System.Collections;

public class shootThreads : player {

	LineRenderer line;
	public int lengthOfLineRenderer = 5;


	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();

		line.SetVertexCount(lengthOfLineRenderer);
	
	}
	/*
	// Update is called once per frame
	public override void Update () {

		Vector3 pos = new Vector3(posX, posY, 0);
		line.SetPosition(shootTime, pos);

	
	}
	*/
}
