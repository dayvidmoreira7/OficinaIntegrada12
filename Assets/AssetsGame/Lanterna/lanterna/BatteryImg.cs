using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatteryImg : MonoBehaviour {

	public GameObject lanterna;

	public Sprite b0;
	public Sprite b1;
	public Sprite b2;
	public Sprite b3;
	public Sprite b4;

	bool poucaBateria = false;
	float piscar = 1f;
	float piscar1;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		piscar1 = Mathf.Floor (piscar);

		if(lanterna.GetComponent<OnOff>().energy > 6f)
		{
			gameObject.GetComponent<Image>().sprite = b4;
		}	
		else if(lanterna.GetComponent<OnOff>().energy > 4f && lanterna.GetComponent<OnOff>().energy < 6f)
		{
			gameObject.GetComponent<Image>().sprite = b3;
		}
		else if(lanterna.GetComponent<OnOff>().energy > 2f && lanterna.GetComponent<OnOff>().energy < 4f)
		{
			gameObject.GetComponent<Image>().sprite = b2;
		}
		else if(lanterna.GetComponent<OnOff>().energy > 0f && lanterna.GetComponent<OnOff>().energy < 2f)
		{
			gameObject.GetComponent<Image>().sprite = b1;
		}
		else
		{
			gameObject.GetComponent<Image>().sprite = b0;
		}

		if(gameObject.GetComponent<Image>().sprite == b1 && lanterna.GetComponent<OnOff>().energy < 1f)
		{
			poucaBateria = true;
		}
		else
		{
			poucaBateria = false;
		}

		if(poucaBateria)
		{
			piscar += 1 * Time.deltaTime;
			if(piscar1 % 4 == 1 || piscar1 % 4 == 3)
			{
				gameObject.GetComponent<Image>().enabled = false;
			}
			if(piscar1 % 4 == 2 || piscar1 % 4 == 0)
			{
				gameObject.GetComponent<Image>().enabled = true;
			}
		}
		else
		{
			gameObject.GetComponent<Image>().enabled = true;
		}

	//	gameObject.GetComponent<Image> ().sprite = b3;
	}
}
