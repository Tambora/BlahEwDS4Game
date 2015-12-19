using UnityEngine;
using System.Collections;

public class soundButton : MonoBehaviour {

	AudioSource[] audio;
	
	// Use this for initialization
	void Start () {
		audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource> ();
		if (GameObject.Find ("UI_Settings_SoundsON")) {
			if (audio[1].mute) {
				GameObject.Find ("UI_Settings_SoundsON").GetComponent<SpriteRenderer> ().enabled = false;
				GameObject.Find ("UI_Settings_SoundsOFF").GetComponent<SpriteRenderer> ().enabled = true;
			} else {
				GameObject.Find ("UI_Settings_SoundsON").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("UI_Settings_SoundsOFF").GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown(){
		if (audio[1].mute) {
			audio[1].mute = false;
			audio[2].mute = false;
			audio[3].mute = false;
			GameObject.Find("UI_Settings_SoundsON").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("UI_Settings_SoundsOFF").GetComponent<SpriteRenderer>().enabled = false;
		} else {
			audio[1].mute = true;
			audio[2].mute = true;
			audio[3].mute = true;
			GameObject.Find("UI_Settings_SoundsON").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("UI_Settings_SoundsOFF").GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
