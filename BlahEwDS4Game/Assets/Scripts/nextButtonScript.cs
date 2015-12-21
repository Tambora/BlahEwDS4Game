using UnityEngine;
using System.Collections;

public class nextButtonScript : MonoBehaviour {
	
		private GameObject find;
		private grads gradss;
		
		
		// Use this for initialization
		void Start () {
			find = GameObject.Find("UI_gradIcon");
			gradss = find.GetComponent<grads> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
		void OnMouseDown() {
			gradss.pageNumbers += 1;
			Destroy(this.transform.parent.gameObject);
			gradss.graduationList ();
		}
	}
