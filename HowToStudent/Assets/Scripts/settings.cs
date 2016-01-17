using UnityEngine;
using System.Collections;

public class settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(GameObject.Find("Map(Clone)")){
			Destroy(GameObject.Find("Map(Clone)"));
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		}
		if (!GameObject.Find ("SettingsMenu(Clone)") && !GameObject.Find ("Popup(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gradList(Clone)") && !GameObject.Find ("gratzPop(Clone)") && !GameObject.Find ("TutorialBox(Clone)")) {
			GameObject tut = Instantiate (Resources.Load ("SettingsMenu")) as GameObject;
			AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
			audioSources[1].Play();
		}
	}
}
