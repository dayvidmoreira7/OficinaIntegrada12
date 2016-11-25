using UnityEngine;
using System.Collections;

public class DesligarRadio : MonoBehaviour {

	public GameObject textRadio;
	public GameObject celular;
	public GameObject noticia;

	bool desligar = false;
	bool prontopraDesligar = false;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if(prontopraDesligar)
		{
			if(Input.GetKeyDown(KeyCode.E) && !desligar)
			{
				GetComponent<AudioSource>().enabled = false;
				noticia.GetComponent<LerNoticia>().radioDesligado = true;
				celular.GetComponent<Celular>().indiceObj += 1;
				gameObject.GetComponent<BoxCollider>().enabled = false;
				textRadio.SetActive(false);
				desligar = true;
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!desligar && celular.GetComponent<Celular>().indiceObj == 5)
		{
			textRadio.SetActive (true);
			prontopraDesligar = true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textRadio.SetActive (false);
		prontopraDesligar = false;
	}
}
