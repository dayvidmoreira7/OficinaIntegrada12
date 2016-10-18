using UnityEngine;
using System.Collections;

public class onoffsound : MonoBehaviour {

	float timetoSound = 0f;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(gameObject.GetComponent<OnOff>().tocarSom)
		{
			gameObject.GetComponent<AudioSource>().enabled = true;
			timetoSound += 1f * Time.deltaTime;
		}

		if(timetoSound > 0.436f)
		{
			gameObject.GetComponent<OnOff>().tocarSom = false;
			gameObject.GetComponent<AudioSource>().enabled = false;
			timetoSound = 0f;
		}
	}
}
