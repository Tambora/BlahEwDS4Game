using UnityEngine;
using System.Collections;

public class goAwayMap : MonoBehaviour {
	main mainVar;

	// Use this for initialization
	void Start () {
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (GameObject.Find ("SettingsMenu(Clone)")) {
			Destroy(GameObject.Find("SettingsMenu(Clone)"));
		}
		Destroy(GameObject.Find("Map(Clone)"));
//		GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Find("playerDot").GetComponent<SpriteRenderer>().enabled = false;
		AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
		audioSources[1].Play();
		mainVar.scrollDistance = 0;
	}
}
