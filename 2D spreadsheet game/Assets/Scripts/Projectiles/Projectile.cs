using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;
	public float glowSpeed = 1;
	public float damage = 1;
	public bool shotByEnemy = true; //used to determine whether the player shoots it or the enemies shoot it
	public Vector2 projectileVariance = Vector2.zero;

	public bool loadedValues = false;

	SpriteRenderer SpriteRenderR;
	float timePassed = 0;

	void Start () {
		SpriteRenderR = GetComponent<SpriteRenderer> ();
		StartCoroutine ("loadValues");
	}

	void Update () {
		if (loadedValues) {
			transform.position = new Vector3 (transform.position.x + velocity.x * Time.deltaTime, transform.position.y + velocity.y * Time.deltaTime, transform.position.z);
			if (glowSpeed > 0) {
				SpriteRenderR.color = new Color (
					SpriteRenderR.color.r,
					SpriteRenderR.color.g,
					SpriteRenderR.color.b,
					(float)Math.Sin (timePassed) * .5f + .5f);
				timePassed += Time.deltaTime * (float)Math.PI * glowSpeed;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (shotByEnemy) {
			if (coll.gameObject.tag == "Player") {
				coll.gameObject.SendMessage ("hit", damage);
				Destroy (this.gameObject);
			}
		} else {
			if (coll.gameObject.tag == "Enemy") {
				coll.gameObject.SendMessage ("hit", damage);
				Destroy (this.gameObject);
			}
		}
	}
}
