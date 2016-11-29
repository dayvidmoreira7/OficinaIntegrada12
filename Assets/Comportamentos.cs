using UnityEngine;
using System.Collections;

public class Comportamentos : MonoBehaviour {

	public GameObject myCam;
	public GameObject raposa;

	float resetcounter = 0f;

	bool run;

	UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vca;
	UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;

	void Start () {
		vca = myCam.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();
		fps = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
	}
	
	void Update () 
	{

	}

	void OnTriggerEnter(Collider col)
	{
	/*	if(col.name == "Raposa")
		{
			raposa.GetComponent<IA>().seguirPlayer = true;
			raposa.GetComponent<IA>().define = true;
		}	*/
	}
}
