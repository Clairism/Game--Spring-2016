using UnityEngine;
using System.Collections;

public class redProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.redProjectileVelocity + new Vector2( 
			Random.Range(-GameManager.redProjectileVariance.x, GameManager.redProjectileVariance.x), 
			Random.Range(-GameManager.redProjectileVariance.y, GameManager.redProjectileVariance.y)
		);
		glowSpeed = GameManager.redProjectileGlowSpeed;
		damage = GameManager.redProjectileDamage;
		//shotByEnemy = GameManager.redProjectileShotByEnemy;
		loadedValues = true;
	}
}
