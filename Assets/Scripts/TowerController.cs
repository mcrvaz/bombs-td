using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private TowerTargetController targetController;

    void Awake() {
        targetController = GetComponentInChildren<TowerTargetController>();
    }

    void OnTriggerStay2D(Collider2D other) {
        var go = other.gameObject;
        if(go.tag == Tags.ENEMY) targetController.Fire(other.transform);
    }

}
