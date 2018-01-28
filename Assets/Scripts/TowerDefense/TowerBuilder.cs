using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerBuilder : MonoBehaviour {

	public GameObject selectedTower;

	private Vector3 mousePosition;
	private GameObject placeholder;

	void Start() {
		UpdateMousePosition();
		placeholder = (GameObject) Instantiate(selectedTower, mousePosition, Quaternion.identity);
		placeholder.transform.SetParent(transform);
	}

	void Update() {
		UpdateMousePosition();
		UpdatePlaceholderPosition();
    }

	void UpdateMousePosition() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

    private float RoundToHalf(float v) {
        const float half = 0.5f;
        float integerPart = (float) Math.Truncate(v);
        return integerPart > 0 ? (integerPart + half):(integerPart - half);
    }

	void UpdatePlaceholderPosition() {
		if(placeholder != null) {
			placeholder.transform.position = new Vector3(
				RoundToHalf(mousePosition.x),
				RoundToHalf(mousePosition.y),
				0
			);
		}
	}
}
