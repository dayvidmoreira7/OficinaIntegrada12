using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pilhas : MonoBehaviour {

	public GameObject text;
	public GameObject bScript;
	public GameObject maxText;

	bool peguei;
	bool pegar;
	bool numeroMaximo;

	bool contagemTxt;
	float aparecerTxt = 0f;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if(bScript.GetComponent<BatteryCount>().numeroBaterias == 5)
		{
			numeroMaximo = true;
		}
		else
		{
			numeroMaximo = false;
		}

		if(pegar)
		{
			if(Input.GetKey(KeyCode.E))
			{
				if(!numeroMaximo)
				{
					bScript.GetComponent<BatteryCount>().numeroBaterias += 1;
					peguei = true;
					text.SetActive(false);
					contagemTxt = false;
					Destroy(gameObject);
				}
				else
				{
					contagemTxt = true;
				}
			}
		}


		if(contagemTxt)
		{
			aparecerTxt += 1f * Time.deltaTime;
			maxText.GetComponent<Text>().enabled = true;
		}
		else
		{
			maxText.GetComponent<Text>().enabled = false;
		}
		if(aparecerTxt > 1)
		{
			contagemTxt = false;
			aparecerTxt = 0f;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!peguei)
		{
			pegar = true;
			text.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
		pegar = false;
	}
}
