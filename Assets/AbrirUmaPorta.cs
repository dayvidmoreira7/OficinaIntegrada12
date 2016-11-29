using UnityEngine;
using System.Collections;

public class AbrirUmaPorta : MonoBehaviour {

	public GameObject minhaPorta;
	public GameObject doorParticle;
	public GameObject celular;
	public GameObject chaveText;
	public GameObject soundPickKey;

	bool peguei = false;
	bool praPegar = false;

	void Start () 
	{
	
	}
	
	void Update ()
	{
		if(praPegar)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				peguei = true;
			}
		}

		if(peguei)
		{
			doorParticle.SetActive(true);
			minhaPorta.GetComponent<Animator>().enabled = true;
			minhaPorta.GetComponent<OpenCloseDoor>().comChave = true;
			celular.GetComponent<Celular>().indiceObj += 1;
			chaveText.SetActive (false);
			Instantiate(soundPickKey, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!peguei)
		{
			chaveText.SetActive (true);
			praPegar = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		chaveText.SetActive (false);
		praPegar = false;
	}
}
