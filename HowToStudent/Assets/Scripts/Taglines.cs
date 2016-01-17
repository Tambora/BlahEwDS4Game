using UnityEngine;
using System.Collections;

public class Taglines : MonoBehaviour {

    //Set up so you can have general or location dependent tags... There may be a better way of doing this
    //1-General
    //2-Location specific - Mackenzie

   private string[][] taglines = new string[][] 
    {
       new string[] { 
			"What day is\nit?",
			"I hope class\nis cancelled\ntoday.",
			"How do I\nfunction.",
			"Sleep is\nfor casuals.",
			"I’m almost\nout of ramen.",
			"School is\ncool."
        },
        new string[] {
            "I've been stuck in Mackenzie for ten days..."
        }
    };

    string tagPick;

    public string getTagline( int location)
    {
        tagPick = taglines[location][Random.Range(0, taglines[location].Length)];
        return tagPick;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
