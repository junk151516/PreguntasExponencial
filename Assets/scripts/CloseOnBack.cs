using UnityEngine;
using System.Collections;

public class CloseOnBack : MonoBehaviour {
	public GameObject objetosADeshabilitar;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			objetosADeshabilitar.SetActive (false);
		}
	}
}
