using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		var go = other.gameObject;
		if(go.tag == Tags.ENEMY) go.GetComponent<EnemyController>().Die();
	}

}
