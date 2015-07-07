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
	public float d;
	public int ladoDelVertice;
	public int cantidadDeInterceptos;
	StreamReader sr;
	string palabra, tipo;
	private int ran;
	string file = "file2.txt";
	public int tBaseDatos;
	public bool resultado;
	public InputField valorDeA;
	public InputField valorDeB;
	public InputField valorDeC;
	public InputField valorDeCrecimiento;
	public Text botonA;
	public Text botonB;
	public Text Repuesta;
	public UnityEngine.UI.Image fondoRta;
	public bool[] preguntas;
	public GameObject[] objetosADeshabilitar;
	public GameObject[] objetosAHabilitar;
	public crearExponencial scCurva;
	public GameObject[] coordenadasPlano;
	public GameObject camara;
	public GameObject vertice;
	public Text TutuloProblema;
	public Text marcador;
	public Text marcadorCorrectas;
	public int cantidadPregunta;
	public int limitePreguntas;
	public int contadorCorrectas;
	public Text IndicadorResultado;
	public GameObject ObjetoMarcadorFinal;
	public GameObject[] medalla;
	public Image cantidadInterseptos;
	public Image ladoVertice;
	public Text marcadorFinal;
	public string[] animales; 
	public string[] indCantidad; 
	public GameObject[] respondido; 
	public Sprite correcto;
	public Sprite incorrecto;
	public Image validador1;
	public Image validador2;
	public bool respondio1 = false;
	public bool respondio2 = false;
	public GameObject fondoPregunta1;
	public GameObject fondoPregunta2;
	// Use this for initialization
	void Awake () {
		//scCurva = GameObject.Find ("Curva").GetComponent<crearExponencial>();
//
//		sr = new StreamReader (Application.dataPath + "/StreamingAssets/" + file);
//		//Debug.Log (Application.dataPath.ToString ());
//
//		for (int i = 0; i<tBaseDatos; i++) {		
//			palabra = sr.ReadLine().ToString ();
//			//Debug.Log(palabra);
//			string[] entries = palabra.Split(',');
//			if (entries.Length > 0){
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

		for(int i =0; i< objetosADeshabilitar.Length;i++){
			objetosADeshabilitar[i].SetActive (false);
		}
		for(int i =0; i< objetosAHabilitar.Length;i++){
			objetosAHabilitar[i].SetActive (!false);
		}
		scCurva.cambiarGrafica (a,b,c);
		generarPregunta ();
			//c = c/16.6666667;  			
	}

	public void HabilitaRta(UnityEngine.UI.Image objecto) {
		objecto.gameObject.SetActive(true);

		//yield return new WaitForSeconds(4);
		//objecto.gameObject.SetActive(false);
		//generarPregunta ();

	}

	public void pregunta1 (){
		if(!respondio1){
			fondoPregunta1.SetActive(true);
			respondio1=true;
		}
	}
	public void pregunta2 (){
		if(!respondio2){
			fondoPregunta2.SetActive(true);
			respondio2=true;
		}
	}

	public void validarRespuesta1 (){
		if (!(a == float.Parse (valorDeA.text) && b == float.Parse (valorDeB.text) && c == float.Parse (valorDeC.text))) {
			validador1.sprite = incorrecto;
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/20)";
		} else {
			validador1.sprite = correcto;
			contadorCorrectas++;
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/20)";

		}
	}

	public void validarRespuesta2 (){
		Debug.Log ((a * Mathf.Pow(b, (c * d))));

		if ((a * Mathf.Pow(b, (c * d))) == float.Parse (valorDeCrecimiento.text)) {
			validador2.sprite = correcto;
			contadorCorrectas++;
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/20)";

		} else {
			validador2.sprite = incorrecto;
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/20)";
		}
	}
	public void generarPregunta () {

		if(cantidadPregunta<=limitePreguntas){

		for(int i =0; i< objetosADeshabilitar.Length;i++){
			objetosADeshabilitar[i].SetActive (true);
		}
		for(int i =0; i< objetosAHabilitar.Length;i++){
			objetosAHabilitar[i].SetActive (false);
		}
		valorDeA.text = "";
		valorDeB.text = "";
		valorDeC.text = "";
		valorDeCrecimiento.text = "";
		respondido[0].SetActive(false);
		respondido[1].SetActive(false);
		respondio1 = false;
		respondio2 = false;
		//if (float.TryParse(stringToEdit, b));// print ("Succeeded, and the result is " + b);
		//c = Random.Range(0.72, 0);

		TutuloProblema.text = "Pregunta "+cantidadPregunta;

		string[] textos = new string[4];
		string textoAleatorio = animales[Random.Range(0,3)];
		textos[0]="Una población de "+textoAleatorio+",";
		int	ramdonValue = Random.Range(1,6);
		botonA.text = "¿Cuál es la fórmula de la función que representa el crecimiento de la población de "+textoAleatorio+"?";
		//botonB.text = "¿cuánta cantidad de "+textoAleatorio+" hay a los "+ ramdonValue +" años?";
		//d = ramdonValue;
		botonB.text = "¿cuánta cantidad de "+textoAleatorio+" hay despues de un año?";
		d = 1;
		ramdonValue = Random.Range(2,50);
		textos[1]=" tiene una población inicial de "+ramdonValue+" individuos";
		a = ramdonValue;
		ramdonValue = Random.Range(0,5);
		b = ramdonValue+2;
		textoAleatorio = indCantidad[ramdonValue];
		textos[2]=" se "+textoAleatorio;
		ramdonValue = Random.Range(2,6);
		c = ramdonValue;
		textos[3]=" cada "+ramdonValue+" años";
		
		
		textoProblema.text = textos[0];
		int j =0; 
		int[] repetido = new int[3];

		ramdonValue = Random.Range(0,2);
				
			if(ramdonValue==0){
				textoProblema.text= textoProblema.text+ textos[1];
				ramdonValue = Random.Range(0,2);
				if(ramdonValue==0){
					textoProblema.text= textoProblema.text +" y"+ textos[2]+textos[3]+".";
				}else{
					textoProblema.text= textoProblema.text +" y"+ textos[3]+textos[2]+".";
				}
			}else{
				ramdonValue = Random.Range(0,2);
				if(ramdonValue==0){
					textoProblema.text= textoProblema.text + textos[2]+textos[3];
				}else{
					textoProblema.text= textoProblema.text + textos[3]+textos[2];
				}
				textoProblema.text= textoProblema.text+" y"+ textos[1]+".";
			}

			marcador.text = "Pregunta("+cantidadPregunta+"/"+limitePreguntas+")";
			marcadorCorrectas.text = "Correctas("+contadorCorrectas+"/20)";
			cantidadPregunta++;
		}else{
			// habilita el marcador final
			generarMarcadorFinal ();
		}
		scCurva.cambiarGrafica (a,b,c);
	}
	public void generarMarcadorFinal () {
		ObjetoMarcadorFinal.SetActive(true);
		marcadorFinal.text = "Puntaje ("+contadorCorrectas+"/20)";
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