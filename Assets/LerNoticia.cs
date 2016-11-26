using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LerNoticia : MonoBehaviour {

	public GameObject noticia;
	public GameObject textNoticia;
	public GameObject raposa;
	public GameObject triggerZombi;

	public AudioClip mod3;

	public bool radioDesligado = false;
	bool firstRead = false;

	bool mostrandoNoticia = false;
	bool prontoPraMostrar = false;

	public GameObject celular;

	void Start () 
	{
	}
	
	void Update () 
	{
		if(prontoPraMostrar)
		{
			if(Input.GetKeyDown(KeyCode.E) && !mostrandoNoticia)
			{
				mostrandoNoticia = true;
			}
			else if(Input.GetKeyDown(KeyCode.E) && mostrandoNoticia)
			{
				mostrandoNoticia = false;
			}

			if(!firstRead && Input.GetKeyDown(KeyCode.E))
			{
				celular.GetComponent<Celular>().indiceObj += 1;
				GetComponent<AudioSource>().PlayOneShot(mod3);
				firstRead = true;
			}
		}

		switch(mostrandoNoticia)
		{
		case true:
			noticia.SetActive(true);
			raposa.SetActive(true);
			triggerZombi.SetActive(true);
			break;
		case false:
			noticia.SetActive(false);
			break;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(radioDesligado)
		{
			if(!mostrandoNoticia)
			{
				textNoticia.SetActive (true);
				prontoPraMostrar = true;
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textNoticia.SetActive (false);
		prontoPraMostrar = false;
		mostrandoNoticia = false;
	}
}
