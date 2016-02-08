using UnityEngine;
using System.Collections;

public class LoadVaules : MonoBehaviour {

	void Awake () {
		GameManager.init ();
	}

	void Update() {
		if (GameManager.restartRequired) {
			StartCoroutine ("restart");
			GameManager.restartRequired = false;
		}
	}

	IEnumerator restart() {
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Level1");
	}
}
