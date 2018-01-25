using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public List<EnemyWave> waves;

	private List<EnemyController> enemiesAlive;
	private IEnumerator<EnemyWave> waveEnumerator;
	private EnemySpawner spawner;

	void Awake() {
		enemiesAlive = new List<EnemyController>();
		waveEnumerator = waves.GetEnumerator();
		spawner = FindObjectOfType<EnemySpawner>();
		NextWave();
	}

	public void NextWave() {
		if(!waveEnumerator.MoveNext()) return;
		StartCoroutine(spawner.Spawn(waveEnumerator.Current));
	}

	public void AddLiveEnemy(EnemyController enemy) {
		this.enemiesAlive.Add(enemy);
	}

	public void KillEnemy(EnemyController enemy) {
		this.enemiesAlive.Remove(enemy);
		if(enemiesAlive.Count == 0) NextWave();
	}

}
