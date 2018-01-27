using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		var go = other.gameObject;
		if(go.tag == Tags.ENEMY) go.GetComponent<EnemyController>().Die();
	}

}
