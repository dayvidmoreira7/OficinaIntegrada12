﻿using UnityEngine;
using System.Collections;

public class Pickable1 : MonoBehaviour {

	public GameObject Txt1;
	public GameObject celular;
	public GameObject pickKeySound;

	public AbrirPortaEscola ape;

	public bool txtAppear1 = false;
	public bool onHand1 = false;
	public bool readyToPick1 = false;
	public bool empurrado = false;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if(readyToPick1)
		{
			if(Input.GetKeyDown(KeyCode.E) && !onHand1)
			{
				celular.GetComponent<Celular>().indiceObj += 1;
				txtAppear1 = false;
				onHand1 = true;
			}
		}

		if(onHand1)
		{
			ape.comChave = true;
			Instantiate(pickKeySound, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
		}

		if(txtAppear1)
		{
			Txt1.SetActive(true);
		}
		else
		{
			Txt1.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(empurrado)
		{
			readyToPick1 = true;
			if(!onHand1)
			{
				txtAppear1 = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		readyToPick1 = false;
		txtAppear1 = false;
	}
}
