using UnityEngine;
using System.Collections;

public class AudioContrll : MonoBehaviour {

	public AudioClip abertura;

	AudioSource mySource;

	void Start () 
	{
		mySource = GetComponent<AudioSource> ();
		mySource.clip = abertura;
		mySource.Play ();
	}
	
	void Update () 
	{
	}
}
