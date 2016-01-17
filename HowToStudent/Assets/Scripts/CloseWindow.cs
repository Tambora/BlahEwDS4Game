using UnityEngine;
using System.Collections;

public class CloseWindow : MonoBehaviour {

    private GameObject studentGen;
    private CreateStudent createStudent;

    bool first = true;

    // Use this for initialization
    void Start()
    {
        studentGen = GameObject.Find("GameObject");
        createStudent = studentGen.GetComponent<CreateStudent>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
		Debug.Log ("helllo");
        if ( createStudent.first )
        {
            createStudent.SpawnStudent();
            createStudent.first = false;
        }
		Debug.Log ("destroying");
        Destroy(this.transform.parent.gameObject);
		Debug.Log ("destroyed");
		AudioSource[] audioSources = GameObject.Find("Main Camera").GetComponents<AudioSource>();
		audioSources[2].Play();
    }
}
