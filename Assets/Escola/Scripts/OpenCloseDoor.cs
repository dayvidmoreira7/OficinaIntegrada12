using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {

	public GameObject textDoor;
	public GameObject textLocked;
	public AudioClip openDoor;
	public AudioClip closeDoorAudio;
	public AudioClip lockWarn;
	public bool open = false,lockedWarn = false, readyToOpen, tocarAudio = false, tocarAudio2 = false, comChave = false;

	float counter = 0f;

	void Start ()
	{

	}
	
	void Update ()
	{	
		Debug.Log (lockedWarn);

		if(readyToOpen)
		{
			if(Input.GetKeyDown(KeyCode.E) && !this.open)
			{
				if(comChave)
				{
					this.open = true;
					tocarAudio = true;
					readyToOpen = false;
				}
				else
				{
					lockedWarn = true;
				}
			}
		}

		if(lockedWarn)
		{
			TocandoWarn();
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

	void TocandoWarn()
	{
		gameObject.GetComponent<AudioSource> ().PlayOneShot (lockWarn);
		lockedWarn = false;
	}


/*	IEnumerator closeDoor()
	{
		yield return new WaitForSeconds(3f);
		this.open = false;
		StopCoroutine("closeDoor");
	}	*/
}
