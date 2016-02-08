using UnityEngine;
using System.Collections;

public class BillEnemy : EnemyMovement {
	IEnumerator loadValues() {
		while (!GameManager.isLoaded) {
			yield return null;
		}
		speed = GameManager.billEnemySpeed;
		health = GameManager.billEnemyHealth;
		fireCooldownTime = GameManager.billEnemyFireCooldownTime;
		wrapScreen = GameManager.billEnemyWrapScreen;
		damageToPlayerShip = GameManager.billEnemyRammingDamage;
	}
}
