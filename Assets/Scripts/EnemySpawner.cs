using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float timeBetween;
	public float amount;
	public GameObject enemy;

	private float timeToSpawn;

	void Awake() {
		StartCoroutine(Spawn());
	}

	public void NextWave() {

	}

	IEnumerator Spawn() {
		for (int i = 0; i < amount; i++) {
			Instantiate(enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(timeBetween);
		}
	}

}
