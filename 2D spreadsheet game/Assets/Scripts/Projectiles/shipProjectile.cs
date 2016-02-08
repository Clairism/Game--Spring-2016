using UnityEngine;
using System.Collections;

public class shipProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.shipShotVelocity;
		glowSpeed = GameManager.shipShotGlowSpeed;
		damage = GameManager.shipShotDamage;
		shotByEnemy = false;
		loadedValues = true;
	}
}
