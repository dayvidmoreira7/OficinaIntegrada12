using UnityEngine;
using System.Collections;

public class Empurrar : MonoBehaviour {

	public GameObject textEmpurrar;
	Rigidbody rb;

	bool prontoPraEmpurrar = false;

	void Start () {
	
	}


	void Update () 
	{
		if(prontoPraEmpurrar && Input.GetKeyDown(KeyCode.E))
		{
			prontoPraEmpurrar = false;
			GetComponent<Empurrar>().enabled = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!prontoPraEmpurrar)
		{
			textEmpurrar.SetActive(true);
			prontoPraEmpurrar = true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textEmpurrar.SetActive(false);
		prontoPraEmpurrar = false;
	}
}
