﻿using UnityEngine;

public class TargetManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0) {
			GameObject.Destroy(gameObject);
		}
	}
}
