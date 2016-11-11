using UnityEngine;
using System.Collections;

public class PickBilhete : MonoBehaviour {

	public GameObject celular, bilheteText, catraca;
	bool readyToPick = false;
	bool picked = false;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(readyToPick)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				celular.GetComponent<Celular>().indiceObj += 1;
				catraca.GetComponent<Animator>().enabled = true;
				picked = true;
			}
		}

		if(picked)
		{
			bilheteText.SetActive (false);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!picked)
		{
			readyToPick = true;
			bilheteText.SetActive (true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		readyToPick = false;
		bilheteText.SetActive (false);
	}
}
