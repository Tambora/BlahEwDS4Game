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
		if (GameObject.Find ("SettingsMenu(Clone)") == null) {
			GameObject tut = Instantiate (Resources.Load ("SettingsMenu")) as GameObject;
		} else {
			Destroy(GameObject.Find("SettingsMenu(Clone)"));
		}
//		if(GameObject.Find("UI_Settings").GetComponent<SpriteRenderer>().enabled == false){
//			GameObject.Find("UI_Settings").GetComponent<SpriteRenderer>().enabled = true;
//			GameObject.Find("UI_Settings_ShowTutorial").GetComponent<SpriteRenderer>().enabled = true;
//		}else{
//			GameObject.Find("UI_Settings").GetComponent<SpriteRenderer>().enabled = false;
//			GameObject.Find("UI_Settings_ShowTutorial").GetComponent<SpriteRenderer>().enabled = false;
//		}
	}
}
