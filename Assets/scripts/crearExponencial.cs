using UnityEngine;
using System.Collections;

public class crearExponencial : MonoBehaviour {
	public LineRenderer miLineRender;
	public int puntos	= 20;
	public float a		= 1;
	public float b		= 1;
	public float c		= 0;
	
	public float desde	= 0;
	public float hasta	= 0;
	public ViewDrag detener;


	void Start () 
	{
		//desde = desde * 50;
		//hasta = hasta * 50;
		crearGrafica();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) Start ();
		//Start ();
	}
	
	public float f(float x)
	{
		return((a*Mathf.Exp(b*x)));

		//return((Mathf.Sin (a + b*x/10))*100);
	}
	
	public void crearGrafica()
	{
		detener.moverGrafica(false);
		int contador = 0;
		miLineRender = gameObject.GetComponent<LineRenderer>();
		// mueve el vertice de posicion 

		//math.Pow (f : float, p : float)
		//((-b+(Mathf.Sqrt ((b*b)-(4*a*c))))/(2*a));

		//(Mathf.Sqrt (b*b-(4*a*c))) ;

		float espacio;
		float npun = puntos + 0.0f;
		espacio = (hasta-desde) / npun;
		
		for (int i = 0; i < puntos; i++)
		{
			miLineRender.SetPosition (contador, new Vector3(0,f (desde + i*espacio), desde + i*espacio));
			contador ++;
		}
	}
	
	public void cambiarA(float nA)
	{
		a=nA;
		crearGrafica();
	}
	
	public void cambiarB(float nB)
	{
		b=nB;
		crearGrafica();
	}
	
	public void cambiarC(float nC)
	{
		c=nC;
		crearGrafica();
	}
	public void cambiarGrafica(float nA,float nB, float nC)
	{
		a=nA;
		b=nB;
		c=nC;
		crearGrafica();
	}
}
