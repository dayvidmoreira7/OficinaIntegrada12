using UnityEngine;
using System.Collections;

public class AudioContrll : MonoBehaviour {

	public AudioClip ambiente;

	AudioSource mySource;

	public bool playing = false;
	bool diminuir = true;
	bool tocandoAmbiente = false;

	void Start () 
	{
		mySource = GetComponent<AudioSource> ();
	}
	
	void Update () 
	{
		if(playing)
		{
			StartCoroutine(soundTurnDown());
		}

		if(!diminuir && !tocandoAmbiente)
		{
			mySource.clip = ambiente;
			mySource.Play();
			tocandoAmbiente = true;
		}
	}

	IEnumerator soundTurnDown()
	{
		if(mySource.volume > 0f && diminuir)
		{
			mySource.volume -= 0.02f * Time.deltaTime;
		}

		if (mySource.volume == 0f) 
		{
			diminuir = false;
		}

		if(!diminuir && mySource.volume < 0.05f)
		{
			mySource.volume += 0.02f * Time.deltaTime;
		}
		
		yield return null;
	}
}
