using UnityEngine;
using System.Collections;

public class Empurrar : MonoBehaviour {

	public GameObject textEmpurrar;
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
			rb.AddForce(Vector3.back * 5f, ForceMode.Impulse);
			prontoPraEmpurrar = false;
			scriptAtivo = false;
		}

		if(!scriptAtivo)
		{
			GetComponent<Empurrar>().enabled = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (scriptAtivo) 
		{
			if (!prontoPraEmpurrar) {
				textEmpurrar.SetActive (true);
				prontoPraEmpurrar = true;
			}
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textEmpurrar.SetActive(false);
		prontoPraEmpurrar = false;
	}
}
