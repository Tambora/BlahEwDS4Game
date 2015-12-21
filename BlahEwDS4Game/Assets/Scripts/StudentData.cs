using UnityEngine;
using System.Collections;

public class StudentData : MonoBehaviour {
	
	public string name;
	public string tagline;
	public string major;
	public float CGPA;
	
//	private float lastTime = 0f;
//	private float dragDelay = 1f;
//	private float distance;
//	private bool dragging = false;
	
	private float DECAY_RATE = 0.09375f;
	private float HW_DECAY = -0.33f;
	private float S_DECAY = -0.00625f;
	
	public int studentState; // (0=neutral, 1=study, 2=hw, 3 = fail, 4 = graduated)
	private int numUpdates;
	
	public int studyStart;
	public int hwStart;
	private int systemTime;
	private int inactiveTime;
	public int lastUpdate;
    
	public int enrollSemester;
	public int currentSemester;
    
	System.DateTime epochStart;

	private int half = 1; // Half hour
	private int full = 2; // Full hour
	private int day = 12; // Semester

	public bool semesterEnd;

	
	// Use this for initialization
	void Start () { //Saving Shit
		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		PlayerPrefs.SetString (this.gameObject.transform.name + " name", name);
		PlayerPrefs.SetString (this.gameObject.transform.name + " tagline", tagline);
		PlayerPrefs.SetString (this.gameObject.transform.name + " major", major);
		PlayerPrefs.SetInt (this.gameObject.transform.name + " ES", enrollSemester);
		
		
    }
	
	// Update is called once per frame
	void Update () {
		
		 systemTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
        
        if (currentSemester + enrollSemester < systemTime/day && studentState < 3) { // this runs when the semester changes and the student is in uni

            currentSemester = (int)(systemTime - enrollSemester*day)/day;
            int semesterUpdate = (currentSemester + enrollSemester) * day;
            
			if (hwStart + full*3 > semesterUpdate) { // This runs when the student is doing homework
				int hwUpdates = (int)(semesterUpdate - (hwStart + full*3)/half); // THIS IS THE NUMBER OF HOMEWORK UPDATES OR TICKS THAT HAPPENED SINCE THE LAST UPDATE
																				 // NUMBEROFUPDATES SHOWS UP ALL OVER, I'M NOT WRITINFG THIS COMMENT AGAIN
				inactiveTime = systemTime - (hwStart+full*3);					// INACTIVE TIME SINCE THE LAST UPDATE 
				numUpdates = (int)((inactiveTime - full*8)/half);				// NORMAL NON-HW TICKS
				
                if (CGPA + hwUpdates * HW_DECAY - numUpdates * DECAY_RATE < 3){ // THE DECAY MATH < 3 CGPA == fail
                    studentState = 3; 
					Debug.Log("THIS IS HW");
                }
            }
            
			else if (studyStart + full*8 > semesterUpdate) {  // This runs when the student is studying
				int studyUpdates = (int)(semesterUpdate - (studyStart + full*8)/half);
				inactiveTime = systemTime - (studyStart+full*8);
				numUpdates = (int)((inactiveTime - full*8)/half);
				if (CGPA + studyUpdates * S_DECAY - numUpdates * DECAY_RATE < 3) { // LOOK ABOVE
                    studentState = 3;
					Debug.Log("THIS IS NOT HW");

                }
            }
            
            else { // Runs when the student is wasting time(STATE = 0)
                inactiveTime = systemTime - semesterUpdate;
				numUpdates = (int)(inactiveTime/half);
				if (CGPA + numUpdates * DECAY_RATE < 3){
                    studentState = 3;
					Debug.Log(CGPA - numUpdates * DECAY_RATE);

                }
            }
			if (currentSemester > 7){
				studentState = 4; // Congrats

			}
			PlayerPrefs.SetInt(this.gameObject.transform.name + " studentState", studentState);
			PlayerPrefs.Save();
			Debug.Log("This Happened.");
		}

		// The following code is weird. Proceed with caution.
		// It checks if the student is currently studying
			// If yes, it checks if 8 hours(full) have passed.
				// If yes It adds the cgpa achieved after 8 hours of studying and the cgpa lost  after done studying and wasting time after
				// If no, It just adds the cgpa achieved from the amount of studying done and sets the student state to studying.
			// If no, check for homework. It works the same.
		// Homework
		// Neutral


		if (systemTime - lastUpdate > half && studentState < 3) { // This runs every half (see variable above)
			if (studyStart > lastUpdate) { // If the student begins to study after the last update
				inactiveTime = systemTime - studyStart;
				if(inactiveTime > full*8) { 
					numUpdates = (int)((inactiveTime - full*8)/half);
					CGPA = 0.1f + CGPA - numUpdates * DECAY_RATE; // This actually changes the CGPA
					studentState = 0;
				}
				else {
					numUpdates = (int)(inactiveTime/half);
					CGPA = CGPA - numUpdates * S_DECAY;
					studentState = 1;
				}
				lastUpdate = ((int)(inactiveTime/half))*half + studyStart; 
			}
			
			else if (hwStart > lastUpdate) { // HW after the last update
				inactiveTime = systemTime - hwStart;
				if(inactiveTime > full*3) {
					numUpdates = (int)((inactiveTime - full*3)/half);
					CGPA = 2 + CGPA - numUpdates * DECAY_RATE; // Decay and logic and stuff
					studentState = 0;
				}
				else {
					numUpdates = (int)(inactiveTime/half);
					CGPA = CGPA - numUpdates * HW_DECAY;
					studentState = 2;
				}
				lastUpdate = ((int)(inactiveTime/half))*half + hwStart; 
			}
			else if (studyStart + full*8 > lastUpdate){
				studentState = 1;
				inactiveTime = systemTime - lastUpdate;
				numUpdates = (int)(inactiveTime/half);
				CGPA = CGPA - numUpdates * S_DECAY;
				lastUpdate = lastUpdate + numUpdates*half;
			}
			else if (hwStart + full*3 > lastUpdate){
				studentState = 2;
				inactiveTime = systemTime - lastUpdate;
				numUpdates = (int)(inactiveTime/half);
				CGPA = CGPA - numUpdates * HW_DECAY;
				lastUpdate = lastUpdate + numUpdates*half;
			}

			else {
				studentState = 0;
				inactiveTime = systemTime - lastUpdate;
				numUpdates = (int)(inactiveTime/half);
				CGPA = CGPA - numUpdates * DECAY_RATE;
				lastUpdate = lastUpdate + numUpdates*half;
			}
			if (CGPA > 12f) 
				CGPA = 12f; // Can't have more than 12 CGPA
			if (CGPA < 0) // You literally can't have such a low CGPA, but if you do, i got you
				CGPA = 0;
			PlayerPrefs.SetFloat( this.gameObject.transform.name + " CGPA", CGPA);
			PlayerPrefs.SetInt( this.gameObject.transform.name + " HWS", hwStart);
			PlayerPrefs.SetInt( this.gameObject.transform.name + " SS", studyStart);
			PlayerPrefs.SetInt( this.gameObject.transform.name + " LU", lastUpdate); // fairly straightforward
            PlayerPrefs.SetInt(this.gameObject.transform.name + " studentState", studentState);

			PlayerPrefs.Save(); // IDK
			Debug.Log("saving");
		}
		/*if( dragging )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }*/
	}
	
	
	
	void OnMouseDown()
	{
		/*if(Time.time - lastTime > dragDelay)
        {
            dragging = true;
        }
        else
        {
            ///info pop up////

            print(tagline);
            print(major);
        }*/
		print("meep");
	}
	
	/*void OnMouseUp()
    {
        dragging = false;
    }*/
}
