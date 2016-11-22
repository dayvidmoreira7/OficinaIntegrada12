using UnityEngine;
using System.Collections;

public class Empurrar : MonoBehaviour {

	public GameObject textEmpurrar;
	public GameObject celular;
	public GameObject key4;
	Rigidbody rb;

	bool prontoPraEmpurrar = false;
	bool scriptAtivo = true;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}


	void Update () 
	{
		if(prontoPraEmpurrar && Input.GetKeyDown(KeyCode.E))
		{
		//	rb.AddForceAtPosition(Vector3.back * 300f, transform.position);
			rb.AddForce(Vector3.back * 500f, ForceMode.Impulse);
			prontoPraEmpurrar = false;
			key4.GetComponent<Pickable1>().empurrado = true;
			scriptAtivo = false;
		}

		if(!scriptAtivo)
		{
			GetComponent<Empurrar>().enabled = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(celular.GetComponent<Celular>().indiceObj == 7)
		{
		if (scriptAtivo) 
			{
				if (!prontoPraEmpurrar) {
					textEmpurrar.SetActive (true);
					prontoPraEmpurrar = true;
				}
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textEmpurrar.SetActive(false);
		prontoPraEmpurrar = false;
	}
}
