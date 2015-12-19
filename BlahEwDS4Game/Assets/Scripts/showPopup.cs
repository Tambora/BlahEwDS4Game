using UnityEngine;
using System.Collections;

public class showPopup : MonoBehaviour {

	private GameObject newPopup;
	StudentData studentData;
	private float cgpaBar;
	main mainVar;
	bool gameState;

	// Use this for initialization
	void Start () {
		mainVar = GameObject.Find ("QUAD").GetComponent<main> ();
//		selectedStudent = this.name;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (!GameObject.Find ("Popup(Clone)") && !GameObject.Find ("Map(Clone)") && !GameObject.Find ("EncounterBox(Clone)") && !GameObject.Find ("gradList(Clone)") && !GameObject.Find ("gratzPop(Clone)")) {
			mainVar.selectedStudent = this.name; 
			Debug.Log (this);
			studentData = this.GetComponent<StudentData> ();
			if (mainVar.gameState) {
				newPopup = Instantiate (Resources.Load ("Popup"))as GameObject;
				newPopup.GetComponentsInChildren<TextMesh> () [1].text = studentData.name;
				newPopup.GetComponentsInChildren<TextMesh> () [2].text = studentData.major;
				newPopup.GetComponentsInChildren<TextMesh> () [0].text = "'" + studentData.tagline + "'";
				//			cgpaBar = studentData.CGPA;

				//			cgpaBar = (cgpaBar - 0) / (12 - 0) * (3 - 0) + 0;

				//			newPopup.GetComponentsInChildren<Transform> () [10].localScale = new Vector3 (cgpaBar, 3f, 3f);
//				newPopup.AddComponent<BoxCollider2D> ();       	
				newPopup.layer = 5;
//				newPopup.GetComponent<BoxCollider2D> ().isTrigger = true;
//				newPopup.GetComponent<BoxCollider2D> ().size = new Vector2 (5, 3);

				AudioSource[] audioSources = GameObject.Find ("Main Camera").GetComponents<AudioSource> ();
				audioSources [1].Play ();

				//			newPopup.AddComponent<AudioSource>();
				//			newPopup.GetComponent<AudioSource>().clip = Resources.Load("Audio/blip") as AudioClip;
				//			newPopup.GetComponent<AudioSource>().Play ();

//				newPopup.AddComponent<DestoryPopup> ();
				mainVar.gameState = false;
			}

		}
//		Debug.Log (this.name);

	}
}
