using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbrirPortaEscola : MonoBehaviour {

	public GameObject textDoor;
	public AudioClip openDoor;
	public GameObject myDoor;
	public bool open = false, readyToOpen, tocarAudio = false;

	public GameObject trancado;

	bool comChave = true;
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
				}
				else
				{
					exibitText = true;
				}
			}
		}

		myDoor.GetComponent<Animator> ().SetBool ("abrir", open);

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
		yield return new WaitForSeconds(3.8f);
		this.open = false;
		StopCoroutine("closeDoor");
	}
}
