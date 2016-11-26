using UnityEngine;
using System.Collections;

public class ObjetivoUp : MonoBehaviour {

	public GameObject celular;
	public GameObject cartao;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(celular.GetComponent<Celular>().indiceObj == 1)
		{
			cartao.SetActive (true);
			celular.GetComponent<Celular> ().indiceObj += 1;
			celular.GetComponent<Celular>().indiceMsg += 1;
			Destroy (gameObject);
		}

		if(celular.GetComponent<Celular>().indiceObj == 3)
		{
			celular.GetComponent<Celular> ().indiceObj += 1;
			Destroy (gameObject);
		}	

		if(celular.GetComponent<Celular>().indiceObj == 7)
		{
			celular.GetComponent<Celular> ().indiceObj += 1;
			Destroy (gameObject);
		}	

	}
}
