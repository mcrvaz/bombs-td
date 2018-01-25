using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		if(currentHealth <= 0) Die();
	}

	void Die() {
		Destroy(gameObject);
	}

}
