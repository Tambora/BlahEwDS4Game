using UnityEngine;
using System.Collections;

public class musicButton : MonoBehaviour {

	AudioSource[] audio;

	// Use this for initialization
	void Start () {
		audio = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource> ();
		if (GameObject.Find ("UI_Settings_MusicON")) {
			if (audio[0].mute) {
				GameObject.Find ("UI_Settings_MusicON").GetComponent<SpriteRenderer> ().enabled = false;
				GameObject.Find ("UI_Settings_MusicOFF").GetComponent<SpriteRenderer> ().enabled = true;
			} else {
				GameObject.Find ("UI_Settings_MusicON").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("UI_Settings_MusicOFF").GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		if (audio[0].mute) {
			audio[0].mute = false;
			GameObject.Find("UI_Settings_MusicON").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("UI_Settings_MusicOFF").GetComponent<SpriteRenderer>().enabled = false;
		} else {
			audio[0].mute = true;
			GameObject.Find("UI_Settings_MusicON").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("UI_Settings_MusicOFF").GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
