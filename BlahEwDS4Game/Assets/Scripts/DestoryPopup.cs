using UnityEngine;
using System.Collections;

public class DestoryPopup : MonoBehaviour {

	main mainVar;

	// Use this for initialization
	void Start () {
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Destroy (this.gameObject);
		Debug.Log ("destroy");
		mainVar.gameState = true;
	}
}
