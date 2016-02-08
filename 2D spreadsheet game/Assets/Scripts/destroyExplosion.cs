using UnityEngine;
using System.Collections;

public class destroyExplosion : MonoBehaviour {
	void Start () {
		StartCoroutine ("destroyAfterDuration");
	}
	IEnumerator destroyAfterDuration() {
		ParticleSystem ps = this.GetComponent<ParticleSystem> ();
		yield return new WaitForSeconds (ps.duration);
		Destroy (gameObject);
	}
}
