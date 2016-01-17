using UnityEngine;
using System.Collections;

public class textScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Renderer>().sortingLayerName = "Foreground";
		gameObject.GetComponent<Renderer>().sortingOrder = 1;
	}
}
