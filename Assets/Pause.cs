using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	bool jogando;

	bool pause = false;
	float time = 1f;

	public GameObject player;
	public GameObject camCursor;
	public GameObject menuJogar;
	public GameObject pausePanel;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		jogando = menuJogar.GetComponent<PlayGame> ().jogando;

		if(jogando)
		{
			if(Input.GetKeyDown(KeyCode.Escape) && !pause)
			{
				pause = true;
			}
			else if(Input.GetKeyDown(KeyCode.Escape) && pause)
			{
				pause = false;

			}
		}

		switch(pause)
		{
		case true:
			Pausar();
			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
			camCursor.GetComponent<Mira>().jogando = false;
			pausePanel.SetActive(true);
			break;
		case false:
			Despausar();
			player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			camCursor.GetComponent<Mira>().jogando = true;
			pausePanel.SetActive(false);
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
