﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarWaveController : MonoBehaviour {

	public GameObject sonarParticle;
	List<GameObject> sonarParticles;
	public int particleResolution;
	public float timeToFadeOut;
	public float speed;
	public float startAngle;
	public float endAngle;
	public float particleSpotlightAngle;
	public Color color;

	float t;

	void Start () {
		sonarParticles = new List<GameObject>();
		float angleIncrement = (endAngle - startAngle) / particleResolution;
		for (float curAngle = startAngle; curAngle < endAngle; curAngle+=angleIncrement) {
			GameObject newParticle = Instantiate(sonarParticle, gameObject.transform.position, Quaternion.identity, gameObject.transform) as GameObject;
			SonarParticleController pc = newParticle.GetComponent<SonarParticleController>();
			
			Vector3 dir = Quaternion.AngleAxis(curAngle, Vector3.forward) * Vector3.right;
			pc.light.spotAngle = particleSpotlightAngle;
			pc.timeToFade = timeToFadeOut;
			pc.velocity = speed * dir;
			pc.color = color;
			sonarParticles.Add(newParticle);
		}
	}

	void Update() {
		if (t > timeToFadeOut)
			Destroy(gameObject);
		t += Time.deltaTime;
	}
}
