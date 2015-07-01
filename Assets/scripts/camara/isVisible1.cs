using UnityEngine;
using System.Collections;

public class isVisible1 : MonoBehaviour {
	public bool isVisible ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		isVisible = GetComponent<Renderer>().isVisible;

		if (isVisible){
			Debug.Log("I see you");

		}

	}
}
