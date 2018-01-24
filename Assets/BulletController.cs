using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;
	public Transform target { get; set; }
	private float damage { get; set; }

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
        transform.position = Vector3.Lerp(startMarker.position, target.position, fracJourney);
    }

}
