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
		if (GameObject.Find ("SettingsMenu(Clone)")) {
			Destroy(GameObject.Find("SettingsMenu(Clone)"));
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		}
		if (!GameObject.Find ("Popup(Clone)") && !GameObject.Find ("Map(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gradList(Clone)") && !GameObject.Find ("gratzPop(Clone)")) {
			GameObject tut = Instantiate (Resources.Load ("Map")) as GameObject;
//			GameObject.Find ("CampusMap").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("playerDot").GetComponent<SpriteRenderer> ().enabled = true;
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		}
	}
}
