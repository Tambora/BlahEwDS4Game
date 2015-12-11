using UnityEngine;
using System.Collections;

public class colourTexxt : MonoBehaviour {

	main mainSelected;
	StudentData studentSelect;


	// Use this for initialization
	void Start () {
		mainSelected = GameObject.Find ("QUAD").GetComponent<main> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainSelected.selectedStudent != "temp") {
			studentSelect = GameObject.Find (mainSelected.selectedStudent).GetComponent<StudentData> ();
			if (studentSelect.studentState == 1) {
				gameObject.GetComponent<TextMesh> ().color = new Color (255, 255, 0);
			}else{
				gameObject.GetComponent<TextMesh> ().color = new Color (255, 255, 255);
			}
		}
	}
}
