using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;
	public float damage;
	public Transform target { get; set; }

    private Transform startMarker;
    private float startTime;
    private float journeyLength;

    void Awake() {
		startMarker = transform;
	}

	void Start() {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, target.position);
    }

	void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        if(target == null) Die();
        transform.position = Vector3.Lerp(startMarker.position, target.position, fracJourney);
    }

    void Die() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        var go = other.gameObject;
        if(go.tag == Tags.ENEMY) {
            go.GetComponent<EnemyController>().TakeDamage(damage);
            Die();
        }
    }

}
