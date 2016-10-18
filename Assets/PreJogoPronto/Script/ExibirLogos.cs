using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ExibirLogos : MonoBehaviour {

	public List<Sprite> images = new List<Sprite>();

	public GameObject canvasPreJogo;

	float speed = 0.5f;

	int counter = 0;
	bool fadeIn = true;

	void Start () 
	{

	}
	
	void Update () 
	{
		gameObject.GetComponent<Image> ().sprite = images [counter];
		StartCoroutine (doFade ());

		if(Input.GetKey(KeyCode.Space))
		{
			speed = 1f;
		}
		else
		{
			speed = 0.5f;
		}

		switch(counter)
		{
		case 0:
			transform.localScale = new Vector3(0.4712027f, 0.3569443f, 0.7085786f);
			break;
		case 1:
			transform.localScale = new Vector3(0.4712027f, 0.3569443f, 0.7085786f);
			break;
		case 2:
			transform.localScale = new Vector3(0.4712027f, 0.3569443f, 0.7085786f);
			break;
		case 3:
			transform.localScale = new Vector3(0.4712027f, 0.3569443f, 0.7085786f);
			break;
		case 4:
			transform.localScale = new Vector3(0.4712027f, 0.3569443f, 0.7085786f);
			break;
		case 5:
			transform.localScale = new Vector3(0.8051217f, 0.1782459f, 0.7085786f);
			break;
		}
	}

	IEnumerator doFade()
	{
		CanvasGroup cg = gameObject.GetComponent<CanvasGroup> ();

		if(fadeIn)
		{
			if(cg.alpha < 1f)
			{
				cg.alpha += speed * Time.deltaTime;
			}
			if(cg.alpha > 1f)
			{
				fadeIn = false;
			}
		}
		if(!fadeIn)
		{
			if(cg.alpha > 0f)
			{
				cg.alpha -= speed * Time.deltaTime;
			}
			if(cg.alpha < 0f && counter < 5)
			{
				counter += 1;
				fadeIn = true;
			}
		}
		if(cg.alpha < 0f && counter == 5 && !fadeIn)
		{
			canvasPreJogo.GetComponent<CanvasGroup>().alpha -= 0.25f * Time.deltaTime;
			if(canvasPreJogo.GetComponent<CanvasGroup>().alpha < 0f)
			{
				Destroy(canvasPreJogo);
			}
		}
		yield return null;
	}
}
