using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour 
{

	public float VelocidadZoom = 0.1f;        // Velocidad en la que actualizara el Zoom
	public float minimo = 1;
	public float maximo = 10;
	public Camera miCamara;

	void Awake()
	{
		miCamara = gameObject.GetComponent<Camera>();
	}
	
	
	void Update()
	{
		
		// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Ubica los puntos tocados.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			
			// If the camera is orthographic...
			if (miCamara.orthographic)
			{
				if ((miCamara.orthographicSize + deltaMagnitudeDiff * VelocidadZoom )> minimo  && (miCamara.orthographicSize + deltaMagnitudeDiff * VelocidadZoom )< maximo)
				{
				// ... change the orthographic size based on the change in distance between the touches.
					miCamara.orthographicSize += deltaMagnitudeDiff * VelocidadZoom;
					
					// Make sure the orthographic size never drops below zero.
					miCamara.orthographicSize = Mathf.Max(miCamara.orthographicSize, 0.1f);

					if (miCamara.orthographicSize < 4)
					{
						multiplicador_ejes.Escala = 0.5f;
					}else if (miCamara.orthographicSize < 7)
					{
						multiplicador_ejes.Escala = 1.0f;
					}else if (miCamara.orthographicSize < 10)
					{
						multiplicador_ejes.Escala = 2f;
					}else if (miCamara.orthographicSize < 30)
					{
						multiplicador_ejes.Escala = 5f;
					}else if (miCamara.orthographicSize <=40)
					{
						multiplicador_ejes.Escala = 10f;
					}
				}
			}
		}
	}
}
