using UnityEngine;
using System.Collections;

public class StudentData : MonoBehaviour {

    public string tagline;
    public string major;
    public float CGPA;
    public float coffee;

    private float lastTime = 0f;
    private float dragDelay = 1f;
    private float distance;

    private bool dragging = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
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
