using UnityEngine;
using System.Collections;

public class introTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			gameObject.SetActive(false);
		}
	}

	void OnMouseDown(){

	}
}
