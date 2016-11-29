using UnityEngine;
using System.Collections;

public class DestroyAudioSouce : MonoBehaviour {

	float counter = 0f;

	void Start () 
	{
	
	}
	
	void Update ()
	{
		counter += 1f * Time.deltaTime;

		if(counter > GetComponent<AudioSource>().clip.length)
		{
			Destroy(gameObject);
		}
	}
}
