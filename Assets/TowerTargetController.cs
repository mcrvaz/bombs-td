using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargetController : MonoBehaviour {

	public GameObject bullet;
	public float damage;
	public float cooldown;

	private float cooldownLeft { get; set; }

	void Awake() {
		cooldownLeft = cooldown;
	}

	void Update() {
		cooldownLeft -= Time.deltaTime;
	}

	public void Fire(Transform target) {
		if(cooldownLeft <= 0) {
			var bc = ((GameObject) Instantiate(bullet, transform.position, Quaternion.identity))
				.GetComponent<BulletController>();
			bc.target = target;
			cooldownLeft = cooldown;
		}
	}
}
