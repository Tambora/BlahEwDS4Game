using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class introTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			gameObject.SetActive(false);
//			GameObject.Find("locationText").GetComponent<Text>();
//			Debug.
		}
	}

	void OnMouseDown(){
		Destroy(GameObject.Find("introScreen"));
		if (PlayerPrefs.GetInt ("Count") == 0) {
			GameObject tut = Instantiate (Resources.Load ("TutorialBox")) as GameObject;
		}
	}
}
