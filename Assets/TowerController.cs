using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private TowerTargetController targetController;

    void Awake() {
        targetController = GetComponent<TowerTargetController>();
    }

    void OnTriggerStay2D(Collider2D other) {
        targetController.Fire(other.transform);
    }

}
