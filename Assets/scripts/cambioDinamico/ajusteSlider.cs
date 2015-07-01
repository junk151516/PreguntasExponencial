using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ajusteSlider : MonoBehaviour {
	public float anchoMinimo = 1f;	
	public float anchoMaximo = 1f;
	public float nWidth;
	public Camera miCamara;
	public Slider sl;
	
	void Start () 
	{
		if (miCamara == null)
		{
			miCamara = Camera.main;
		}
		sl = gameObject.GetComponent <Slider>();

	}
	
	
	void Update () 
	{
		cambiarZomm (miCamara.orthographicSize);
	}
	
	public void cambiarZomm(float nZoom)
	{	
		if (Mathf.Abs( sl.value)<nZoom*anchoMaximo){
			sl.minValue = -nZoom*anchoMinimo;
			sl.maxValue = nZoom*anchoMaximo;
		}else{

		}
	}
}
