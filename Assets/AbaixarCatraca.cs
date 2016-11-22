using UnityEngine;
using System.Collections;

public class AbaixarCatraca : MonoBehaviour {

	bool open = false;
	bool readyToOpen = false;

	public GameObject textCatraca;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		Debug.Log (open);

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
