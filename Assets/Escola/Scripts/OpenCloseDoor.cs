using UnityEngine;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {

	public GameObject textDoor;
	public AudioClip openDoor;
	public AudioClip closeDoorAudio;
	public bool open = false, readyToOpen, tocarAudio = false, tocarAudio2 = false;

	float counter = 0f;

	void Start ()
	{

	}
	
	void Update ()
	{	
		if(readyToOpen)
		{
			if(Input.GetKeyDown(KeyCode.E) && !this.open)
			{
				this.open = true;
				tocarAudio = true;
				readyToOpen = false;
			}
		}

		if(tocarAudio)
		{
			Tocando();
		}

		if(counter > 2.25f)
		{
			tocarAudio2 = true;
			open = false;
			counter = 0f;
		}

		if(tocarAudio2)
		{
			Tocando2();
		}

		if(open)
		{
			counter += 1f * Time.deltaTime;
		//	StartCoroutine(closeDoor());
		}

		gameObject.GetComponent<Animator> ().SetBool ("abrir", open);
	}
	// RUN SPEED 6 !
	void OnTriggerEnter(Collider col)
	{
		if(!this.open)
		{
			textDoor.SetActive(true);
			readyToOpen = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
			textDoor.SetActive(false);
			readyToOpen = false;
	}

	void Tocando()
	{
		gameObject.GetComponent<AudioSource> ().PlayOneShot (openDoor);
		tocarAudio = false;
	}

	void Tocando2()
	{
		gameObject.GetComponent<AudioSource> ().PlayOneShot (closeDoorAudio);
		tocarAudio2 = false;
	}

/*	IEnumerator closeDoor()
	{
		yield return new WaitForSeconds(3f);
		this.open = false;
		StopCoroutine("closeDoor");
	}	*/
}
