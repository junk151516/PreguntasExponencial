using UnityEngine;
using System.Collections;

public class TamañoLetras : MonoBehaviour {
	public float anchoMinimo	= 0.16f;	
	public float anchoMaximo = 1.0f;
	public float nWidth;
	public Camera miCamara;
	
	
	void Start () 
	{
		if (miCamara == null)
		{
			miCamara = Camera.main;
		}
	}
	
	
	void Update () 
	{
		cambiarZomm (miCamara.orthographicSize);
	}
	
	public void cambiarZomm(float nZoom)
	{
		nWidth = anchoMinimo*nZoom;

			gameObject.transform.localScale = new Vector3 (nWidth,nWidth,nWidth);

	}
}
