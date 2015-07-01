using UnityEngine;
using System.Collections;

public class ViewDrag : MonoBehaviour {
	Vector3 hit_position = Vector3.zero;
	Vector3 current_position = Vector3.zero;
	Vector3 camera_position = Vector3.zero;
	float z = -10.0f;

	public Transform CamaraDelJuego;
	public bool moverSiNo=true;
	public GameObject limiteSuperior;
	public GameObject limiteInferior;
	public GameObject limiteIzquierda;
	public GameObject limiteDerecha;
	public bool izquierda;
	public bool derecha;
	public bool arriba;
	public bool abajo;
	// CambiaElEstado
	void Awake () 
	{
		if (CamaraDelJuego==null)
		{
			CamaraDelJuego = Camera.main.transform;
		}
	}
	
	void Update(){

		// si suelta el track activa el mover
		if(Input.GetMouseButtonUp(0)){
			moverSiNo=true;
		}
		if (!moverSiNo) return;

		if (Input.touchCount >1) return;

		if(Input.GetMouseButtonDown(0)){
			hit_position = Input.mousePosition;
			camera_position = CamaraDelJuego.position;
			
		}
		if(Input.GetMouseButton(0)){
			current_position = Input.mousePosition;
			LeftMouseDrag();        
		}
	}
	
	void LeftMouseDrag(){

		if (!moverSiNo) return;
		if (Input.touchCount >1) return;
		// From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
		// with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
		current_position.z = hit_position.z = camera_position.y;
		
		// Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
		// anyways.  
		Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
		
		// Invert direction to that terrain appears to move with the mouse.
		arriba = limiteSuperior.gameObject.GetComponent<Renderer>().isVisible;
		abajo = limiteInferior.gameObject.GetComponent<Renderer>().isVisible;
		izquierda = limiteIzquierda.gameObject.GetComponent<Renderer>().isVisible;
		derecha = limiteDerecha.gameObject.GetComponent<Renderer>().isVisible;

		if(direction.x < 0 && derecha){	
			camera_position.x = CamaraDelJuego.position.x;
			Debug.Log ("derecha");
			direction.x = 0;
		}
		if(direction.x > 0 && izquierda){
			camera_position.x = CamaraDelJuego.position.x;
			Debug.Log ("izquierda");
			direction.x = 0;
		}
		if(direction.y < 0 && arriba){
			camera_position.y = CamaraDelJuego.position.y;
			Debug.Log ("arriba");
			direction.y = 0;
		}
		if(direction.y > 0 && abajo){
			camera_position.y = CamaraDelJuego.position.y;
			Debug.Log ("abajo");
			direction.y = 0;
		}


		direction = direction * -1;
		
		Vector3 position = camera_position + direction;
		
		CamaraDelJuego.position = position;
	}
	public void moverGrafica(bool val)
	{
		moverSiNo=val;
	}
	public void setLimiteInferior(GameObject li){
		limiteInferior = li;
	}
	public void setLimiteSuperior(GameObject ls){
		limiteSuperior = ls;
	}
	public void setLimiteIzquierda(GameObject liz){
		limiteIzquierda = liz;
	}
	public void setLimiteDerecha(GameObject ld){
		limiteDerecha = ld;
	}
}