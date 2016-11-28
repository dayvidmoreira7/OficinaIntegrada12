using UnityEngine;
using System.Collections;

public class AudioContrll : MonoBehaviour {

	public AudioClip abertura;
	public AudioClip ambiente;

	AudioSource mySource;

	public bool playing = false;
	bool diminuir = true;

	void Start () 
	{
		mySource = GetComponent<AudioSource> ();
		mySource.clip = abertura;
		mySource.Play ();
	}
	
	void Update () 
	{
		if(playing)
		{
			StartCoroutine(soundTurnDown());
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
			mySource.clip = ambiente;
			mySource.volume += 0.02f * Time.deltaTime;
		}
		
		yield return null;
	}
}
