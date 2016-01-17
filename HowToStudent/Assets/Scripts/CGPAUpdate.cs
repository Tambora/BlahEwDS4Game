using UnityEngine;
using System.Collections;

public class CGPAUpdate : MonoBehaviour {

	main mainSelected;
	StudentData studentSelect;
	private float cgpaBar;


	// Use this for initialization
	void Start () {
		mainSelected = GameObject.Find ("QUAD").GetComponent<main> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainSelected.selectedStudent != "temp") {
			if(GameObject.Find (mainSelected.selectedStudent)){
				studentSelect = GameObject.Find (mainSelected.selectedStudent).GetComponent<StudentData> ();
				cgpaBar = studentSelect.CGPA;
			
				cgpaBar = (cgpaBar - 0) / (12 - 0) * (3 - 0) + 0;
			
				gameObject.transform.localScale = new Vector3 (cgpaBar, 3f, 3f);
			}
		}
	}
}
