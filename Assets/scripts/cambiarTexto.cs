using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cambiarTexto : MonoBehaviour {
	public string prefijo 	= "A= ";
	public float dividirPor	= 1;

	public void cambiarPorFloat(float texto)
	{
		gameObject.GetComponent<Text>().text = prefijo + texto.ToString ("n2");
	}

}
