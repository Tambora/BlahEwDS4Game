using UnityEngine;
using System.Collections;

public class goAwayMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("playerDot").GetComponent<SpriteRenderer>().enabled = false;
	}
}
