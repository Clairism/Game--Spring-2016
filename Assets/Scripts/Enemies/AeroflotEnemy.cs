using UnityEngine;
using System.Collections;

public class AeroflotEnemy : EnemyMovement {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		speed = GameManager.aeroflotEnemySpeed;
		health = GameManager.aeroflotEnemyHealth;
		fireCooldownTime = GameManager.aeroflotEnemyFireCooldownTime;
		wrapScreen = GameManager.aeroflotEnemyWrapScreen;
		damageToPlayerShip = GameManager.aeroflotEnemyRammingDamage;
	}
}
