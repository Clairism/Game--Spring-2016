using UnityEngine;
using System.Collections;

public class greenProjectile : Projectile {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		velocity = GameManager.greenProjectileVelocity + new Vector2( 
			Random.Range(-GameManager.greenProjectileVariance.x, GameManager.greenProjectileVariance.x), 
			Random.Range(-GameManager.greenProjectileVariance.y, GameManager.greenProjectileVariance.y)
		);
		glowSpeed = GameManager.greenProjectileGlowSpeed;
		damage = GameManager.greenProjectileDamage;
		//shotByEnemy = GameManager.redProjectileShotByEnemy;
		loadedValues = true;
	}
}
