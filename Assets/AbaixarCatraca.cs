using UnityEngine;
using System.Collections;

public class AbaixarCatraca : MonoBehaviour {

	bool open = false;
	bool tocando = false;
	bool readyToOpen = false;

	public GameObject textCatraca;
	public AudioClip audioCatraca;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(readyToOpen)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				open = true;
			}
		}

		if(open)
		{
			StartCoroutine(openFalse());
		}

		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Open") && !tocando)
		{
			GetComponent<AudioSource>().PlayOneShot(audioCatraca);
			tocando = true;
		}

		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			tocando = false;
		}

		GetComponent<Animator> ().SetBool ("open", open);
	}

	void OnTriggerEnter(Collider col)
	{
		if(GetComponent<Animator>().enabled == true)
		{
			readyToOpen = true;
			textCatraca.SetActive (true);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		readyToOpen = false;
		textCatraca.SetActive (false);
	}

	IEnumerator openFalse()
	{
		yield return new WaitForSeconds (0.1f);
		open = false;
		StopCoroutine("openFalse");
	}
}
