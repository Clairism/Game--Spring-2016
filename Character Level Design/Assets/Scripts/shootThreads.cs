using UnityEngine;
using System.Collections;

public class shootThreads : playerControl {

	LineRenderer line;
	public int lengthOfLineRenderer = 5;


	// Use this for initialization
	void Start () {

		line = GetComponent<LineRenderer>();

		line.SetVertexCount(lengthOfLineRenderer);
	
	}
	
	// Update is called once per frame
//	public override void Update () {

//		Vector3 pos = new Vector3(posX, posY, 0);
//		line.SetPosition(shootTime, pos);

		/*
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		Vector3[] points = new Vector3[lengthOfLineRenderer];
		float t = Time.time;
		int i = 0;
		while (i < lengthOfLineRenderer) {
			points[i] = new Vector3(i * 0.5F, Mathf.Sin(i + t), 0);
			i++;
		}
		lineRenderer.SetPositions(points);
		*/
	
//	}
}
