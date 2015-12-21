using UnityEngine;
using System.Collections;

public class DestoryPopup : MonoBehaviour {

	main mainVar;
	AudioSource audioSource;
	AudioClip audioClip;



	// Use this for initialization
	void Start () {
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
//		audioSource = gameObject.AddComponent<AudioSource> ();
//		audioSource.clip = Resources.Load ("Audio/8-bit-noise") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
		audioSources[2].Play();

		Destroy (this.gameObject);
		Debug.Log ("destroy");
		mainVar.gameState = true;
	}
}
