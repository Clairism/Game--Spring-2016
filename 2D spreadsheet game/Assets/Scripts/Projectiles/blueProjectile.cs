using UnityEngine;
using System.Collections;

public class blueProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.blueProjectileVelocity + new Vector2( 
			Random.Range(-GameManager.blueProjectileVariance.x, GameManager.blueProjectileVariance.x), 
			Random.Range(-GameManager.blueProjectileVariance.y, GameManager.blueProjectileVariance.y)
		);
		glowSpeed = GameManager.blueProjectileGlowSpeed;
		damage = GameManager.blueProjectileDamage;
		loadedValues = true;
	}
}
