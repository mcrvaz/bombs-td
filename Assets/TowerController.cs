using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private TowerTargetController targetController;

    void Awake() {
        targetController = GetComponent<TowerTargetController>();
    }

    void OnCollisionStay2D(Collision2D other){
        targetController.Fire(other.transform);
    }

}
