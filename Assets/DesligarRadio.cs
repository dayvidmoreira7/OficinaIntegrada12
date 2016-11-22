using UnityEngine;
using System.Collections;

public class DesligarRadio : MonoBehaviour {

	public GameObject textRadio;
	public GameObject celular;
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
				celular.GetComponent<Celular>().indiceObj += 1;
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
