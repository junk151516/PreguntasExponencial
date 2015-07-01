using UnityEngine;
using System.Collections;

using UnityEngine.UI; 
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CuadraticaCS : MonoBehaviour {

	public Text textoProblema;
	public int aleatorio;
	public float a;
	public float b;
	public float c;
	public Vector2[] preguntas1;
	public int ladoDelVertice;
	public int cantidadDeInterceptos;
	StreamReader sr;
	string palabra, tipo;
	private int ran;
	string file = "file2.txt";
	public int tBaseDatos;
	public bool resultado;
	public InputField valorDeB;
	public Text Repuesta;
	public UnityEngine.UI.Image fondoRta;
	public bool[] preguntas;
	public GameObject[] objetosADeshabilitar;
	public GameObject[] objetosAHabilitar;
	public crearCurva2 scCurva;
	public GameObject[] coordenadasPlano;
	public GameObject camara;
	public GameObject vertice;
	public Text marcador;
	public Text marcadorCorrectas;
	public int cantidadPregunta;
	public int limitePreguntas;
	public int contadorCorrectas;
	public Text IndicadorResultado;
	public GameObject ObjetoMarcadorFinal;
	public GameObject[] medalla;
	public Sprite[] IMGcantidadInterseptos;
	public Sprite[] IMGladoVertice;
	public Image cantidadInterseptos;
	public Image ladoVertice;
	public Text marcadorFinal;

	// Use this for initialization
	void Awake () {
//		scCurva = GameObject.Find ("Curva").GetComponent<crearCurva2>();
//
//		sr = new StreamReader (Application.dataPath + "/StreamingAssets/" + file);
//		//Debug.Log (Application.dataPath.ToString ());
//
//		for (int i = 0; i<tBaseDatos; i++) {		
//			palabra = sr.ReadLine().ToString ();
//			//Debug.Log(palabra);
//			string[] entries = palabra.Split(',');
//			if (entries.Length > 0){
//				preguntas1[i].x = float.Parse(entries[0]);
//				preguntas1[i].y = float.Parse(entries[1]);
//			}
//		}
//		sr.Close ();
		generarPregunta ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			for(int i =0; i< objetosADeshabilitar.Length;i++){
				objetosADeshabilitar[i].SetActive (true);
			}
			for(int i =0; i< objetosAHabilitar.Length;i++){
				objetosAHabilitar[i].SetActive (false);
			}
		}
	}

	public void validarRespuesta () {
	
		camara.transform.localPosition = new Vector3(0,0,-10);
		b = float.Parse(valorDeB.text);		
		coordenadasPlano[1].SetActive(false);
		coordenadasPlano[0].SetActive(false);
		//botonResponder.gameObject.SetActive(true);
		resultado = true; 
		bool banderaIntersepto = false;
		bool banderaVertice = false;
		if (b==0){
			resultado = false; 
		}
		if((-b/(2*a))<0){                    // si es negativo en x 
			if ( ladoDelVertice!= 0){ // izquierda != izquierda
				resultado = false; 
				Repuesta.text = "Incorrecto"; 
				ladoVertice.gameObject.SetActive(true);

				ladoVertice.sprite = IMGladoVertice[1];
				coordenadasPlano[1].SetActive(true);
				coordenadasPlano[0].SetActive(false);
				banderaVertice = true;
			}else{
				coordenadasPlano[0].SetActive(true);
				coordenadasPlano[1].SetActive(false);
			}

		}
		if((-b/(2*a))>0){            // si es positivo en x 
			if ( ladoDelVertice!= 1){ // derecha 
				resultado = false;
				Repuesta.text = "Incorrecto"; 
				ladoVertice.gameObject.SetActive(true);

				ladoVertice.sprite = IMGladoVertice[0];
				coordenadasPlano[0].SetActive(true);
				coordenadasPlano[1].SetActive(false);
				banderaVertice = true;
			}else{
				coordenadasPlano[1].SetActive(true);				
				coordenadasPlano[0].SetActive(false);				
			}

		}

		
		if(((b*b)-(4*a*c))<0){   //si tiene cero interceptos 
			if (cantidadDeInterceptos != 0){ // cero interceptos 
				resultado = false;
				if (cantidadDeInterceptos == 1){	
					Repuesta.text = "Incorrecto"; 
					cantidadInterseptos.gameObject.SetActive(true);	
					cantidadInterseptos.sprite = IMGcantidadInterseptos[1];
					banderaIntersepto = true;
				}
				if (cantidadDeInterceptos == 2){
					Repuesta.text = "Incorrecto"; 
					cantidadInterseptos.gameObject.SetActive(true);	
					cantidadInterseptos.sprite = IMGcantidadInterseptos[2];
					banderaIntersepto = true;
				}
			}
		}
		if(((b*b)-(4*a*c))==0) {
			if (cantidadDeInterceptos != 1){ // un interceptos 
				resultado = false;
				if (cantidadDeInterceptos == 0){	
					Repuesta.text = "Incorrecto";
					cantidadInterseptos.gameObject.SetActive(true);	
					cantidadInterseptos.sprite = IMGcantidadInterseptos[0];
					banderaIntersepto = true;
				}
				if (cantidadDeInterceptos == 2){
					Repuesta.text = "Incorrecto"; 					
					cantidadInterseptos.gameObject.SetActive(true);	
					cantidadInterseptos.sprite = IMGcantidadInterseptos[2];
					banderaIntersepto = true;
				}
			}
		}
		if(((b*b)-(4*a*c))>0) {
			if (cantidadDeInterceptos != 2){ // dos interceptos 
				resultado = false;
				if (cantidadDeInterceptos == 1){	
					Repuesta.text = "Incorrecto"; 		
					cantidadInterseptos.gameObject.SetActive(true);	
					cantidadInterseptos.sprite = IMGcantidadInterseptos[1];
					banderaIntersepto = true;
				}
				if (cantidadDeInterceptos == 0){
					Repuesta.text = "Incorrecto"; 
					cantidadInterseptos.gameObject.SetActive(true);	

					cantidadInterseptos.sprite = IMGcantidadInterseptos[0];	
					banderaIntersepto = true;
				}
			}
		}
		if(!banderaIntersepto){
			cantidadInterseptos.gameObject.SetActive(false);
		}
		if(!banderaVertice){
			ladoVertice.gameObject.SetActive(false);
		}
		if(banderaIntersepto&&banderaVertice ){
			Repuesta.text = "La respuesta fue incorrecta ya que fallaste en aplicar las siguientes fórmulas correctamente.";
		}
		if(banderaIntersepto&&!banderaVertice ){
			Repuesta.text = "La respuesta fue incorrecta ya que fallaste en aplicar la siguiente fórmula correctamente.";
		}
		if(!banderaIntersepto&&banderaVertice ){
			Repuesta.text = "La respuesta fue incorrecta ya que fallaste en aplicar la siguiente fórmula correctamente.";
		}


			if(resultado){ // si pasa
				
				HabilitaRta(fondoRta);
				Repuesta.text = "Correcto"; 
			cantidadInterseptos.sprite = null; 
				contadorCorrectas++;
			//resultadoTextura.texture = 	tipoResultado[0];	// pone un true	
			}else{
				HabilitaRta(fondoRta);
				
				//Repuesta.text = "Incorrecto"; 
				//resultadoTextura.texture = 	tipoResultado[1];	// pone un false	
			}
		
		for(int i =0; i< objetosADeshabilitar.Length;i++){
			objetosADeshabilitar[i].SetActive (false);
		}
		for(int i =0; i< objetosAHabilitar.Length;i++){
			objetosAHabilitar[i].SetActive (!false);
		}
		scCurva.cambiarGrafica (a,b,c);
			//c = c/16.6666667;  			
	}

	public void HabilitaRta(UnityEngine.UI.Image objecto) {
		objecto.gameObject.SetActive(true);

		//yield return new WaitForSeconds(4);
		//objecto.gameObject.SetActive(false);
		//generarPregunta ();

	}

	public void generarPregunta () {

		if(cantidadPregunta<=limitePreguntas){

		for(int i =0; i< objetosADeshabilitar.Length;i++){
			objetosADeshabilitar[i].SetActive (true);
		}
		for(int i =0; i< objetosAHabilitar.Length;i++){
			objetosAHabilitar[i].SetActive (false);
		}
		valorDeB.text = "";
		aleatorio = Random.Range(0, preguntas1.Length);
		a = preguntas1[aleatorio].x;
		c = preguntas1[aleatorio].y;
		//if (float.TryParse(stringToEdit, b));// print ("Succeeded, and the result is " + b);
		//c = Random.Range(0.72, 0);
		ladoDelVertice = Random.Range(0, 2);
		textoProblema.text = "Sea <b><i>f(X)=<color=#008000ff>a</color>x²+"
			+"<color=#0000ffff>b</color>x+"
				+"<color=#ffa500ff>c</color></i></b>"
				+"\nDados <b><i><color=#008000ff>a</color></i></b>="+a+" y <b><i><color=#ffa500ff>c</color></i></b>="+c+","
				+" encuentre un valor de <b><i><color=#0000ffff>b</color></i></b> tal que el vértice de la"
				+" parábola esté a la ";
		
		if (ladoDelVertice == 0){
			textoProblema.text = textoProblema.text + "<b>izquierda </b>"; // el ramdom es cero esta a la derecha.
		}else{
			textoProblema.text = textoProblema.text + "<b>derecha </b>"; // el ramdom es cero esta a la derecha.
		}
		if ( ladoDelVertice!= 0){ // izquierda != izquierda
			coordenadasPlano[1].SetActive(true);
			coordenadasPlano[0].SetActive(false);
		}else{
			coordenadasPlano[0].SetActive(true);
			coordenadasPlano[1].SetActive(false);
		}
		cantidadDeInterceptos = Random.Range(0, 3);
		textoProblema.text = textoProblema.text 
			+"del eje <b><i>y</i></b>, que tenga <b>"+cantidadDeInterceptos+"</b> interceptos con el "
				+"eje <b>x</b>"
				//+" <b><i><color=#008000ff>a</color></i></b> = "+a
				//+" <b><i><color=#0000ffff>b</color></i></b> = ?"
				//+" <b><i><color=#ffa500ff>c</color></i></b> = "+c
				;
			marcador.text = "Pregunta("+cantidadPregunta+"/"+limitePreguntas+")";
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/"+(cantidadPregunta-1)+")";
			cantidadPregunta++;
		}else{
			// habilita el marcador final
			generarMarcadorFinal ();
		}
	}
	public void generarMarcadorFinal () {
		ObjetoMarcadorFinal.SetActive(true);
		marcadorFinal.text = "Puntaje ("+contadorCorrectas+"/"+(cantidadPregunta-1)+")";
		if(contadorCorrectas>=limitePreguntas-1){
			IndicadorResultado.text="Excelente, has comprendido el tema a la perfección.";

			medalla[0].SetActive(true);
			medalla[1].SetActive(false);
			medalla[2].SetActive(false);
		}else{
			if(contadorCorrectas<=limitePreguntas-1&&contadorCorrectas>(limitePreguntas/3)){
				IndicadorResultado.text="Aunque comprendes los temas te falta algo de repaso, revisa bien en que estas fallando y vuelve a poner a prueba tus conocimientos.";
				medalla[0].SetActive(false);
				medalla[1].SetActive(true);
				medalla[2].SetActive(false);
			}else{
				IndicadorResultado.text="Intenta de nuevo, usa las formulas indicadas y veras una gran mejoría en tu nota final.";
				medalla[0].SetActive(false);
				medalla[1].SetActive(false);
				medalla[2].SetActive(true);
			}
		}
		cantidadPregunta = 1;
		contadorCorrectas = 0;
	}
}