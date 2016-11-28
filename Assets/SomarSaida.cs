using UnityEngine;
using System.Collections;

public class SomarSaida : MonoBehaviour {

	GameObject raposa;

	void Start () {
		raposa = GameObject.Find("Raposa");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (raposa.GetComponent<IA> ().saida);
	}

	void OnTriggerEnter(Collider col)
	{
		if(raposa.GetComponent<IA>().saida < 3)
		{
			raposa.GetComponent<IA> ().saida += 1;
			raposa.GetComponent<IA> ().target = GameObject.Find("SaidaRaposa" + raposa.GetComponent<IA>().saida.ToString()).transform;
		}

		if(raposa.GetComponent<IA>().saida == 3)
		{
			raposa.GetComponent<IA>().saida = 0;
			Destroy(GameObject.Find("SaidaRaposa2"));
			raposa.SetActive(false);
		}

		Destroy (this.gameObject);
	}
}
