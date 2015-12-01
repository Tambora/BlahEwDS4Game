using UnityEngine;
using System.Collections;

public class Majors : MonoBehaviour {

    private string[] majors = new string[] 
    {
        "Architecture",
        "Information Technology",
        "Industrial Design",
        "Health Sciences",
        "Commerce",
        "International Business",
        "Social Work",
        "Cognitive Science",
        "Mathematics",
        "Computer Science",
        "Science",
        "Music",
        "Public Affairs and Policy Management",
        "Engineering",
        "Humanities",
        "Language Studies",
        "Arts",
        "Global and International Studies",
        "Journalism",
        "Communication and Media Studies"
    };

    private string majorPick;

    public string getMajor()
    {
        majorPick = majors[Random.Range(0, majors.Length)];
        return majorPick;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
