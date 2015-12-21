using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class resetGame : MonoBehaviour {

	CreateStudent createStudent;


	// Use this for initialization
	void Start () {
		createStudent = GameObject.Find ("GameObject").GetComponent<CreateStudent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		PlayerPrefs.DeleteAll();
		Debug.Log ("playerprefs");
		foreach (GameObject x in createStudent.students) {
			Destroy(x);
		}
//		Destroy (GameObject.Find ("Student0"));
		Debug.Log ("gameobjects");
		Destroy(GameObject.Find("SettingsMenu(Clone)"));
		Destroy(GameObject.Find("resetConfirm(Clone)"));	
	}
}
