using UnityEngine;
using System.Collections;

public class KeshaEnemy : EnemyMovement {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		speed = GameManager.keshaEnemySpeed;
		health = GameManager.keshaEnemyHealth;
		fireCooldownTime = GameManager.keshaEnemyFireCooldownTime;
		wrapScreen = GameManager.keshaEnemyWrapScreen;
		damageToPlayerShip = GameManager.keshaEnemyRammingDamage;
	}
}
