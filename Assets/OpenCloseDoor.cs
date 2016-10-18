using UnityEngine;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {

	public GameObject textDoor;
	public AudioClip openDoor;
	public GameObject myDoor;
	public bool open = false, readyToOpen, tocarAudio = false;
	public float rotY = 0f;
	
	void Start ()
	{
		this.myDoor = GameObject.Find("Porta" + this.gameObject.name);
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

		if(open)
		{
			this.StartCoroutine(closeDoor());
			if(rotY > -60f)
			{
				rotY -= 60.1f * 0.5f * Time.deltaTime;
			}
		}
		else
		{
			if(rotY < 0f)
			{
				rotY += 60.1f * 0.5f * Time.deltaTime;
			}
		}	

		this.myDoor.GetComponent<Transform>().localEulerAngles = new Vector3(0f, rotY, 0f);
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

	IEnumerator closeDoor()
	{
		yield return new WaitForSeconds(4f);
		this.open = false;
		StopCoroutine("closeDoor");
	}
}
