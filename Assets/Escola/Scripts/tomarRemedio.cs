using UnityEngine;
using System.Collections;

public class tomarRemedio : MonoBehaviour {

	public GameObject playerCam;
	public GameObject textRemedio;

	float counter = 0f;

	bool prontoPraTomar = false, tomou = false;

	UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vac;
	UnityStandardAssets.ImageEffects.MotionBlur mb;

	void Start () 
	{
		vac = playerCam.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();
		mb = playerCam.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>();
	}
	
	void Update () 
	{
		if(prontoPraTomar && Input.GetKeyDown(KeyCode.E) && !tomou)
		{
			tomou = true;
		}

		if(tomou)
		{
			counter += 1f * Time.deltaTime;

			if(vac.chromaticAberration < 300f)
			{
				vac.chromaticAberration += 30f * Time.deltaTime;
			}
			
			if(mb.blurAmount < 0.75f)
			{
				mb.blurAmount += 0.15f * Time.deltaTime;
			}
		}
		if(!tomou)
		{
			if(vac.chromaticAberration > 0.2f)
			{
				vac.chromaticAberration -= 30f * Time.deltaTime;
			}
			
			if(mb.blurAmount > 0f)
			{
				mb.blurAmount -= 0.15f * Time.deltaTime;
			}
		}

		if(counter > 60f)
		{
			tomou = false;
			counter = 0f;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(!tomou)
		{
			textRemedio.SetActive(true);
			prontoPraTomar = true;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		textRemedio.SetActive(false);
		prontoPraTomar = false;
	}
}
