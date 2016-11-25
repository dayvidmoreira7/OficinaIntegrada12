using UnityEngine;
using System.Collections;

public class Perseguir : MonoBehaviour {

	GameObject raposa;

	public GameObject saida1;
	public GameObject saida2;
	public GameObject saida3;

	void Start () 
	{
		raposa = GameObject.Find("Raposa");
	}
	
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		raposa.GetComponent<IA> ().andar = true;
		raposa.GetComponent<IA> ().define = true;

		if(raposa.GetComponent<IA>().lantPower == false)
		{
			saida1.SetActive (true);
			saida2.SetActive (true);
			saida3.SetActive (true);
		}

		Destroy (gameObject);
	}
}
