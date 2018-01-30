using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class TowerBuilder : MonoBehaviour {

	public GameObject selectedTower;

	private Vector3 mousePosition;
	private GameObject placeholder;
	private SpriteRenderer sprite;
	private GameObject towerContainer;
	private AstarPath astarPath;
	private bool canBuild;

	void Awake() {
		towerContainer = GameObject.FindGameObjectWithTag(Tags.TOWER_CONTAINER);
		astarPath = GameObject.FindGameObjectWithTag(Tags.ASTAR).GetComponent<AstarPath>();
	}

	void Start() {
		UpdateMousePosition();
		var spriteObject = selectedTower.transform.GetChild(0).gameObject;
		placeholder = (GameObject) Instantiate(spriteObject, mousePosition, Quaternion.identity);
		placeholder.transform.SetParent(transform);
		sprite = placeholder.GetComponent<SpriteRenderer>();
	}

	void Update() {
		UpdateMousePosition();
		UpdatePlaceholderPosition();
		IsValidPosition(placeholder.transform.position);
		PaintTower(canBuild);
		if (Input.GetMouseButtonDown(0)) BuildTower();
    }

	void UpdateMousePosition() {
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

	float RoundToHalf(float v) {
        const float halfInverse = 1/0.5f;
		return (float) (Math.Round(v * halfInverse, MidpointRounding.AwayFromZero) / halfInverse);
	}

	void BuildTower() {
		if(!canBuild) return;
		var go = (GameObject) Instantiate(selectedTower, placeholder.transform.position, Quaternion.identity);
		go.transform.SetParent(towerContainer.transform);
		astarPath.Scan();
	}

	bool IsValidPosition(Vector3 position) {
		var hitCollider = Physics2D.OverlapBox(position, Vector2.one / 2, 0, LayerMask.GetMask("Towers"));
		canBuild = hitCollider == null;
		return canBuild;
	}

	void PaintTower(bool canBuild) {
		if(canBuild) sprite.color = Color.green;
		else sprite.color = Color.red;
	}

}
