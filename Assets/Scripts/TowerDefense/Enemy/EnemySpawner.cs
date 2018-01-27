using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public float timeBetween;
	public GameObject enemyContainer;

	public IEnumerator Spawn(EnemyWave wave) {
		foreach(GameObject enemy in wave) {
			((GameObject) Instantiate(enemy, transform.position, Quaternion.identity))
				.transform.SetParent(enemyContainer.transform);
			yield return new WaitForSeconds(timeBetween);
		}
	}

}
