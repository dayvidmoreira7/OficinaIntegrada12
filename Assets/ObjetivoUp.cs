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
		cartao.SetActive (true);
		celular.GetComponent<Celular> ().indiceObj += 1;
		Destroy (gameObject);
	}
}
