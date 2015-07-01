using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cambiarTamanoTexto : MonoBehaviour {

	public float anchoMinimo	= 0.01f;	
	public float anchoMaximo	= 0.2f;	
	public Camera miCamara;
	
	private LineRenderer miLineRender;
	
	void Start () 
	{
		if (miCamara == null)
		{
			miCamara = Camera.main;
		}
		miLineRender = gameObject.GetComponent <LineRenderer>();
	}
	
	
	void Update () 
	{
		cambiarZomm (miCamara.orthographicSize / 10.0f);
	}
	
	public void cambiarZomm(float nZoom)
	{
		float nWidth = anchoMinimo + (anchoMaximo - anchoMinimo)*nZoom;
		miLineRender.SetWidth (nWidth,nWidth);
	}
}