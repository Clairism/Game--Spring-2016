using UnityEngine;
using System.Collections;

public class carEnemy : EnemyMovement {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		speed = GameManager.carEnemySpeed;
		health = GameManager.carEnemyHealth;
		fireCooldownTime = GameManager.carEnemyFireCooldownTime;
		wrapScreen = GameManager.carEnemyWrapScreen;
		damageToPlayerShip = GameManager.carEnemyRammingDamage;
	}
}
