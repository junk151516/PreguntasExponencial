using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class multiplicador_ejes : MonoBehaviour {
	public int cantidad			= 10;
	public GameObject Padre;
	public GameObject lineaAMultiplicar;
	public GameObject numeroInstanciar;
	public Vector3 posicionEje	=  new Vector3(0,1,0);
	public float nEscala 		= 1;
	public static float Escala	= 1;
	
	public GameObject[] ejesPositivos;
	public GameObject[] ejesNegativos;
	
	public GameObject[] numerosPositivos;
	public GameObject[] numerosNegativos;
	public ViewDrag limites;


	void Start () {
		ejesPositivos = new GameObject[cantidad];
		ejesNegativos = new GameObject[cantidad];
		numerosPositivos = new GameObject[cantidad];
		numerosNegativos = new GameObject[cantidad];

		for (int i = 1; i<cantidad ; i++)
		{
			Vector3 nPos = posicionEje * i;
			nPos.z = 10;
			ejesPositivos[i] = Instantiate (lineaAMultiplicar, nPos ,lineaAMultiplicar.transform.rotation) as GameObject;
			ejesPositivos[i].transform.parent = Padre.transform;
			numerosPositivos[i] = Instantiate (numeroInstanciar, nPos, Quaternion.identity) as GameObject;
			numerosPositivos[i].transform.parent = ejesPositivos[i].transform;


			nPos =  -posicionEje * i;
			nPos.z = 10;
			ejesNegativos[i] = Instantiate (lineaAMultiplicar, nPos ,lineaAMultiplicar.transform.rotation) as GameObject;
			ejesNegativos[i].transform.parent = Padre.transform;
			numerosNegativos[i] = Instantiate (numeroInstanciar, nPos, Quaternion.identity) as GameObject;
			numerosNegativos[i].transform.parent = ejesNegativos[i].transform;
		}
		Reposicionar ();
		if(posicionEje.x==1){
			limites.setLimiteDerecha(ejesPositivos[cantidad-1]);
			limites.setLimiteIzquierda(ejesNegativos[cantidad-1]);
		}else{
			limites.setLimiteSuperior(ejesPositivos[cantidad-1]);
			limites.setLimiteInferior(ejesNegativos[cantidad-1]);
		}
	}

	void Update()
	{
		if (nEscala != Escala)
		{
			Reposicionar ();
			nEscala = Escala;
		}
	}
	public void Reposicionar()
	{
		for (int i = 1; i<cantidad ; i++)
		{
			Vector3 nPos = posicionEje * i * Escala;
			nPos.z = 10;
			ejesPositivos[i].transform.position = nPos;
			numerosPositivos[i].GetComponentInChildren<Text>().text = ((float) i * Escala).ToString();
			
			nPos =  -posicionEje * i * Escala;
			nPos.z = 10;
			ejesNegativos[i].transform.position = nPos;
			numerosNegativos[i].GetComponentInChildren<Text>().text = ((float) -i * Escala).ToString();
		}
	}

}
