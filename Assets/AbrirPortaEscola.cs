using UnityEngine;
using System.Collections;

public class AbrirPortaEscola : MonoBehaviour {

	public GameObject textDoor;
	public AudioClip openDoor;
	public GameObject myDoor1;
	public GameObject myDoor2;
	public bool open = false, readyToOpen, tocarAudio = false;
	public float rotY1 = 0f, rotY2 = 0f;
	
	void Start ()
	{

	}
	
	void Update () // p1 ganha | p2 perde
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
			if(rotY1 < 120f)
			{
				rotY1 += 120.1f * 0.5f * Time.deltaTime;
			}

			if(rotY2 > -120f)
			{
				rotY2 -= 120.1f * 0.5f * Time.deltaTime;
			}
		}
		else
		{
			if(rotY1 > 0f)
			{
				rotY1 -= 120.1f * 0.5f * Time.deltaTime;
			}

			if(rotY2 < 0f)
			{
				rotY2 += 120.1f * 0.5f * Time.deltaTime;
			}
		}	
		
		myDoor1.GetComponent<Transform>().localEulerAngles = new Vector3(0f, rotY1, 0f);
		myDoor2.GetComponent<Transform>().localEulerAngles = new Vector3(0f, rotY2, 0f);
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
