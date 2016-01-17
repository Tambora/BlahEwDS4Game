using UnityEngine;
using System.Collections;

public class resetPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameObject tut = Instantiate (Resources.Load ("resetConfirm")) as GameObject;
		AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
		audioSources[1].Play();
	}
}
