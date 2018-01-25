using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float timeBetween;

	public IEnumerator Spawn(EnemyWave wave) {
		foreach(GameObject enemy in wave) {
			Instantiate(enemy, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(timeBetween);
		}
	}

}
