using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;
	private WaveController waveController;

	void Awake() {
		waveController = FindObjectOfType<WaveController>();
		waveController.AddLiveEnemy(this);
		currentHealth = maxHealth;
		SetObjective();
	}

	private void SetObjective() {
		var objective = GameObject.FindGameObjectWithTag(Tags.OBJECTIVE);
		GetComponent<AIDestinationSetter>().target = objective.transform;
	}

	public void TakeDamage(float damage) {
		currentHealth -= damage;
		if(currentHealth <= 0) Die();
	}

	public void Die() {
		waveController.KillEnemy(this);
		Destroy(gameObject);
	}

}
