using UnityEngine;
using System.Collections;

public class escenas : MonoBehaviour {

	public void cargarEscena(string escena)
	{
		Application.LoadLevel (escena);
	}
}
