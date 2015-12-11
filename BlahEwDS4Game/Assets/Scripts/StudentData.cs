using UnityEngine;
using System.Collections;

public class StudentData : MonoBehaviour {
	
	public string name;
	public string tagline;
	public string major;
	public float CGPA;
	
	private float lastTime = 0f;
	private float dragDelay = 1f;
	private float distance;
	private bool dragging = false;
	
	private float DECAY_RATE = 0.09375f;
	private float HW_DECAY = -0.33f;
	private float S_DECAY = -0.00625f;
	
	public int studentState; // (0=neutral, 1=study, 2=hw, 3 = fail 4 = graduated)
	private int numUpdates;
	
	public int studyStart;
	public int hwStart;
	private int systemTime;
	private int inactiveTime;
	public int lastUpdate;
    
	public int enrollSemester;
	public int currentSemester;
    
	System.DateTime epochStart;

	private int half = 1;
	private int full = 2;
	private int day = 12;

	public bool semesterEnd;

	
	// Use this for initialization
	void Start () {
		epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
    }
	
	// Update is called once per frame
	void Update () {
		
		 systemTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
        
        if (currentSemester < systemTime/day && studentState < 3) {

            currentSemester = (int)(systemTime - enrollSemester*day)/day;
            int semesterUpdate = (currentSemester + enrollSemester) * day;
            
			if (hwStart + full*3 > semesterUpdate) {
				int hwUpdates = (int)(semesterUpdate - (hwStart + full*3)/half);
				inactiveTime = systemTime - (hwStart+full*3);
				numUpdates = (int)((inactiveTime - full*8)/half);
				
                if (CGPA + hwUpdates * HW_DECAY - numUpdates * DECAY_RATE < 3){
                    studentState = 3;
					Debug.Log("THIS IS HW");
                }
            }
            
			else if (studyStart + full*8 > semesterUpdate) {
				int studyUpdates = (int)(semesterUpdate - (studyStart + full*8)/half);
				inactiveTime = systemTime - (studyStart+full*8);
				numUpdates = (int)((inactiveTime - full*8)/half);
				if (CGPA + studyUpdates * S_DECAY - numUpdates * DECAY_RATE < 3) {
                    studentState = 3;
					Debug.Log("THIS IS NOT HW");

                }
            }
            
            else {
                inactiveTime = systemTime - semesterUpdate;
				numUpdates = (int)(inactiveTime/half);
				if (CGPA + numUpdates * DECAY_RATE < 3){
                    studentState = 3;
					Debug.Log(CGPA - numUpdates * DECAY_RATE);

                }
            }
			if (currentSemester > 7){
				studentState = 4;

			}
        }
		
		if (systemTime - lastUpdate > half && studentState < 3) {
			if (studyStart > lastUpdate) {
				inactiveTime = systemTime - studyStart;
				if(inactiveTime > full*8) {
					numUpdates = (int)((inactiveTime - full*8)/half);
					CGPA = 0.1f + CGPA - numUpdates * DECAY_RATE;
					studentState = 0;
				}
				else {
					numUpdates = (int)(inactiveTime/half);
					CGPA = CGPA - numUpdates * S_DECAY;
					studentState = 1;
				}
				lastUpdate = ((int)(inactiveTime/half))*half + studyStart; 
			}
			
			else if (hwStart > lastUpdate) {
				inactiveTime = systemTime - hwStart;
				if(inactiveTime > full*3) {
					numUpdates = (int)((inactiveTime - full*3)/half);
					CGPA = 2 + CGPA - numUpdates * DECAY_RATE;
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
				CGPA = 12f;
			if (CGPA < 0)
				CGPA = 0;
			//PlayerPrefs.SetFloat("Current GPA", CGPA);
			//PlayerPrefs.SetInt("Student State", studentState);
			//PlayerPrefs.SetInt("Latest Update", lastUpdate);
			
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
