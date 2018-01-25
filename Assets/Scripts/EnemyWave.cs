using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave : IEnumerable {

	public List<GameObject> enemies;

    public IEnumerator GetEnumerator() {
        return enemies.GetEnumerator();
    }
}
