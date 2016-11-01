using UnityEngine;
using System.Collections;

public class Pickable1 : MonoBehaviour {

	public GameObject Txt1;

	public AbrirPortaEscola ape;

	public bool txtAppear1 = false;
	public bool onHand1 = false;
	public bool readyToPick1 = false;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if(readyToPick1)
		{
			if(Input.GetKey(KeyCode.E))
			{
				onHand1 = true;
				txtAppear1 = false;
			}
		}

		if(onHand1)
		{
			ape.comChave = true;
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
		readyToPick1 = true;
		if(!onHand1)
		{
			txtAppear1 = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		readyToPick1 = false;
		txtAppear1 = false;
	}
}
