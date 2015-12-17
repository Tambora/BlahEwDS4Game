using UnityEngine;
using System.Collections;

public class OpenTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {
		Debug.Log ("DRAGGING");
        GameObject tut = Instantiate(Resources.Load("TutorialBox")) as GameObject;
    }
}
