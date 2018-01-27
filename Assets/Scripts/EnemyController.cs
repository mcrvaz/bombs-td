using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;
	private WaveController waveController;

	void Awake() {
		waveController = FindObjectOfType<WaveController>();
		// waveController.AddLiveEnemy(this);
	}

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		if(currentHealth <= 0) Die();
	}

	void Die() {
		waveController.KillEnemy(this);
		Destroy(gameObject);
	}

}
