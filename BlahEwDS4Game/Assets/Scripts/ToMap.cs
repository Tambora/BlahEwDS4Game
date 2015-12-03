using UnityEngine;
using System.Collections;

public class ToMap : MonoBehaviour {

	public static Mesh viewedModel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if(GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled == false){
			GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("playerDot").GetComponent<SpriteRenderer>().enabled = true;
		}else{
			GameObject.Find("CampusMap").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("playerDot").GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
