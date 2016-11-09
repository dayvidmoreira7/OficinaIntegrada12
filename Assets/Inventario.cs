using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventario : MonoBehaviour {

	public List<GameObject> slots;

	public GameObject player;
	public GameObject camCursor;
	public GameObject invPanel; 

	bool inv = false;
	float time;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I) && !inv)
		{
			inv = true;
		}
		else if(Input.GetKeyDown(KeyCode.I) && inv)
		{
			inv = false;
		}

		switch(inv)
		{
		case true:
			Pausar();
			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
			camCursor.GetComponent<Mira>().jogando = false;
			invPanel.SetActive(true);
			break;
		case false:
			Despausar();
			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			camCursor.GetComponent<Mira>().jogando = true;
			invPanel.SetActive(false);
			break;
		}

		Time.timeScale = time;
	}

	void Pausar()
	{
		time = 0f;
	}
	
	void Despausar()
	{
		time = 1f;
	}
}
