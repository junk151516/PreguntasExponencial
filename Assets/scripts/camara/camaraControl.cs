using UnityEngine;
using System.Collections;

public class camaraControl : MonoBehaviour {
	bool bDragging;
	Vector3 oldPos;
	Vector3 panOrigin;
	public float panSpeed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetMouseButtonDown(0))
//		{
//			bDragging = true;
//			oldPos = transform.position;
//			panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
//		}
//		
//		if(Input.GetMouseButton(0))
//		{
//			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;    //Get the difference between where the mouse clicked and where it moved
//			transform.position = oldPos + -pos * panSpeed;                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
//		}
//		
//		if(Input.GetMouseButtonUp(0))
//		{
//			bDragging = false;
//		}
	}

	public void cambiarZoom(float nzoom)
	{
		gameObject.GetComponent<Camera>().orthographicSize = nzoom;

		if (nzoom < 4)
		{
			multiplicador_ejes.Escala = 0.5f;
		}else if (nzoom < 7)
		{
			multiplicador_ejes.Escala = 1.0f;
		}else if (nzoom < 10)
		{
			multiplicador_ejes.Escala = 2f;
		}else if (nzoom < 30){
			multiplicador_ejes.Escala = 5f;
		}else if (nzoom <=40){
			multiplicador_ejes.Escala = 10f;
		}
	}
}
