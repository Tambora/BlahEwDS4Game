using UnityEngine;
using System.Collections;

public class ToMap : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled = true;
		GameObject.Find("playerDot").GetComponent<SpriteRenderer>().enabled = true;
	}
}
