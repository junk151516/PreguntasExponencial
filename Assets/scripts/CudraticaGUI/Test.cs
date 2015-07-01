using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Test : MonoBehaviour
{
	StreamReader sr;
	string palabra, tipo;
	private int ran;
	string file = "file.txt";
	public int tamañoDelTexto;

	public void Start ()
	{
		sr = new StreamReader (Application.dataPath + "/" + file);
		Debug.Log (Application.dataPath.ToString ());
		ran = Random.Range (0, 100);
		Debug.Log (ran);
		for (int i = 0; i<ran; i++) {		
			palabra = sr.ReadLine().ToString ();
			Debug.Log(palabra);
		}
		sr.Close ();
	}
}