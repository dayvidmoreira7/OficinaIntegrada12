using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbrirPortaEscola : MonoBehaviour {

	public GameObject textDoor;
	public AudioClip openDoor;
	public AudioClip lockedDoor;
	public GameObject myDoor1;
	public GameObject myDoor2;
	public bool open = false, readyToOpen, tocarAudio = false, tocarAudio2 = false;
	
	public GameObject trancado;

	public bool comChave = false;
	bool exibitText = false;
	float contagemtxt = 0f;

	void Start ()
	{

	}
	
	void Update () // p1 ganha | p2 perde
	{	
		if(readyToOpen)
		{
			if(Input.GetKeyDown(KeyCode.E) && !this.open)
			{
				if(comChave)
				{
					this.open = true;
					tocarAudio = true;
					readyToOpen = false;
					gameObject.GetComponent<Animator> ().SetBool ("abrir", true);
				}
				else
				{
					this.open = false;
					exibitText = true;
					tocarAudio2 = true;
					gameObject.GetComponent<Animator> ().SetBool ("abrir", false);
				}
			}
		}

		if(open)
		{
			StartCoroutine(closeDoor());
		}

		if(exibitText)
		{
			trancado.GetComponent<Text>().enabled = true;
			contagemtxt += 1f* Time.deltaTime;
		}
		else
		{
			trancado.GetComponent<Text>().enabled = false;
		}

		if(contagemtxt > 2f)
		{
			exibitText = false;
			contagemtxt = 0f;
		}

		if(tocarAudio)
		{
			Tocando();
		}

		if(tocarAudio2)
		{
			Tocando2();
		}

		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			gameObject.GetComponent<BoxCollider>().enabled = true;
			myDoor1.GetComponent<BoxCollider>().enabled = false;
			myDoor2.GetComponent<BoxCollider>().enabled = false;
		}

		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AbrirFechar"))
		{
			gameObject.GetComponent<BoxCollider>().enabled = false;
			myDoor1.GetComponent<BoxCollider>().enabled = true;
			myDoor2.GetComponent<BoxCollider>().enabled = true;
		}

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
		gameObject.GetComponent<AudioSource> ().PlayOneShot (lockedDoor);
		tocarAudio2 = false;
	}

	IEnumerator closeDoor()
	{
		yield return new WaitForSeconds(3.8f);
		this.open = false;
		gameObject.GetComponent<Animator> ().SetBool ("abrir", false);
		StopCoroutine("closeDoor");
	}
}
