using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private TowerTargetController targetController;

    void Awake() {
        targetController = GetComponentInChildren<TowerTargetController>();
    }

}
