using UnityEngine;
using System.Collections;

public class yellowProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.yellowProjectileVelocity + new Vector2( 
			Random.Range(-GameManager.yellowProjectileVariance.x, GameManager.yellowProjectileVariance.x), 
			Random.Range(-GameManager.yellowProjectileVariance.y, GameManager.yellowProjectileVariance.y)
		);
		glowSpeed = GameManager.yellowProjectileGlowSpeed;
		damage = GameManager.yellowProjectileDamage;
		//shotByEnemy = GameManager.redProjectileShotByEnemy;
		loadedValues = true;
	}
}
