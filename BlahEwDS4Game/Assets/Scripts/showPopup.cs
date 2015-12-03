using UnityEngine;
using System.Collections;

public class showPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Debug.Log ("popup");
		if(GameObject.Find("UI_StudentInfoBox").GetComponent<SpriteRenderer>().enabled == false){
			GameObject.Find("UI_StudentInfoBox").GetComponent<SpriteRenderer>().enabled = true;
		}else{
			GameObject.Find("UI_StudentInfoBox").GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
