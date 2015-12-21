using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class failyPassy : MonoBehaviour {
	public bool semesterEnd;
	private System.DateTime epochStart;
	private int currentSemester;
	private int day;

	CreateStudent createStudent;

	GameObject popup;

	List<GameObject> fails;
	List<GameObject> grads;

	// Use this for initialization
	void Start () {
		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		day = 3;
		currentSemester = 0;

		createStudent = GetComponent<CreateStudent> ();
		StudentData studentData = GetComponent<StudentData> ();

		fails = new List<GameObject> ();
		grads = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		int systemTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

		if (currentSemester < systemTime / day) {
			currentSemester = (int)systemTime / day;
			reportCard();
		}
	}

	void reportCard()
	{
		string fail = "FAILED STUDENTS\n";
		string pass = "NEW GRADUATES!\n";

		int failsCount = 0;
		int gradsCount = 0;

		foreach (GameObject x in createStudent.students) {
			if(x){
				StudentData data = x.GetComponent<StudentData>();
			

			if( data.studentState == 3)
			{
				fail += data.name + "\n";
				fails.Add(x);
				failsCount++;
			}
			else if( data.studentState == 4)
			{
				pass += data.name + "\n";
				grads.Add(x);
				gradsCount++;
			}
			}
		}

		if (!GameObject.Find ("Popup(Clone)") && !GameObject.Find ("EncounterBox(Clone)") ) {
			if (failsCount > 0) {

				popup = Instantiate (Resources.Load ("gratzPop")) as GameObject;
				popup.GetComponentsInChildren<TextMesh> () [0].text = fail;

				foreach (GameObject x in fails) {
					Destroy (x);
				}
			}

			if (gradsCount > 0) {
				popup = Instantiate (Resources.Load ("gratzPop")) as GameObject;
				popup.GetComponentsInChildren<TextMesh> () [0].text = pass;

				foreach (GameObject x in grads) {
					Destroy (x);

				}
			}
		}

	}
}
