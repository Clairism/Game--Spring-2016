using UnityEngine;
using System.Collections;

public class deathZone : MonoBehaviour {
	void Start() {
		transform.position = new Vector3 (0, 1, 0);	
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Projectile") {
			Destroy (other.gameObject);
		}
	}
}
