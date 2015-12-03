using UnityEngine;
using System.Collections;

public class AnimateChar : MonoBehaviour {

    private bool  moveUp = false;

    private float lastTime = 0f;
    private float delay = 1f;


	// Use this for initialization
	void Start () {
        transform.Translate(0, -0.03f, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if( Time.time - lastTime > delay)
        {
            if (moveUp)
            {
                transform.Translate(0, 0.01f, 0);
                moveUp = false;
            }
            else
            {
                transform.Translate(0, -0.01f, 0);
                moveUp = true;
            }

            lastTime = Time.time;
        }
	
	}
}
