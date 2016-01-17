using UnityEngine;
using System.Collections;

public class tutorialNext : MonoBehaviour {

	int tutorialImg;

	// Use this for initialization
	void Start () {
		tutorialImg = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (tutorialImg != 5) {
			Destroy (GameObject.Find ("Tutorial-" + tutorialImg));
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		} else {
			Destroy(this.transform.parent.gameObject);
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[2].Play();
		}
		tutorialImg++;
	}
}
